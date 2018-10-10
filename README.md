* In the `General` folder you will find a small collection of facts about Web Apps and Azure Dev Ops
* In the `Tutorial` folder you will find a step-by-step description of how the example project `BesiGourmet` was set up and implemented.
* In the `BesiGourmet` folder you will find the source code for the BesiGourmet application
  * The `ARM` folder contains an ARM template that represents the Azure infrastructure the BesiGourmet application requires to run
  * The folder `BesiGourmet` contains the WebAPI for the application
  * The folder `BesiGourmet.Test` contains a example test project for the WebAPI
  * The folder `Reminder` contains an Azure function that consumes the WebAPI
* `azure-pipelines.yaml` contains the build definition for the BesiGourmet WebAPI