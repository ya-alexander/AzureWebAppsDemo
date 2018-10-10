# Azure Web Apps
## What are Azure Web Apps
* Web apps are a part of [Azure App Service](https://azure.microsoft.com/en-us/services/app-service/) (Web apps, Web app for containers, Mobile Apps, API Apps)
* Basically, various options to host a web app, web apps being one of them ([comparison](https://docs.microsoft.com/en-us/azure/app-service/choose-web-site-cloud-service-vm))
* Microsoft's PaaS solution to run web applications, REST APIs and mobile backends
* Mostly Windows-based hosting environment, but [Linux-based](https://docs.microsoft.com/en-us/azure/app-service/app-service-web-overview) also available

Microsoft provides additional services for:

* Built-in load balancing and traffic manager
* [Scaling](https://docs.microsoft.com/en-us/azure/app-service/web-sites-scale):
  * Scale up: Add additional resources or services to single node
  * Scale out: Increase number of nodes your app runs on
  * manually or [automatically](https://docs.microsoft.com/en-us/azure/monitoring-and-diagnostics/monitoring-autoscale-get-started)
* Run web apps in data centers all over the world
* SLAs: guaranteed availability of [99.95%](https://azure.microsoft.com/en-us/support/legal/sla/app-service/v1_4/) in selected tiers
* Custom domains
* Security: 
  * [Managed Identites for Azure resources](https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/overview)
  * [Integration with AAD and other authentication providers](https://docs.microsoft.com/en-us/azure/app-service/app-service-authentication-overview)
  * SSL
* Connect to On-Prem via [Hybrid Connections](https://docs.microsoft.com/en-us/azure/biztalk-services/integration-hybrid-connection-overview) or [Azure Virtual Networks](https://docs.microsoft.com/en-us/azure/app-service/web-sites-integrate-with-vnet)
* DevOps capabilities:
  * Deployment from Azure DevOps, GitHub, Docker Hub
  * Staging environments (Deployment slots)
  * Manageable using [PowerShell](https://docs.microsoft.com/en-us/powershell/azure/overview?view=azurermps-6.9.0), [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest)
  * Deployment Center

* Pricing: See app service plan [pricing](https://docs.microsoft.com/en-us/azure/app-service/azure-web-sites-web-hosting-plans-in-depth-overview#how-much-does-my-app-service-plan-cost)

## Web Jobs

* For implementing background processing code
* Runs in the context of a web app
* Allows to run scripts or compiled code
  * .cmd, .bat, .exe (using Windows cmd)
  * .ps1 (using PowerShell)
  * .sh (using Bash)
  * .php (using PHP)
  * .py (using Python)
  * .js (using Node.js)
  * .jar (using Java)
* Either triggered (manually/scheduled) or continuous (endless loop, e.g. listen for new message in message queue)
* Various [bindings/triggers](https://github.com/Azure/azure-webjobs-sdk/wiki)
  * Bindings enable access to e.g. Azure Storage Blobs, Queues, Tables, Service Bus
  * Triggers allow ro reacto on e.g. WebHooks, SendGrid, Timer/Cron, Files, Service Bus Message
  * Configurable via .NET attributes

* Use Web Jobs if you need more control over listeners

### Links
* https://docs.microsoft.com/en-us/azure/app-service/web-sites-create-web-jobs
* https://github.com/Azure/azure-webjobs-sdk/wiki
* https://docs.microsoft.com/en-us/azure/azure-functions/functions-compare-logic-apps-ms-flow-webjobs#compare-functions-and-webjobs

## Azure Functions

* Also for implementing background processing code, but with richer experience (now)
* [Version 2](https://azure.microsoft.com/en-us/blog/introducing-azure-functions-2-0/) released just now
  * Mac/Linux (.NET Standard/.NET Core 2.1)
  * Run from a [package file](https://docs.microsoft.com/en-us/azure/azure-functions/run-functions-from-deployment-package) (run from zip)
* Most of the time the better choice now because:
  * more languages supported
  * pay-per-use pricing ([consumption plans](https://docs.microsoft.com/en-us/azure/azure-functions/functions-scale#how-the-consumption-plan-works))
  * serverless and [automatic scaling] with scale controller(https://docs.microsoft.com/en-us/azure/azure-functions/functions-scale#how-the-consumption-plan-works)
  
  ![Scale Controller](https://docs.microsoft.com/en-us/azure/azure-functions/media/functions-scale/central-listener.png "Scale Controller")
  
* Triggers:
  * Timer
  * Azure Storage queues and blobs
  * Azure Service Bus queues and topics
  * Azure Cosmos DB
  * Azure Event Hubs
  * HTTP/WebHook (GitHub, Slack)
  * Azure Event Grid

* [Bindings](https://docs.microsoft.com/en-us/azure/azure-functions/functions-versions): 
  * Service Bus
  * Sendgrid
  * Table Storage
  * Twilio
  * ...

* Also dedicated app service plan possible
### Advanced topics
* [Durable functions](https://docs.microsoft.com/en-us/azure/azure-functions/durable-functions-overview)
  * Simplifying complex, stateful coordination problems in serverless applications (function chaining, fan-out/in, async apis)
  * manage state (output can be persisted to variables) and restartes
  * stateful workflows with [orchestrator functions](https://docs.microsoft.com/en-us/azure/azure-functions/durable-functions-types-features-overview#orchestrator-functions) that coordinate [activity functions](https://docs.microsoft.com/en-us/azure/azure-functions/durable-functions-types-features-overview#orchestrator-functions) who do the actual work
* Azure function proxy
* [Pricing consumption plan](https://azure.microsoft.com/en-us/pricing/details/functions/)
* ```TODO: What exactly is a function host```

### Links
* https://docs.microsoft.com/en-us/azure/azure-functions/
* https://docs.microsoft.com/en-us/azure/azure-functions/functions-compare-logic-apps-ms-flow-webjobs#compare-functions-and-webjobs
https://docs.microsoft.com/en-us/azure/azure-functions/durable-functions-overview

## What is behind Azure Web Apps

* Cloud first by design, but also available on premise
* SQL base configuration
* Dynamic provisioning of sites on demand
* Network based storage (Azure xDrive)
* Intelligent load balancing
* TODO: find more info

## App Service Plans
* App services are hosted in [app service plans](https://docs.microsoft.com/en-us/azure/app-service/azure-web-sites-web-hosting-plans-in-depth-overview)
* Basically a [server farm](https://en.wikipedia.org/wiki/Server_farm) in conventional web app hosting
* Available in different regions and pricing tiers
* Pricing tiers
  * Shared compute (single VM shared by web apps and customers, CPU quotas)
    * Free 
    * Shared
  * Dedicated compute (single VM shared by your web apps in plan)
    * Basic
    * Standard
    * Premium
    * PremiumV2
  * Isolated
  * Consumption
* All except free tier billed per hour compute resources
* ATTENTION: An app service plan incurs charges as long as it is not deleted. Although a web app might be stopped charges still occur

* Scale out via switching to higher pricing tier 
  * more resoruce + more features
  * E.g. custom domains and SSL certificates, autoscaling, deployment slots, backups, Traffic Manager integration...

### Links
* Overview: https://docs.microsoft.com/en-us/azure/app-service/azure-web-sites-web-hosting-plans-in-depth-overview
* Running and Scaling: https://docs.microsoft.com/en-us/azure/app-service/azure-web-sites-web-hosting-plans-in-depth-overview#how-much-does-my-app-service-plan-cost
* Pricing: https://docs.microsoft.com/en-us/azure/app-service/azure-web-sites-web-hosting-plans-in-depth-overview#how-much-does-my-app-service-plan-cost



## Links

* https://azure.microsoft.com/en-us/status/
* https://docs.microsoft.com/en-us/azure/app-service/app-service-web-overview
* https://docs.microsoft.com/en-us/azure/app-service/containers/app-service-linux-intro
* https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-overview
* https://docs.microsoft.com/en-us/azure/app-service/choose-web-site-cloud-service-vm