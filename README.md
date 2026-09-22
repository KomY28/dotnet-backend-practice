# .NET Backend Practice

This is a learning log — I'm practicing backend development with C# and .NET 8 as a junior developer. Each session I focus on building real-world Web API concepts from scratch, moving away from course-following to independent project-based learning.

**Goal:** to confidently build modern, scalable .NET Web APIs at a junior level, mastering Entity Framework Core, database management, and backend architecture.

## Log

| Day | Project | What it covered |
|-----|---------|------------------|
| [Day 1](./day-01-gymlog-setup/GymLog.API) | GymLog API - Setup & DB | Setting up a Web API (.NET 8, Controllers), Domain Models (`Exercise`, `WorkoutLog`), 1-to-many relationships, Entity Framework Core setup, `DbContext` inheritance, `appsettings.json` connection strings, Dependency Injection in `Program.cs`, Dockerized MS SQL Server (on Apple Silicon), and Initial EF Core Migrations (`dotnet ef migrations add`, `dotnet ef database update`). |

## How I'm learning

At the end of each session, I write a short summary of the harder, newly learned concepts. Instead of just watching tutorials, I recreate the concepts in my own independent practice projects (like GymLog) to build muscle memory and truly understand the syntax and underlying architecture.

## Tech stack

- .NET 8 (ASP.NET Core Web API, Controllers)
- C#
- Entity Framework Core (EF Core 8)
- MS SQL Server (running in Docker)
- JetBrains Rider
- macOS (Apple Silicon environment)

## Running a daily project

Each day is its own standalone .NET project in its respective folder.

**Prerequisites:**
You need to have an MS SQL Server container running in Docker. Example command:
`docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YourPassword123" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest`

**Running the app:**
Go into that day's project folder (where the `.csproj` file is located), then:

```bash
dotnet restore
dotnet run