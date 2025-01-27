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
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using CubicOrange.Windows.Forms.ActiveDirectory;
using Dev2.Common.Interfaces.Scheduler.Interfaces;
using Dev2.Core.Tests.Utils;
using Dev2.Services.Events;
using Dev2.Services.Security;
using Dev2.Triggers.Scheduler;
using Dev2.Studio.Core;
using Dev2.TaskScheduler.Wrappers;
using Dev2.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32.TaskScheduler;
using Moq;
using TechTalk.SpecFlow;
using Dev2.Activities.Specs.BaseTypes;
using Dev2.Common.Interfaces.Enums;
using Dev2.Common.Interfaces.Studio.Controller;
using Dev2.Studio.Interfaces;
using System.IO;
using Dev2.Infrastructure.Tests;

namespace Dev2.Activities.Specs.Scheduler
{
    [Binding]
    public class SchedulerSteps
    {
        static ScenarioContext _scenarioContext;
        readonly CommonSteps _commonSteps;

        public SchedulerSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            _scenarioContext = scenarioContext;
            _commonSteps = new CommonSteps(_scenarioContext);
            CustomContainer.Register(new Mock<IExplorerTooltips>().Object);
        }

        [Given(@"I have a schedule ""(.*)""")]
        public void GivenIHaveASchedule(string scheduleName)
        {
            _scenarioContext.Add("ScheduleName", scheduleName);
        }

        [Given(@"""(.*)"" executes an Workflow ""(.*)""")]
        public void GivenExecutesAnWorkflow(string scheduleName, string workFlow)
        {
            _scenarioContext.Add("WorkFlow", workFlow);
        }

        [Given(@"""(.*)"" has a username of ""(.*)"" and a Password of ""(.*)"" and group ""(.*)""")]
        public void GivenHasAUsernameOfAndAPasswordOf(string scheduleName, string userName, string password, string groupName)
        {
            _scenarioContext.Add("UserName", userName);
            _scenarioContext.Add("Password", password);
        }

