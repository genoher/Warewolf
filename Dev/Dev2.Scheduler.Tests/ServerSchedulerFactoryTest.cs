/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Text;
using Dev2.Common;
using Dev2.Common.Interfaces.Scheduler.Interfaces;
using Dev2.Common.Interfaces.WindowsTaskScheduler.Wrappers;
using Dev2.Common.Interfaces.Wrappers;
using Dev2.Common.Wrappers;
using Dev2.Runtime.Security;
using Dev2.TaskScheduler.Wrappers;
using Dev2.TaskScheduler.Wrappers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32.TaskScheduler;
using Moq;


namespace Dev2.Scheduler.Test
{
    [TestClass]
    public class ServerSchedulerFactoryTest
    {
        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerSchedulerFactory_Constructor")]
        public void ServerSchedulerFactory_Constructor()
        {
            var service = new Mock<IDev2TaskService>().Object;
            var cFactory = new Mock<ITaskServiceConvertorFactory>().Object;
            var mockDirectory = new Mock<IDirectory>();
            mockDirectory.Setup(a => a.CreateIfNotExists(It.IsAny<string>())).Verifiable();
            var factory = new ServerSchedulerFactory(service, cFactory, mockDirectory.Object, a => a.WorkflowName);
            Assert.AreEqual(cFactory, factory.ConvertorFactory);
            Assert.AreEqual(service, factory.TaskService);
            mockDirectory.Verify(a => a.CreateIfNotExists(It.IsAny<string>()));
        }
        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerSchedulerFactory_Constructor")]
        public void ServerSchedulerFactory_ConstructorNulls()
        {


            try
            {
                new ServerSchedulerFactory(null, null, null, null);
            }
            catch (Exception e)
            {
                var expected = @"The following arguments are not allowed to be null: service
factory
directory
";
                var actual = e.Message;
                FixBreaks(ref expected, ref actual);
                Assert.AreEqual(expected, actual);
            }
        }
        void FixBreaks(ref string expected, ref string actual)
        {
            expected = new StringBuilder(expected).Replace(Environment.NewLine, "\n").Replace("\r", "").ToString();
            actual = new StringBuilder(actual).Replace(Environment.NewLine, "\n").Replace("\r", "").ToString();
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerSchedulerFactory_Constructor")]
        public void ServerSchedulerFactory_Default()
        {

#pragma warning disable 168
            var factory = new ServerSchedulerFactory(a => a.WorkflowName);
#pragma warning restore 168

        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerSchedulerFactory_Constructor")]
        public void ServerSchedulerFactory_Dispose()
        {

            var service = new Mock<IDev2TaskService>();
            var cFactory = new Mock<ITaskServiceConvertorFactory>().Object;
            var mockDirectory = new Mock<IDirectory>();
            mockDirectory.Setup(a => a.CreateIfNotExists(It.IsAny<string>())).Verifiable();
            var factory = new ServerSchedulerFactory(service.Object, cFactory, mockDirectory.Object, a => a.WorkflowName);
            service.Setup(a => a.Dispose()).Verifiable();
            factory.Dispose();
            service.Verify(a => a.Dispose());

        }


        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerSchedulerFactory_Model")]
        public void ServerSchedulerFactory_CreateModel()
        {
            var service = new Mock<IDev2TaskService>().Object;
            var cFactory = new Mock<ITaskServiceConvertorFactory>().Object;
            var factory = new ServerSchedulerFactory(service, cFactory, new DirectoryWrapper(), a => a.WorkflowName);
            var model = (ScheduledResourceModel)factory.CreateModel("bob", new SecurityWrapper(ServerAuthorizationService.Instance));
            Assert.AreEqual("bob", model.WarewolfFolderPath);
            Assert.IsTrue(model.WarewolfAgentPath.Contains(GlobalConstants.SchedulerAgentPath));
            Assert.IsTrue(model.DebugHistoryPath.Contains(GlobalConstants.SchedulerDebugPath));

        }


        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerSchedulerFactory_CreateResource")]
        public void ServerSchedulerFactory_CreateResource()
        {
            var service = new Mock<IDev2TaskService>();

            var cFactory = new Mock<ITaskServiceConvertorFactory>();
            cFactory.Setup(f => f.CreateExecAction("notepad", null, null))
                
                .Returns(new Dev2ExecAction(new TaskServiceConvertorFactory(), new ExecAction("notepad.exe", null, null)));
            
            var mockTask = new Mock<IDev2TaskDefinition>();
            mockTask.Setup(a => a.AddAction(It.IsAny<IAction>()));
            mockTask.Setup(a => a.AddTrigger(It.IsAny<ITrigger>()));
            mockTask.Setup(a => a.XmlText).Returns("bob");
            service.Setup(a => a.NewTask()).Returns(mockTask.Object);

            var factory = new ServerSchedulerFactory(service.Object, cFactory.Object, new Mock<IDirectory>().Object, a => a.WorkflowName);
            var trig = new DailyTrigger();
            var res = factory.CreateResource("A", SchedulerStatus.Disabled, trig, "c", Guid.NewGuid().ToString());
            Assert.AreEqual("A", res.Name);
            Assert.AreEqual(SchedulerStatus.Disabled, res.Status);

            Assert.AreEqual("c", res.WorkflowName);
        }


        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerSchedulerFactory_CreateDailyTrigger")]
        public void ServerSchedulerFactory_CreateBootTrigger()
        {
            CheckTriggerTypes(new BootTrigger());
        }
        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerSchedulerFactory_CreateDailyTrigger")]
        public void ServerSchedulerFactory_CreateDailyTrigger()
        {
            CheckTriggerTypes(new DailyTrigger());
        }



        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerSchedulerFactory_CreateEventTrigger")]
        public void ServerSchedulerFactory_CreateEventTrigger()
        {
            CheckTriggerTypes(new EventTrigger("log", "bob", 111));
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerSchedulerFactory_CreateIdleTrigger")]
        public void ServerSchedulerFactory_CreateIdleTrigger()
        {
            CheckTriggerTypes(new IdleTrigger());
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerSchedulerFactory_CreateLogonTrigger")]
        public void ServerSchedulerFactory_CreateLogonTrigger()
        {
            CheckTriggerTypes(new LogonTrigger());
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerSchedulerFactory_CreateMonthlyTrigger")]
        public void ServerSchedulerFactory_CreateMonthlyTrigger()
        {
            
            CheckTriggerTypes(new MonthlyTrigger(1, MonthsOfTheYear.AllMonths));
            
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerSchedulerFactory_CreateMonthlyDOWTrigger")]
        public void ServerSchedulerFactory_CreateMonthlyDowTrigger()
        {
            CheckTriggerTypes(new MonthlyDOWTrigger(DaysOfTheWeek.AllDays, MonthsOfTheYear.AllMonths, WhichWeek.AllWeeks));
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerSchedulerFactory_CreateRegistrationTrigger")]
        public void ServerSchedulerFactory_CreateRegistrationTrigger()
        {
            CheckTriggerTypes(new RegistrationTrigger());
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerSchedulerFactory_CreateSessionChangeTrigger")]
        public void ServerSchedulerFactory_CreateSessionChangeTrigger()
        {
            CheckTriggerTypes(new SessionStateChangeTrigger());
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerSchedulerFactory_CreateTimeTrigger")]
        public void ServerSchedulerFactory_CreateTimeTrigger()
        {
            CheckTriggerTypes(new TimeTrigger(DateTime.Now));
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("ServerSchedulerFactory_CreateWeeklyTrigger")]
        public void ServerSchedulerFactory_CreateWeeklyTrigger()
        {
            
            CheckTriggerTypes(new WeeklyTrigger(DaysOfTheWeek.AllDays, 1));
            
        }


        static void CheckTriggerTypes(Trigger t)
        {
            IDev2TaskService s = new Dev2TaskService(new TaskServiceConvertorFactory());
            ITaskServiceConvertorFactory fact = new TaskServiceConvertorFactory();
            var schedulerFactory = new ServerSchedulerFactory(s, fact, new DirectoryWrapper(), a => a.WorkflowName);


            var trig = schedulerFactory.CreateTrigger(t);
            Assert.AreEqual(t.TriggerType, trig.Trigger.TriggerType);
            Assert.AreEqual(t.ToString(), trig.Trigger.ToString());
        }
    }
}
