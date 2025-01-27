using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Dev2.Activities.Designers2.Core;
using Dev2.Activities.Designers2.Core.Source;
using Dev2.Common;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Core;
using Dev2.Common.Interfaces.ServerProxyLayer;
using Dev2.Common.Interfaces.ToolBase;
using Dev2.Common.Interfaces.WebService;
using Dev2.Studio.Core.Activities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Dev2.Activities.Designers.Tests.Core
{
    [TestClass]

    public class WebPostInputRegionTest
    {
        [TestMethod]
        public void TestInputCtor()
        {
            var id = Guid.NewGuid();
            var act = new DsfWebPostActivity() { SourceId = id };

            var mod = new Mock<IWebServiceModel>();
            mod.Setup(a => a.RetrieveSources()).Returns(new List<IWebServiceSource>());
            var srcreg = new WebSourceRegion(mod.Object, ModelItemUtils.CreateModelItem(new DsfWebPostActivity()));
            var region = new WebPostInputRegion(ModelItemUtils.CreateModelItem(act), srcreg);
            Assert.AreEqual(region.IsEnabled, false);
            Assert.AreEqual(region.Errors.Count, 0);
        }

        [TestMethod]
        public void TestInputCtorEmpty()
        {
            var mod = new Mock<IWebServiceModel>();
            mod.Setup(a => a.RetrieveSources()).Returns(new List<IWebServiceSource>());
            var region = new WebPostInputRegion();
            Assert.AreEqual(region.IsEnabled, false);
        }

        [TestMethod]
        public void TestClone()
        {
            var id = Guid.NewGuid();
            var act = new DsfWebPostActivity() { SourceId = id };

            var mod = new Mock<IWebServiceModel>();
            mod.Setup(a => a.RetrieveSources()).Returns(new List<IWebServiceSource>());
            var srcreg = new WebSourceRegion(mod.Object, ModelItemUtils.CreateModelItem(new DsfWebPostActivity()));
            var region = new WebPostInputRegion(ModelItemUtils.CreateModelItem(act), srcreg) { PostData = "bob" };
            Assert.AreEqual(region.IsEnabled, false);
            Assert.AreEqual(region.Errors.Count, 0);
            if (region.CloneRegion() is WebPostInputRegion clone)
            {
                Assert.AreEqual(clone.IsEnabled, false);
                Assert.AreEqual(clone.Errors.Count, 0);
                Assert.AreEqual(clone.PostData, "bob");
            }
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("WebInputRegion_RestoreFromPrevious")]
        public void WebPostInputRegion_RestoreFromPrevious_Restore_ExpectValuesChanged()
        {
            //------------Setup for test--------------------------
            var id = Guid.NewGuid();
            var act = new DsfWebPostActivity() { SourceId = id };

            var mod = new Mock<IWebServiceModel>();
            mod.Setup(a => a.RetrieveSources()).Returns(new List<IWebServiceSource>());
            var srcreg = new WebSourceRegion(mod.Object, ModelItemUtils.CreateModelItem(new DsfWebPostActivity()));
            var region = new WebPostInputRegion(ModelItemUtils.CreateModelItem(act), srcreg);
            var regionToRestore = new WebPostInputRegion(ModelItemUtils.CreateModelItem(act), srcreg);
            regionToRestore.IsEnabled = true;
            regionToRestore.QueryString = "blob";
            regionToRestore.Headers = new ObservableCollection<INameValue> { new NameValue("a", "b") };
            //------------Execute Test---------------------------
            region.RestoreRegion(regionToRestore as IToolRegion);
            //------------Assert Results-------------------------

            Assert.AreEqual(region.QueryString, "blob");
            Assert.AreEqual(region.Headers.First().Name, "a");
            Assert.AreEqual(region.Headers.First().Value, "b");
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("WebInputRegion_RestoreFromPrevious")]
        public void WebInputRegion_SrcChanged_UpdateValues()
        {
            //------------Setup for test--------------------------
            var id = Guid.NewGuid();
            var act = new DsfWebPostActivity() { SourceId = id };

            var mod = new Mock<IWebServiceModel>();
            var lst = new List<IWebServiceSource> { new WebServiceSourceDefinition() { HostName = "bob", DefaultQuery = "Dave" }, new WebServiceSourceDefinition() { HostName = "f", DefaultQuery = "g" } };
            mod.Setup(a => a.RetrieveSources()).Returns(lst);
            var srcreg = new WebSourceRegion(mod.Object, ModelItemUtils.CreateModelItem(new DsfWebPostActivity()));
            var region = new WebPostInputRegion(ModelItemUtils.CreateModelItem(act), srcreg);

            srcreg.SelectedSource = lst[0];
            Assert.AreEqual(region.QueryString, "Dave");
            Assert.AreEqual(region.RequestUrl, "bob");
        }
    }
}