        [Given(@"""(.*)"" has a username of ""(.*)"" and a saved password")]
        public void GivenHasAUsernameOfAndAPasswordOf(string scheduleName, string userName)
        {
            _scenarioContext.Add("UserName", userName);
            _scenarioContext.Add("Password", TestEnvironmentVariables.GetVar(userName));
        }
        
        [Given(@"""(.*)"" has a Schedule of")]
        public void GivenHasAScheduleOf(string scheduleName, Table table)
        {
            AppUsageStats.LocalHost = "http://localhost:3142";
            var mockServer = new Mock<IServer>();
            var mockshell = new Mock<IShellViewModel>();
            mockshell.Setup(a => a.ActiveServer).Returns(mockServer.Object);
            mockshell.Setup(a => a.LocalhostServer).Returns(mockServer.Object);
            mockServer.Setup(a => a.GetServerVersion()).Returns("1.0.0.0");
            CustomContainer.Register(mockServer.Object);
            CustomContainer.Register(mockshell.Object);
            var mockPopupController = new Mock<IPopupController>();
            mockPopupController.Setup(controller => controller.ShowDeleteConfirmation(It.IsAny<string>())).Returns(MessageBoxResult.Yes);
            var serverRepository = ServerRepository.Instance;
            var server = serverRepository.Source;
            CustomContainer.Register(serverRepository);
            var scheduler = new SchedulerViewModel(EventPublishers.Aggregator, new DirectoryObjectPickerDialog(), mockPopupController.Object, AsyncWorkerTests.CreateSynchronousAsyncWorker().Object, new Mock<IServer>().Object, a => new Mock<IServer>().Object);

            var resourceId = table.Rows[0]["ResourceId"];

            server.Connect();
            scheduler.ScheduledResourceModel = new ClientScheduledResourceModel(server, () => { });
            scheduler.CurrentEnvironment = server;
            scheduler.CreateNewTask();
            scheduler.SelectedTask.Name = _scenarioContext["ScheduleName"].ToString();
            scheduler.SelectedTask.OldName = "bob";
            scheduler.SelectedTask.UserName = _scenarioContext["UserName"].ToString();
            scheduler.SelectedTask.Password = _scenarioContext["Password"].ToString();
            scheduler.SelectedTask.WorkflowName = _scenarioContext["WorkFlow"].ToString();
            scheduler.SelectedTask.ResourceId = string.IsNullOrEmpty(resourceId) ? new Guid("acb75027-ddeb-47d7-814e-a54c37247ec1") : new Guid(resourceId);
            scheduler.SelectedTask.NumberOfHistoryToKeep = (int)_scenarioContext["HistoryCount"];
            scheduler.SelectedTask.Status = (SchedulerStatus)_scenarioContext["TaskStatus"];
            scheduler.Errors.ClearErrors();
            var task = scheduler.SelectedTask;
            UpdateTrigger(task, table);

            var po = new PrivateObject(scheduler.CurrentEnvironment);
            var mockAuth = new Mock<IAuthorizationService>();
            mockAuth.Setup(a => a.IsAuthorized(It.IsAny<AuthorizationContext>(), null)).Returns(true);
            po.SetFieldOrProperty("AuthorizationService", mockAuth.Object);
            _scenarioContext["Scheduler"] = scheduler;
            try
            {
                scheduler.SaveCommand.Execute("");
                if (scheduler.HasErrors)
                {
                    _scenarioContext["Error"] = scheduler.Error;
                    Console.WriteLine("Error creating schedule: " + scheduler.Error);
                }
            }
            catch (Exception e)
            {
                _scenarioContext["Error"] = e.Message;
                Console.WriteLine("Error creating schedule: " + e.Message);
            }
        }

        void UpdateTrigger(IScheduledResource task, Table table)
        {
            var sched = table.Rows[0]["ScheduleType"];
            Microsoft.Win32.TaskScheduler.Trigger x;
            switch (sched)
            {
                case "At log on":
                    x = new LogonTrigger();
                    break;
                case "On a schedule":
                    x = CreateScheduleTrigger(table);
                    break;
                case "At Startup":
                    x = new BootTrigger();
                    break;
                case "On Idle":
                    x = new IdleTrigger();
                    break;
                default:
                    x = new DailyTrigger();
                    break;
            }
            task.Trigger.Trigger = new Dev2Trigger(new TaskServiceConvertorFactory(), x);
        }

        Microsoft.Win32.TaskScheduler.Trigger CreateScheduleTrigger(Table table)
        {
            var sched = table.Rows[0]["Interval"];
            switch (sched)
            {
                case "Daily":
                    return new DailyTrigger(Convert.ToInt16(table.Rows[0]["Recurs"])) { StartBoundary = DateTime.Parse(table.Rows[0]["StartDate"] + " " + table.Rows[0]["StartTime"]) };
                case "One Time":
                    return new TimeTrigger(DateTime.Parse(table.Rows[0]["StartDate"] + " " + table.Rows[0]["StartTime"]));
                case "Weekly":
                    return new WeeklyTrigger(GetDays(table.Rows[0]["Interval"].Split(new[] { ',' })));
                default:
                    return new DailyTrigger();
            }


        }

        DaysOfTheWeek GetDays(string[] split)
        {
            Enum.TryParse(split.First(), true, out DaysOfTheWeek res);

            foreach (var s in split.Except(new[] { split.First() }))
            {
                Enum.TryParse(s, true, out DaysOfTheWeek day);
                res &= day;

            }
            return res;
        }



        [Then(@"the schedule status is ""(.*)""")]
        public void ThenTheScheduleStatusIs(string status)
        {
            if (_scenarioContext["Scheduler"] is SchedulerViewModel scheduler)
            {
                scheduler.ActiveItem = new TabItem { Header = "History" };
                Thread.Sleep(12000);

                var scheduledResource = scheduler.SelectedTask;
                IList<IResourceHistory> x = scheduler.ScheduledResourceModel.CreateHistory(scheduledResource).ToList();


                if (status == "Success")
                {
                    Assert.AreEqual(ScheduleRunStatus.Success, x[0].TaskHistoryOutput.Success);
                }
                else
                {
                    Assert.IsTrue(x[0].TaskHistoryOutput.Success == ScheduleRunStatus.Error || x[0].TaskHistoryOutput.Success == ScheduleRunStatus.Error);
                }
                _scenarioContext["History"] = x;

            }
            else
            {
                throw new Exception("Where the scheduler");
            }
        }

        [Then(@"""(.*)"" has ""(.*)"" row of history")]
        public void ThenHasRowOfHistory(string scheduleName, int history) => _scenarioContext["HistoryCount"] = history;

        [Then(@"the history debug output for ""(.*)"" for row ""(.*)"" is")]
        public void ThenTheHistoryDebugOutputForForRowIs(string p0, int p1, Table table)
        {
            var resources = _scenarioContext["History"] as IList<IResourceHistory>;

            var debug = resources.First().DebugOutput;
            
            var debugTocompare = debug.Last();
            _commonSteps.ThenTheDebugOutputAs(table, debugTocompare.Outputs.SelectMany(s => s.ResultsList).ToList(), true);
        }

        [Given(@"task history ""(.*)"" is ""(.*)""")]
        public void GivenTaskHistoryIs(string scheduleName, int history) => _scenarioContext["HistoryCount"] = history;

        [Given(@"the task status ""(.*)"" is ""(.*)""")]
        public void GivenTheTaskStatusIs(string schedule, string status) => _scenarioContext["TaskStatus"] = status == "Enabled" ? SchedulerStatus.Enabled : SchedulerStatus.Disabled;

        [Then(@"the Schedule task has ""(.*)"" error")]
        public void ThenTheScheduleTaskHasError(string error)
        {
            if (error == "AN" && (!_scenarioContext.ContainsKey("Error") || _scenarioContext["Error"] == null))
            {
                Assert.Fail("Error Expected");
            }

            if (error == "NO" && _scenarioContext.ContainsKey("Error") && _scenarioContext["Error"] != null)
            {
                Assert.Fail(_scenarioContext["Error"].ToString());
            }
        }

        [When(@"the ""(.*)"" is executed ""(.*)"" times")]
        public void WhenTheIsExecutedTimes(string scheduleName, int times)
        {
            try
            {
                var i = 0;
                var x = new TaskService();
                x.GetFolder("Warewolf");
                var task = x.FindTask(scheduleName);
                Assert.IsNotNull(task, "Task " + scheduleName + " not found in Warewolf folder");
                do
                {
                    task.Run();
                    const int TimeOut = 10;
                    var time = 0;
                    while (task.State == TaskState.Running && time < TimeOut)
                    {
                        time++;
                        Thread.Sleep(1000);
                    }
                    i++;

                } while (i < times);
                if (task.LastTaskResult != 0)
                {
                    throw new Exception($"Task {scheduleName} exitted with a non-zero exit code: ({task.LastTaskResult})");
                }
            }
            catch (Exception e)
            {
                _scenarioContext["Error"] = e;
            }
        }

        public static bool AccountExists(string name)
        {
            var accountExists = false;
            try
            {
                var id = GetUserSecurityIdentifier(name);
                accountExists = id.IsAccountSid();
            }            
            catch (Exception)            
            {
                /* Invalid user account */
            }
            return accountExists;
        }

        public static SecurityIdentifier GetUserSecurityIdentifier(string name)
        {
            var acct = new NTAccount(Environment.MachineName, name);
            var id = (SecurityIdentifier)acct.Translate(typeof(SecurityIdentifier));
            return id;
        }

        public static bool CreateLocalWindowsAccount(string username, string password, string groupName)
        {
            try
            {
                var context = new PrincipalContext(ContextType.Machine);
                var user = new UserPrincipal(context);
                user.SetPassword(password);
                user.DisplayName = username;
                user.Name = username;
                user.UserCannotChangePassword = true;
                user.PasswordNeverExpires = true;

                user.Save();
                AddUserToGroup(groupName, context, user);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"error creating user" + ex.Message);
                return false;
            }
        }

        public static void AddUserToGroup(string groupName, PrincipalContext context, UserPrincipal user)
        {
            var usersGroup = GroupPrincipal.FindByIdentity(context, groupName);
            if (usersGroup != null)
            {
                usersGroup.Members.Add(user);
                usersGroup.Save();
            }
        }

        [AfterScenario("@Scheduler")]
        public static void CleanupAfterTestScheduler()
        {
            if (_scenarioContext.ContainsKey("Scheduler"))
            {
                var vm = _scenarioContext["Scheduler"] as SchedulerViewModel;
                vm?.DeleteCommand.Execute(vm.SelectedTask);
            }
        }
    }
}
