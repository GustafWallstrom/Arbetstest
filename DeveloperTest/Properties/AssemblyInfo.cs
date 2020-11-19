using Core.Plugin;
using Core.Controls;

[assembly: PluginHolder]
[assembly: WebServiceUrl("/api/logservice", typeof(DeveloperTest.LogService))]