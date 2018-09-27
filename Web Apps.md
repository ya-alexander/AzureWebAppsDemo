# Azure Web Apps
## What are Azure Web Apps
* Microsoft's PaaS solution to run web applications, REST APIs and mobile backends
* Mostly Windows-based hosting environment, but [Linux-based](https://docs.microsoft.com/en-us/azure/app-service/app-service-web-overview) also available

Microsoft provides additional services for:

* [Scaling](https://docs.microsoft.com/en-us/azure/app-service/web-sites-scale): Scale up and Scale out (manually/[automatically](https://docs.microsoft.com/en-us/azure/monitoring-and-diagnostics/monitoring-autoscale-get-started))
  * Scale up: Add additional resources or services to single node
  * Scale out: Increase number of nodes your app runs on
* Run web apps in data centers all over the world 
* Custom domains
* Security: 
  * [Managed Identites for Azure resources](https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/overview)
  * [Integration with AAD and other authentication providers](https://docs.microsoft.com/en-us/azure/app-service/app-service-authentication-overview)
  * SSL
* DevOps capabilities:
  * Deployment from Azure DevOps, GitHub, Docker Hub
  * Staging environments (Deployment slots)
  * Manageable using [PowerShell](https://docs.microsoft.com/en-us/powershell/azure/overview?view=azurermps-6.9.0), [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest)

## What is behind Azure Web Apps

## App Service Plans

## Pricing

## Links

* https://docs.microsoft.com/en-us/azure/app-service/app-service-web-overview
* https://docs.microsoft.com/en-us/azure/app-service/containers/app-service-linux-intro