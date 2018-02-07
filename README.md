# Event Grid Dynamic Tags
## Sample Azure Function app to show processing events from Event Grid
## Quick Start

<a target="_blank" href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fbretthackermsft%2Fevent-grid-dynamic-tags%2Fmaster%2Fazuredeploy.json"><img src="http://azuredeploy.net/deploybutton.png"/></a>

__Details__
* Listens for web hook calls from an Event Grid
* Subscription-level Event Grid listeners aren't deployed into a Resource Group. Therefore, deployment of the Event Grid can't be automated from this template. After the template deploys successfully, retrieve the URL of the resulting Function app, and run the following code to create your Event Grid Subscription:
```powershell
#Login-AzureRmAccount

$functionAppName = "[YOUR APP NAME]"
$functionAppApiKey = "[FUNCTION API KEY]"
$eventGridSubName = "[EVENT GRID SUBSCRIPTION NAME]"

$functionAppUrl = "https://$functionAppName.azurewebsites.net/api/TagManager?code=$functionAppApiKey"
$includedEventTypes = "Microsoft.Resources.ResourceWriteSuccess"

New-AzureRmEventGridSubscription `
    -Endpoint $functionAppUrl `
    -EventSubscriptionName $eventGridSubName `
    -EndpointType webhook `
    -IncludedEventType $includedEventTypes

```

Retrieve the Function app name and API key from within the portal after deploying the template:  ![alt text][App1]

* ARM template deploys the following:
  * Azure Function App
  * Azure Storage account
* Requires the following:
  1. Azure Event Grid Subscription (deploy via PSH script, sample above)

## As-Is Code

This code is made available as a sample to demonstrate processing Azure administration events as part of a larger compliance strategy. It should not be utilized directly in production without review and enhancement by your dev team or a partner.

[App1]: ./Images/FunctionSettings.jpg "Function Settings"