using Microsoft.Extensions.Hosting;

var host = new HostBuilder();

host.ConfigureFunctionsWorkerDefaults();

await host.Build().RunAsync();
