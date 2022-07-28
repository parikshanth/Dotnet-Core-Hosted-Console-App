# Dotnet-Core-Hosted-Console-App
a console app using Microsoft.Extensions.Hosting and Microsoft DI

A dotnet background worker console template, with adds the default Microsoft Dependency injector and logging support.

From observation, the regular dotnet console applications fail health checks and crash when within docker containers or PCF deployments, 

Using the Microsoft.Extensions.Hosting eliminates this issue and adds a lot of other capabilities like DI and logging and a structured way to add additional background workers as needed within the main application

The multistage docker file has been added in the project directory to help create the container as well

` docker build -t hostedconsoleapp:dev . `
