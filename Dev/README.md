# Warewolf

---------------------------
## How to Build Warewolf from Source Part 1 (Basics)
[![How to build warewolf from source Part 1](https://warewolf.io/knowledge-base/articles/how-to-build-warewolf-from-source/)]

This article outlines the steps involved to build Warewolf from source, 
as well as execute it. You’ll be creating and using microservices in no time!

### Step 0 Requirements

In order to download and build Warewolf you will need the following:

* Visual Studio 2017
* A GitHub client

### Step 1 Ensure that Warewolf is not running

Only one instance of the Warewolf Studio can run on a given machine, 
and only one instance of the Warewolf Server can run on a single port. 
Therefore before attempting to build and run Warewolf for the first time, 
make sure the Warewolf Server is stopped and the Warewolf Studio is not running.

### Step 2 Get the source

The entirety of the Warewolf codebase is stored in the Warewolf Open Source GitHub Repository. 
The steps for getting the source code is outlined in the Getting Started: Getting the code article. 
Please also check the ‘Readme’ section on the GitHub site for updates on dependencies or tools required.

### Step 3 Open the solution files

The two main solutions required to build and execute Warewolf are *Server.sln* and *Studio.sln*. 
The files will be located in [[PathToGitHub]]\Dev\. Open both of these solutions in Visual Studio.

### Step 4 Build and execute

* Click on the start button of the Server solution in Visual studio. 
  This will bring up a console window. The following image shows a successful server start
  Successful Server Start as seen in the Building Warewolf form a source Knowledge Base Article  
  [![Captura 1](https://warewolf.io/knowledge-base/wp-content/uploads/2015/03/build-warewolf-source-successful-server-start1-768x402.png)]
  
* Once the server has loaded; click on the start button in the Studio solution in Visual Studio. 
  This will first display the studio splash screen and then bring up the Warewolf Studio as shown in the screenshot below.
  Screenshot of how to warewolf studio
  [![Captura 2](https://warewolf.io/knowledge-base/wp-content/uploads/2017/01/How-to-build-Warewolf-from-a-source.png)]

### End

You have now successfully built Warewolf.

---------------------------
## How to Build Warewolf from Source Part 2 (Testing)
[![How to build warewolf from source Part 2](https://warewolf.io/knowledge-base/articles/how-do-i-build-warewolf-from-source/)]

This article outlines the more advanced concepts involved in building the Warewolf source files and running the tests.

### Run the Unit tests

* Having built Warewolf for the first time, it is advisable to run all the unit tests to ensure that you have a clean and stable copy of the code base. The Studio and Server unit test projects are located within the *Studio* and *Server* solutions respectively.

* In Visual Studio Menu Click on, Test >Windows >Test Explorer. This will bring up the test explorer. Click “Run All” to run all the unit tests. It is imperative that you run all the tests before starting any development

### Run the Specflow BDD Acceptance Tests

* Download and install the free version of Specflow 
* From Visual Studio open the Dev2.AcceptanceTesting.sln file from your local Git repository. The Specflow specs are defined in Dev2.Activities.Specs project
* Start the server as outlined in the getting started guide for building Warewolf article
* In Visual Studio Menu Click on, Test >Windows >Test Explorer. This will bring up the test explorer. In the test explorer filter box type Project:”Dev2.Activities.Specs” and press return
* Click “Run All” to run all the spec flow scenarios

### Run the Integration Tests

* From Visual Studio open the Integration Tests.sln file from the Dev folder of your local Git repository. The Integration tests are defined in the Dev2.Integration.Tests project
* Start the server as outlined in the getting started guide for building Warewolf article
* In Visual Studio Menu Click on, Test >Windows >Test Explorer. This will bring up the test explorer. In the test explorer filter box type Project:” Dev2.Integration.Tests” and press return
* Click “Run All” to run all the integration tests

---------------------------
## Sample Section with code and link

 [![Link Name](Link Url)]

```c#
public class MyWorkflow : IWorkflow
{
    public void Build(IWorkflowBuilder<MyData> builder)
    {    
        builder
           .StartWith<Task1>()
           .Then<Task2>()
           .Then<Task3>();
    }
}
```

---------------------------
## Orden de Compilacion

========== Warewolf 0 ==========

91>------ Operación Limpiar iniciada: proyecto: Warewolf.Resource, configuración: Debug Any CPU ------
90>------ Operación Limpiar iniciada: proyecto: Warewolf.Studio.Resources, configuración: Debug Any CPU ------
89>------ Operación Limpiar iniciada: proyecto: Warewolf.Interfaces, configuración: Debug Any CPU ------
86>------ Operación Limpiar iniciada: proyecto: Warewolf.Common, configuración: Debug Any CPU ------
87>------ Operación Limpiar iniciada: proyecto: Warewolf.Security, configuración: Debug Any CPU ------
82>------ Operación Limpiar iniciada: proyecto: Warewolf.Parser.Interop, configuración: Debug Any CPU ------
80>------ Operación Limpiar iniciada: proyecto: Warewolf.Language.Parser, configuración: Debug Any CPU ------
78>------ Operación Limpiar iniciada: proyecto: Warewolf.Storage.Interfaces, configuración: Debug Any CPU ------

========== Dev2 0 ==========

88>------ Operación Limpiar iniciada: proyecto: Dev2.Common.Interfaces, configuración: Debug Any CPU ------
85>------ Operación Limpiar iniciada: proyecto: Dev2.Common, configuración: Debug Any CPU ------
84>------ Operación Limpiar iniciada: proyecto: Dev2.Util, configuración: Debug Any CPU ------
83>------ Operación Limpiar iniciada: proyecto: Dev2.CustomControls, configuración: Debug Any CPU ------
81>------ Operación Limpiar iniciada: proyecto: Dev2.Runtime.Configuration, configuración: Debug Any CPU ------
79>------ Operación Limpiar iniciada: proyecto: Dev2.Diagnostics, configuración: Debug Any CPU ------
77>------ Operación Limpiar iniciada: proyecto: Dev2.Instrumentation, configuración: Debug Any CPU ------
76>------ Operación Limpiar iniciada: proyecto: Dev2.Data.Interfaces, configuración: Debug Any CPU ------
75>------ Operación Limpiar iniciada: proyecto: Dev2.Infrastructure, configuración: Debug Any CPU ------

========== Warewolf 1 ==========

74>------ Operación Limpiar iniciada: proyecto: Warewolf.Storage, configuración: Debug Any CPU ------
73>------ Operación Limpiar iniciada: proyecto: Warewolf.Sharepoint, configuración: Debug Any CPU ------
70>------ Operación Limpiar iniciada: proyecto: Warewolf.Driver.Serilog, configuración: Debug Any CPU ------
70>------ Operación Limpiar iniciada: proyecto: Warewolf.Driver.RabbitMQ, configuración: Debug Any CPU ------
68>------ Operación Limpiar iniciada: proyecto: Warewolf.Data, configuración: Debug Any CPU ------

========== Dev2 1 ==========

72>------ Operación Limpiar iniciada: proyecto: Dev2.Data, configuración: Debug Any CPU ------
71>------ Operación Limpiar iniciada: proyecto: Dev2.Core, configuración: Debug Any CPU ------
			Comentado Microsoft.Owin.Security Microsoft.Owin del appConfig

========== Warewolf 2 ========== (necesita Dev2.Core)

67>------ Operación Limpiar iniciada: proyecto: Warewolf.Auditing, configuración: Debug Any CPU ------ 
65>------ Operación Limpiar iniciada: proyecto: Warewolf.ResourceManagement, configuración: Debug Any CPU ------
64>------ Operación Limpiar iniciada: proyecto: Warewolf.ServiceDefinitions, configuración: Debug Any CPU ------

63>------ Operación Limpiar iniciada: proyecto: Warewolf.Core, configuración: Debug Any CPU ------
62>------ Operación Limpiar iniciada: proyecto: Warewolf.COMIPC.Client, configuración: Debug Any CPU ------
			Se podria compilar Warewolf.COMIPC
60>------ Operación Limpiar iniciada: proyecto: Warewolf.Logger, configuración: Debug Any CPU ------
54>------ Operación Limpiar iniciada: proyecto: Warewolf.Exchange.Email.Wrapper, configuración: Debug Any CPU ------


========== Dev2 2 ========== (porque son necesarios para Warewolf.Studio.Core)

69>------ Operación Limpiar iniciada: proyecto: Dev2.TaskScheduler.Wrappers, configuración: Debug Any CPU ------
66>------ Operación Limpiar iniciada: proyecto: Dev2.Scheduler, configuración: Debug Any CPU ------
			Comentado Microsoft.Owin.Security Microsoft.Owin del appConfig
			
61>------ Operación Limpiar iniciada: proyecto: Dev2.Services.Sql, configuración: Debug Any CPU ------
59>------ Operación Limpiar iniciada: proyecto: Dev2.SignalR.Wrappers.Interfaces, configuración: Debug Any CPU ------
52>------ Operación Limpiar iniciada: proyecto: Dev2.SignalR.Wrappers.New, configuración: Debug Any CPU ------
58>------ Operación Limpiar iniciada: proyecto: Dev2.Runtime.Services, configuración: Debug Any CPU ------
57>------ Operación Limpiar iniciada: proyecto: Dev2.Studio.Interfaces, configuración: Debug Any CPU ------
56>------ Operación Limpiar iniciada: proyecto: Dev2.Development.Languages, configuración: Debug Any CPU ------
55>------ Operación Limpiar iniciada: proyecto: Dev2.Services.Execution, configuración: Debug Any CPU ------
53>------ Operación Limpiar iniciada: proyecto: Dev2.Activities, configuración: Debug Any CPU ------


========== Warewolf 3 ========== (necesita Studio.Interfaces)

51>------ Operación Limpiar iniciada: proyecto: Warewolf.Studio.Core, configuración: Debug Any CPU ------

========== Dev2 3 ========== (porque son necesarios para ???)

50>------ Operación Limpiar iniciada: proyecto: Dev2.Studio.Core, configuración: Debug Any CPU ------

========== Warewolf 4 ========== (necesita Studio.Dev2.Studio.Core)

48>------ Operación Limpiar iniciada: proyecto: Warewolf.Studio.CustomControls, configuración: Debug Any CPU ------
47>------ Operación Limpiar iniciada: proyecto: Warewolf.Studio.Models, configuración: Debug Any CPU ------
46>------ Operación Limpiar iniciada: proyecto: Warewolf.Studio.Themes.Luna, configuración: Debug Any CPU ------
43>------ Operación Limpiar iniciada: proyecto: Warewolf.UI, configuración: Debug Any CPU ------
42>------ Operación Limpiar iniciada: proyecto: Warewolf.Studio.AntiCorruptionLayer, configuración: Debug Any CPU ------
41>------ Operación Limpiar iniciada: proyecto: Warewolf.Trigger.Queue, configuración: Debug Any CPU ------
40>------ Operación Limpiar iniciada: proyecto: Warewolf.Studio.ViewModels, configuración: Debug Any CPU ------
38>------ Operación Limpiar iniciada: proyecto: Warewolf.MergeParser, configuración: Debug Any CPU ------
36>------ Operación Limpiar iniciada: proyecto: Warewolf.Studio.Views, configuración: Debug Any CPU ------

========== Dev2 4 ========== (porque son necesarios para ???)

49>------ Operación Limpiar iniciada: proyecto: Dev2.Intellisense, configuración: Debug Any CPU ------
45>------ Operación Limpiar iniciada: proyecto: Dev2.Activities.Designers, configuración: Debug Any CPU ------
44>------ Operación Limpiar iniciada: proyecto: Dev2.Runtime, configuración: Debug Any CPU ------
39>------ Operación Limpiar iniciada: proyecto: Dev2.Runtime.WebServer, configuración: Debug Any CPU ------
37>------ Operación Limpiar iniciada: proyecto: Dev2.Server, configuración: Debug Any CPU ------

========== Warewolf 5 ==========


31>------ Operación Limpiar iniciada: proyecto: Warewolf.Testing, configuración: Debug Any CPU ------
27>------ Operación Limpiar iniciada: proyecto: Warewolf.TestingDotnetDllCascading, configuración: Debug Any CPU ------
24>------ Operación Limpiar iniciada: proyecto: Warewolf.COMIPC, configuración: Debug x86 ------
18>------ Operación Limpiar iniciada: proyecto: Warewolf.Common.Framework48, configuración: Debug Any CPU ------

========== Dev2 5 ==========

32>------ Operación Limpiar iniciada: proyecto: Dev2.Studio, configuración: Debug Any CPU ------
23>------ Operación Limpiar iniciada: proyecto: Dev2.UnitTestUtils, configuración: Debug Any CPU ------
20>------ Operación Limpiar iniciada: proyecto: Dev2.Runtime.Auditing, configuración: Debug Any CPU ------
19>------ Operación Limpiar iniciada: proyecto: Dev2.Sql, configuración: Debug Any CPU ------
17>------ Operación Limpiar iniciada: proyecto: Dev2.Debug, configuración: Debug Any CPU ------
14>------ Operación Limpiar iniciada: proyecto: Dev2.ScheduleExecutor, configuración: Debug Any CPU ------
10>------ Operación Limpiar iniciada: proyecto: Dev2.Web, configuración: Debug Any CPU ------

========== Warewolf 6 ==========

33>------ Operación Limpiar iniciada: proyecto: Warewolf.MergeParser.Tests, configuración: Debug Any CPU ------
13>------ Operación Limpiar iniciada: proyecto: Warewolf.ResourceManagement.Tests, configuración: Debug Any CPU ------
12>------ Operación Limpiar iniciada: proyecto: Warewolf.Tools.Specs, configuración: Debug Any CPU ------
06>------ Operación Limpiar iniciada: proyecto: Warewolf.Common.Tests, configuración: Debug Any CPU ------
05>------ Operación Limpiar iniciada: proyecto: Warewolf.Driver.SerilogTests, configuración: Debug Any CPU ------
04>------ Operación Limpiar iniciada: proyecto: Warewolf.Core.Tests, configuración: Debug Any CPU ------
03>------ Operación Limpiar iniciada: proyecto: Warewolf.Studio.ViewModels.Tests, configuración: Debug Any CPU ------
02>------ Operación Limpiar iniciada: proyecto: Warewolf.Common.Framework48.Tests, configuración: Debug Any CPU ------
01>------ Operación Limpiar iniciada: proyecto: Warewolf.Auditing.Tests, configuración: Debug Any CPU ------

========== Dev2 6 ==========

35>------ Operación Limpiar iniciada: proyecto: Dev2.Infrastructure.Tests, configuración: Debug Any CPU ------
34>------ Operación Limpiar iniciada: proyecto: Dev2.Diagnostics.Tests, configuración: Debug Any CPU ------
30>------ Operación Limpiar iniciada: proyecto: Dev2.Core.Tests, configuración: Debug Any CPU ------
28>------ Operación Limpiar iniciada: proyecto: Dev2.Studio.Core.Tests, configuración: Debug Any CPU ------
26>------ Operación Limpiar iniciada: proyecto: Dev2.Common.Tests, configuración: Debug Any CPU ------
25>------ Operación Limpiar iniciada: proyecto: Dev2.Activities.Tests, configuración: Debug Any CPU ------
22>------ Operación Limpiar iniciada: proyecto: Dev2.Activities.Designers.Tests, configuración: Debug Any CPU ------
21>------ Operación Limpiar iniciada: proyecto: Dev2.Runtime.Tests, configuración: Debug Any CPU ------
16>------ Operación Limpiar iniciada: proyecto: Dev2.Data.Tests, configuración: Debug Any CPU ------
15>------ Operación Limpiar iniciada: proyecto: Dev2.Runtime.Auditing.Tests, configuración: Debug Any CPU ------
11>------ Operación Limpiar iniciada: proyecto: Dev2.Sql.Tests, configuración: Debug Any CPU ------
09>------ Operación Limpiar iniciada: proyecto: Dev2.Instrumentation.Tests, configuración: Debug Any CPU ------
08>------ Operación Limpiar iniciada: proyecto: Dev2.Instrumentation.Specs, configuración: Debug Any CPU ------
07>------ Operación Limpiar iniciada: proyecto: Dev2.Scheduler.Tests, configuración: Debug Any CPU ------

29>------ Operación Limpiar iniciada: proyecto: ConsoleAppToTestExecuteCommandLineActivity, configuración: Debug Any CPU ------


========== Limpiar: 91 correctos, 0 incorrectos, 0 omitidos ==========