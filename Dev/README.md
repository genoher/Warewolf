# Warewolf

---------------------------
## How to Build Warewolf from Source Part 1 (Basics)
[![How to build warewolf from source Part 1](https://warewolf.io/knowledge-base/articles/how-to-build-warewolf-from-source/)]

This article outlines the steps involved to build Warewolf from source, 
as well as execute it. You�ll be creating and using microservices in no time!

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
Please also check the �Readme� section on the GitHub site for updates on dependencies or tools required.

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

* In Visual Studio Menu Click on, Test >Windows >Test Explorer. This will bring up the test explorer. Click �Run All� to run all the unit tests. It is imperative that you run all the tests before starting any development

### Run the Specflow BDD Acceptance Tests

* Download and install the free version of Specflow 
* From Visual Studio open the Dev2.AcceptanceTesting.sln file from your local Git repository. The Specflow specs are defined in Dev2.Activities.Specs project
* Start the server as outlined in the getting started guide for building Warewolf article
* In Visual Studio Menu Click on, Test >Windows >Test Explorer. This will bring up the test explorer. In the test explorer filter box type Project:�Dev2.Activities.Specs� and press return
* Click �Run All� to run all the spec flow scenarios

### Run the Integration Tests

* From Visual Studio open the Integration Tests.sln file from the Dev folder of your local Git repository. The Integration tests are defined in the Dev2.Integration.Tests project
* Start the server as outlined in the getting started guide for building Warewolf article
* In Visual Studio Menu Click on, Test >Windows >Test Explorer. This will bring up the test explorer. In the test explorer filter box type Project:� Dev2.Integration.Tests� and press return
* Click �Run All� to run all the integration tests

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

91>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Resource, configuraci�n: Debug Any CPU ------
90>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Studio.Resources, configuraci�n: Debug Any CPU ------
89>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Interfaces, configuraci�n: Debug Any CPU ------
86>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Common, configuraci�n: Debug Any CPU ------
87>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Security, configuraci�n: Debug Any CPU ------
82>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Parser.Interop, configuraci�n: Debug Any CPU ------
80>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Language.Parser, configuraci�n: Debug Any CPU ------
78>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Storage.Interfaces, configuraci�n: Debug Any CPU ------

========== Dev2 0 ==========

88>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Common.Interfaces, configuraci�n: Debug Any CPU ------
85>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Common, configuraci�n: Debug Any CPU ------
84>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Util, configuraci�n: Debug Any CPU ------
83>------ Operaci�n Limpiar iniciada: proyecto: Dev2.CustomControls, configuraci�n: Debug Any CPU ------
81>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Runtime.Configuration, configuraci�n: Debug Any CPU ------
79>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Diagnostics, configuraci�n: Debug Any CPU ------
77>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Instrumentation, configuraci�n: Debug Any CPU ------
76>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Data.Interfaces, configuraci�n: Debug Any CPU ------
75>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Infrastructure, configuraci�n: Debug Any CPU ------

========== Warewolf 1 ==========

74>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Storage, configuraci�n: Debug Any CPU ------
73>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Sharepoint, configuraci�n: Debug Any CPU ------
70>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Driver.Serilog, configuraci�n: Debug Any CPU ------
70>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Driver.RabbitMQ, configuraci�n: Debug Any CPU ------
68>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Data, configuraci�n: Debug Any CPU ------

========== Dev2 1 ==========

72>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Data, configuraci�n: Debug Any CPU ------
71>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Core, configuraci�n: Debug Any CPU ------
			Comentado Microsoft.Owin.Security Microsoft.Owin del appConfig

========== Warewolf 2 ========== (necesita Dev2.Core)

67>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Auditing, configuraci�n: Debug Any CPU ------ 
65>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.ResourceManagement, configuraci�n: Debug Any CPU ------
64>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.ServiceDefinitions, configuraci�n: Debug Any CPU ------

63>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Core, configuraci�n: Debug Any CPU ------
62>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.COMIPC.Client, configuraci�n: Debug Any CPU ------
			Se podria compilar Warewolf.COMIPC
60>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Logger, configuraci�n: Debug Any CPU ------
54>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Exchange.Email.Wrapper, configuraci�n: Debug Any CPU ------


========== Dev2 2 ========== (porque son necesarios para Warewolf.Studio.Core)

69>------ Operaci�n Limpiar iniciada: proyecto: Dev2.TaskScheduler.Wrappers, configuraci�n: Debug Any CPU ------
66>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Scheduler, configuraci�n: Debug Any CPU ------
			Comentado Microsoft.Owin.Security Microsoft.Owin del appConfig
			
61>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Services.Sql, configuraci�n: Debug Any CPU ------
59>------ Operaci�n Limpiar iniciada: proyecto: Dev2.SignalR.Wrappers.Interfaces, configuraci�n: Debug Any CPU ------
52>------ Operaci�n Limpiar iniciada: proyecto: Dev2.SignalR.Wrappers.New, configuraci�n: Debug Any CPU ------
58>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Runtime.Services, configuraci�n: Debug Any CPU ------
57>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Studio.Interfaces, configuraci�n: Debug Any CPU ------
56>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Development.Languages, configuraci�n: Debug Any CPU ------
55>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Services.Execution, configuraci�n: Debug Any CPU ------
53>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Activities, configuraci�n: Debug Any CPU ------


========== Warewolf 3 ========== (necesita Studio.Interfaces)

51>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Studio.Core, configuraci�n: Debug Any CPU ------

========== Dev2 3 ========== (porque son necesarios para ???)

50>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Studio.Core, configuraci�n: Debug Any CPU ------

========== Warewolf 4 ========== (necesita Studio.Dev2.Studio.Core)

48>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Studio.CustomControls, configuraci�n: Debug Any CPU ------
47>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Studio.Models, configuraci�n: Debug Any CPU ------
46>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Studio.Themes.Luna, configuraci�n: Debug Any CPU ------
43>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.UI, configuraci�n: Debug Any CPU ------
42>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Studio.AntiCorruptionLayer, configuraci�n: Debug Any CPU ------
41>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Trigger.Queue, configuraci�n: Debug Any CPU ------
40>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Studio.ViewModels, configuraci�n: Debug Any CPU ------
38>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.MergeParser, configuraci�n: Debug Any CPU ------
36>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Studio.Views, configuraci�n: Debug Any CPU ------

========== Dev2 4 ========== (porque son necesarios para ???)

49>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Intellisense, configuraci�n: Debug Any CPU ------
45>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Activities.Designers, configuraci�n: Debug Any CPU ------
44>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Runtime, configuraci�n: Debug Any CPU ------
39>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Runtime.WebServer, configuraci�n: Debug Any CPU ------
37>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Server, configuraci�n: Debug Any CPU ------

========== Warewolf 5 ==========


31>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Testing, configuraci�n: Debug Any CPU ------
27>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.TestingDotnetDllCascading, configuraci�n: Debug Any CPU ------
24>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.COMIPC, configuraci�n: Debug x86 ------
18>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Common.Framework48, configuraci�n: Debug Any CPU ------

========== Dev2 5 ==========

32>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Studio, configuraci�n: Debug Any CPU ------
23>------ Operaci�n Limpiar iniciada: proyecto: Dev2.UnitTestUtils, configuraci�n: Debug Any CPU ------
20>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Runtime.Auditing, configuraci�n: Debug Any CPU ------
19>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Sql, configuraci�n: Debug Any CPU ------
17>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Debug, configuraci�n: Debug Any CPU ------
14>------ Operaci�n Limpiar iniciada: proyecto: Dev2.ScheduleExecutor, configuraci�n: Debug Any CPU ------
10>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Web, configuraci�n: Debug Any CPU ------

========== Warewolf 6 ==========

33>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.MergeParser.Tests, configuraci�n: Debug Any CPU ------
13>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.ResourceManagement.Tests, configuraci�n: Debug Any CPU ------
12>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Tools.Specs, configuraci�n: Debug Any CPU ------
06>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Common.Tests, configuraci�n: Debug Any CPU ------
05>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Driver.SerilogTests, configuraci�n: Debug Any CPU ------
04>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Core.Tests, configuraci�n: Debug Any CPU ------
03>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Studio.ViewModels.Tests, configuraci�n: Debug Any CPU ------
02>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Common.Framework48.Tests, configuraci�n: Debug Any CPU ------
01>------ Operaci�n Limpiar iniciada: proyecto: Warewolf.Auditing.Tests, configuraci�n: Debug Any CPU ------

========== Dev2 6 ==========

35>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Infrastructure.Tests, configuraci�n: Debug Any CPU ------
34>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Diagnostics.Tests, configuraci�n: Debug Any CPU ------
30>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Core.Tests, configuraci�n: Debug Any CPU ------
28>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Studio.Core.Tests, configuraci�n: Debug Any CPU ------
26>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Common.Tests, configuraci�n: Debug Any CPU ------
25>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Activities.Tests, configuraci�n: Debug Any CPU ------
22>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Activities.Designers.Tests, configuraci�n: Debug Any CPU ------
21>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Runtime.Tests, configuraci�n: Debug Any CPU ------
16>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Data.Tests, configuraci�n: Debug Any CPU ------
15>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Runtime.Auditing.Tests, configuraci�n: Debug Any CPU ------
11>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Sql.Tests, configuraci�n: Debug Any CPU ------
09>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Instrumentation.Tests, configuraci�n: Debug Any CPU ------
08>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Instrumentation.Specs, configuraci�n: Debug Any CPU ------
07>------ Operaci�n Limpiar iniciada: proyecto: Dev2.Scheduler.Tests, configuraci�n: Debug Any CPU ------

29>------ Operaci�n Limpiar iniciada: proyecto: ConsoleAppToTestExecuteCommandLineActivity, configuraci�n: Debug Any CPU ------


========== Limpiar: 91 correctos, 0 incorrectos, 0 omitidos ==========