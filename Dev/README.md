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

