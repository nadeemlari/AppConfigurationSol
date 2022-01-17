using Azure.Core;
using Azure.Identity;

namespace AppConfigurationDemo;

public static class AzureCredentialBuilder
{
    public static TokenCredential Credential()
    {
        #if DEBUG
            return new AzureCliCredential();
        #else
            return new DefaultAzureCredential();
        #endif

    }
}