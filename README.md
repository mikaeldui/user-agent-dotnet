# NuGet Package Template Repository
A template repository for NuGet packages.

Add this to the repo description when creating it:

    ProjectName: MyAwesomeProject.Api,
    Prefix: Meeee,
    Namespace: MyAwesomeProject,
    Description: This project is really awesome!,
    Tags: Awesomeness; Project; 1000,
    Package: Optional.Package.ToReference

Prefix is merged with ProjectName where needed, like for the package name.

`NUGET_ORG_API_KEY` needs to be added as a secret for the `nuget.org` environment.

Contains:

    root/
    ├─ .github/
    │  ├─ workflows/
    │  │  ├─ codeql-analysis.yml
    │  │  ├─ dotnet.yml
    │  ├─ dependabot.yml
    ├─ ProjectName/
    │  ├─ ProjectName.csproj
    │  ├─ Class1.cs
    ├─ ProjectName.Tests/
    │  ├─ ProjectName.Tests.csproj
    │  ├─ TestClass1.cs
    ├─ .gitignore
    ├─ LICENSE    
    ├─ ProjectName.sln
    ├─ ProjectName.png
    ├─ README.md
    ├─ SECURITY.md
    
## Thanks

Thanks to [Liam Gulliver](https://github.com/lgulliver) for his great [tutorial](https://lgulliver.github.io/dynamically-generate-projects-with-github-templates-and-actions/).

<!--
# DotNet.Net.UserAgent
[![.NET](https://github.com/mikaeldui/user-agent-dotnet/actions/workflows/dotnet.yml/badge.svg)](https://github.com/mikaeldui/user-agent-dotnet/actions/workflows/dotnet.yml)
[![CodeQL Analysis](https://github.com/mikaeldui/user-agent-dotnet/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/mikaeldui/user-agent-dotnet/actions/workflows/codeql-analysis.yml)

This NuGet package is really awesome!

You can install it using the following **.NET CLI** command:

    dotnet add package MikaelDui.DotNet.Net.UserAgent --version *
-->
