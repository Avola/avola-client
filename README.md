# avola-client
Example .net client for synchronizing and executing Avola decision services. Use this if you want to connect your own .Net application with the Avola platform.
To run this sammple, you need a valid [Avola](http://www.avo.la) account! In Avola, you also need a versioned decision.

## Getting Started
This project was created with [Visual Studio 2017](https://www.visualstudio.com/vs/whatsnew/). Any edition, including community, should work fine. Clone the source, and open the solution.

Edit the values appSettings section of the App.config file with your own values. You can find the values in the Avola platform, or you can get them from support.
```xml
<appSettings>
  <add key="authentication.url" value="https://login.avo.la/connect/token" />
  <add key="authentication.clientid" value="your-clientid-here" />
  <add key="authentication.secret" value="your-secret-here" />
  <add key="authentication.thumbprint" value="cert-thumbprint-here" />
  <add key="authentication.scope" value="avola-api-client" />
  <add key="authentication.validateallservercertificates" value="true" />
  <add key="environment.name" value="test" />
  <add key="environment.organisation" value="yourorganisationname" />
</appSettings>
```

Then, Run the application, it is a console client and should just display help.
```
Avola.Demo 1.0.0.0
Copyright ©  2016
  settings    Get the settings for the organisation.
  list        Show a list of executable decisions.
  execute     Execute a specific decision service.
  help        Display more information on a specific command.
  version     Display version information.
Press enter to quit...
```

The verbs _settings_ and _list_ have been implemented
### settings
This will show you some basic information about the app environment. It will display a short piece of json in the console.

### list
This verb will show the names of the avalable decision services in the console. You can inspect the object in the souce code. The object contains more than just a name. It describes the decision service and what it needs to be executed.

### execute
Not implemented, but you can create a request yourself, based on your own decision services and it will execute correct. 

For more information, feel free to contact Avola Support!

## Future
the api client will be extend with functionalities to search and retrieve past executions on the platform.
