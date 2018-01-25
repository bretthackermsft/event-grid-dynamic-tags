# Event Grid Dynamic Tags
## Sample Azure Function app to show processing events from Event Grid
## Quick Start

<a target="_blank" href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fbretthackermsft%2Fdynamic-tags%2Fmaster%2Fazuredeploy.json"><img src="http://azuredeploy.net/deploybutton.png"/></a>

__Details__
* Listens for web hook calls from an Event Grid
* Subscription-level Event Grid listeners aren't deployed into a Resource Group. Therefore, deployment of the Event Grid can't be automated from this template. After the template deploys successfully, retrieve the URL of the resulting Function app, and run the following code to create your Event Grid Subscription:
```powershell
#Login-AzureRmAccount

$functionAppUrl = "https://[YOUR APP FQDN]/api/TagManager"
$eventGridSubName = "MyEventGrid1"
$includedEventTypes = "Microsoft.Resources.ResourceWriteSuccess"

New-AzureRmEventGridSubscription -Endpoint $functionAppUrl -EventSubscriptionName $eventGridSubName -EndpointType webhook -IncludedEventType $includedEventTypes

```
* ARM template deploys the following:
  * Azure Function App
  * Azure Storage account
* Requires the following (see step-by-step deployment instructions above for details):
  1. Azure Event Grid Subscription

## As-Is Code

This code is made available as a sample to demonstrate processing Azure administration events as part of a larger compliance strategy. It should not be utilized directly in production without review and enhancement by your dev team or a partner.

