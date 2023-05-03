using System.Net;
using System.Runtime.InteropServices;

namespace DockerDemo.Shared;
public static class AppInfoHelper
{
    public static Dictionary<string, object> GetAppInfoDictionary()
    {
        return new Dictionary<string, object>
        {
            { "HostName", Dns.GetHostName() },
            { "Env", Environment.GetEnvironmentVariables() },
            { "RuntimeIdentifier", RuntimeInformation.RuntimeIdentifier },
            { "OSArchitecture", RuntimeInformation.OSArchitecture.ToString() },
            { "OSDescription", RuntimeInformation.OSDescription }
        };
    }
}
