# Mikael Dúi's User-Agent class for .NET
[![.NET](https://github.com/mikaeldui/user-agent-dotnet/actions/workflows/dotnet.yml/badge.svg)](https://github.com/mikaeldui/user-agent-dotnet/actions/workflows/dotnet.yml)
[![CodeQL Analysis](https://github.com/mikaeldui/user-agent-dotnet/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/mikaeldui/user-agent-dotnet/actions/workflows/codeql-analysis.yml)

Adds a `UserAgent` class to `System.Net` that can be used with `HttpClient` and `ClientWebSocket` and whatever you want.

It can easily create a User-Agent from an assembly and includes the assembly version and repository URL among other things.

You can install it using the following **.NET CLI** command:

    dotnet add package MikaelDui.Net.UserAgent --version *

