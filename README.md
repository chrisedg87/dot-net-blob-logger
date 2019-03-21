# dot-net-blob-logger
C# Library for writting logs to Azure Blob Storage

## Getting Started
1. Add the library to your project
2. Register services in your `Startup.cs` -
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

    // Initialise the logging module
    var logger = new Logger.ServiceConfiguration();
    logger.InitializeContainer(services, Configuration);
}
```
3. Add Azure Blob credenitials to your `appsettings.json` or similar -
```json
{
  "Azure.StorageAccount": "<azure-account-name>",
  "Azure.StorageKey": "<azure-storage-key>",
  "Azure.Audit.TableName": "<azure-audit-table-name>",
  "Azure.Logging.TableName": "<azure-logging-table-name>",
}
```
4. Start logging in your controllers -

```csharp
[Route("api/[controller]")]
[ApiController]
public class MyController : ControllerBase
{
    private IApplicationLogger _applicationLogger;

    public MyController(IApplicationLogger applicationLogger)
    {
        _applicationLogger = applicationLogger;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
        _applicationLogger.Debug("Debug message - everything is fine");
        _applicationLogger.Debug("Info message - nothing to worry about");
        _applicationLogger.Warning("Warning message - Something you should look at here");
        _applicationLogger.Error("Error message - This looks bad");
        return new string[] { "value1", "value2" };
    }
}
```

## License
Dot Net Blob Logger is released under the MIT license. See LICENSE for details.
