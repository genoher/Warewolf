using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Dev2.Activities.Designers2.Core;
using Dev2.Activities.Designers2.Core.Source;
using Dev2.Activities.Designers2.Core.Web.Put;
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
    public class WebPutInputRegionTest
    {

        [TestMethod]
        public void TestInputCtor()
        {
            var id = Guid.NewGuid();
            var act = new DsfWebPutActivity() { SourceId = id };

            var mod = new Mock<IWebServiceModel>();
            mod.Setup(a => a.RetrieveSources()).Returns(new List<IWebServiceSource>());
            var srcreg = new WebSourceRegion(mod.Object, ModelItemUtils.CreateModelItem(new DsfWebPutActivity()));
            var region = new WebPutInputRegion(ModelItemUtils.CreateModelItem(act), srcreg);

            Assert.AreEqual(false, region.IsEnabled);
            Assert.AreEqual(0, region.Errors.Count);
        }
        DsfWebPutActivity CreatePutActivity()
        {
            var id = Guid.NewGuid();
            var act = new DsfWebPutActivity() { SourceId = id };
            return act;

        }
        ISourceToolRegion<IWebServiceSource> CreateWebSourceRegion()
        {
            var mod = new Mock<IWebServiceModel>();
            mod.Setup(a => a.RetrieveSources()).Returns(new List<IWebServiceSource>());
            var srcreg = new WebSourceRegion(mod.Object, ModelItemUtils.CreateModelItem(new DsfWebPutActivity()));
            return srcreg;
        }
        [TestMethod]
        public void TestInputCtorEmpty()
        {
            var act = CreatePutActivity();
            var src = new Mock<IWebServiceSource>();

            var mod = new Mock<IWebServiceModel>();
            mod.Setup(a => a.RetrieveSources()).Returns(new List<IWebServiceSource>());
            var srcreg = new WebSourceRegion(mod.Object, ModelItemUtils.CreateModelItem(new DsfWebPutActivity()));
            var region = new WebPostInputRegion();
            Assert.AreEqual(region.IsEnabled, false);
        }


        [TestMethod]
        public void TestClone()
        {
            var id = Guid.NewGuid();
            var act = new DsfWebPutActivity
            {
                SourceId = id
            };
            var src = new Mock<IWebServiceSource>();

            var mod = new Mock<IWebServiceModel>();
            mod.Setup(a => a.RetrieveSources()).Returns(new List<IWebServiceSource>());
            var srcreg = new WebSourceRegion(mod.Object, ModelItemUtils.CreateModelItem(new DsfWebPutActivity()));
            var region = new WebPutInputRegion(ModelItemUtils.CreateModelItem(act), srcreg);
            region.PutData = "bob";
            Assert.AreEqual(region.IsEnabled, false);
            Assert.AreEqual(region.Errors.Count, 0);
            if (region.CloneRegion() is WebPutInputRegion clone)
            {
                Assert.AreEqual(clone.IsEnabled, false);
                Assert.AreEqual(clone.Errors.Count, 0);
                Assert.AreEqual(clone.PutData, "bob");
            }
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("WebInputRegion_RestoreFromPrevios")]
        public void WebPutInputRegion_RestoreFromPrevios_Restore_ExpectValuesChanged()
        {
            //------------Setup for test--------------------------
            var id = Guid.NewGuid();
            var act = new DsfWebGetActivity() { SourceId = id };
            var src = new Mock<IWebServiceSource>();

            var mod = new Mock<IWebServiceModel>();
            mod.Setup(a => a.RetrieveSources()).Returns(new List<IWebServiceSource>());
            var srcreg = new WebSourceRegion(mod.Object, ModelItemUtils.CreateModelItem(new DsfWebPutActivity()));
            var region = new WebPutInputRegion(ModelItemUtils.CreateModelItem(act), srcreg);
            var regionToRestore = new WebPutInputRegion(ModelItemUtils.CreateModelItem(act), srcreg);
            regionToRestore.IsEnabled = true;
            regionToRestore.QueryString = "blob";
            regionToRestore.Headers = new ObservableCollection<INameValue>{new NameValue("a","b")};
            //------------Execute Test---------------------------
            region.RestoreRegion(regionToRestore as IToolRegion);
            //------------Assert Results-------------------------

            Assert.AreEqual(region.QueryString, "blob");
            Assert.AreEqual(region.Headers.First().Name, "a");
            Assert.AreEqual(region.Headers.First().Value, "b");
        }


        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("WebInputRegion_RestoreFromPrevios")]
        public void WebInputRegion_SrcChanged_UpdateValues()
        {
            //------------Setup for test--------------------------
            var id = Guid.NewGuid();
            var act = new DsfWebPutActivity() { SourceId = id };
            var src = new Mock<IWebServiceSource>();

            var mod = new Mock<IWebServiceModel>();
            var  lst = new List<IWebServiceSource> { new WebServiceSourceDefinition(){HostName = "bob",DefaultQuery = "Dave"} , new WebServiceSourceDefinition(){HostName = "f",DefaultQuery = "g"} };
            mod.Setup(a => a.RetrieveSources()).Returns(lst);
            var srcreg = new WebSourceRegion(mod.Object, ModelItemUtils.CreateModelItem(new DsfWebPutActivity()));
            var region = new WebPutInputRegion(ModelItemUtils.CreateModelItem(act), srcreg);
            var regionToRestore = new WebPutInputRegion(ModelItemUtils.CreateModelItem(act), srcreg);

            srcreg.SelectedSource = lst[0];
            Assert.AreEqual(region.QueryString,"Dave");
            Assert.AreEqual(region.RequestUrl, "bob");

        }

    }
}