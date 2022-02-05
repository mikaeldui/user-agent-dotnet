using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;

namespace System.Net
{
    public partial class UserAgent
    {
        public static UserAgent From(Assembly assembly)
        {
            var assemblyName = assembly.GetName();
            UserAgent userAgent = new(assemblyName.Name);

            if (Debugger.IsAttached)
                userAgent.Version = "Debug";
            else
                try
                {
                    userAgent.Version = assembly.GetInformationalVersion() ?? assembly.GetProductVersion();
                }
                catch { }

            if (assembly == Assembly.GetEntryAssembly())
            {
                userAgent.Comments.Add(RuntimeInformation.OSDescription);
                userAgent.Comments.Add(RuntimeInformation.OSArchitecture.ToString());
                userAgent.Comments.Add(RuntimeInformation.FrameworkDescription);
            }

            userAgent.Comments.Add(assemblyName.ProcessorArchitecture.ToString());

            var frameworkVersion = assembly.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
            if (frameworkVersion != null)
                userAgent.Comments.Add(frameworkVersion.Replace(",Version=", " "));

            {
                var repoUrl = assembly.GetCustomAttributes<AssemblyMetadataAttribute>()?.FirstOrDefault(a => a.Key == "RepositoryUrl")?.Value;

                if (repoUrl != null)
                    userAgent.Comments.Add("+" + repoUrl);
            }

            return userAgent;
        }
    }
}
