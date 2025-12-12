using System;
using System.Deployment.Application;
using System.Reflection;

public static class VersionHelper
{
    public static Version GetCurrentVersion()
    {
        // 1) wersja z "Opublikuj" (ClickOnce) – działa PO instalacji
        if (ApplicationDeployment.IsNetworkDeployed)
        {
            return ApplicationDeployment.CurrentDeployment.CurrentVersion;
        }

        // 2) w czasie debugowania z VS (bin\Debug / bin\Release)
        //    ClickOnce nie jest używany, więc bierzemy wersję assembly
        return Assembly.GetExecutingAssembly().GetName().Version;
    }
}
