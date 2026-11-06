using System;
using System.IO;
using DbUp;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TestTemplateAI1.Migrations;

public class Program
{
    public static int Main(string[] args)
    {
        var connectionString = string.Empty;
        var dbUser = string.Empty;
        var dbPassword = string.Empty;
        var scriptsPath = string.Empty;
        var sqlUsersGroupName = string.Empty;

        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
            ?? "Production";
        Console.WriteLine($"Environment: {env}.");
        var builder = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json", true, true)
            .AddJsonFile($"appsettings.{env}.json", true, true)
            .AddEnvironmentVariables();

        var config = builder.Build();
        InitializeParameters();
        var connectionStringBuilderTestTemplateAI1 = new SqlConnectionStringBuilder(connectionString);
        if (env.Equals("Development"))
        {
            connectionStringBuilderTestTemplateAI1.UserID = dbUser;
            connectionStringBuilderTestTemplateAI1.Password = dbPassword;
        }
        else
        {
            connectionStringBuilderTestTemplateAI1.UserID = dbUser;
            connectionStringBuilderTestTemplateAI1.Password = dbPassword;
            connectionStringBuilderTestTemplateAI1.Authentication = SqlAuthenticationMethod.ActiveDirectoryPassword;
        }
        var upgraderTestTemplateAI1 =
            DeployChanges.To
                .SqlDatabase(connectionStringBuilderTestTemplateAI1.ConnectionString)
                .WithVariable("SqlUsersGroupNameVariable", sqlUsersGroupName)    // This is necessary to perform template variable replacement in the scripts.
                .WithScriptsFromFileSystem(
                    !string.IsNullOrWhiteSpace(scriptsPath)
                            ? Path.Combine(scriptsPath, "TestTemplateAI1Scripts")
                        : Path.Combine(Environment.CurrentDirectory, "TestTemplateAI1Scripts"))
                .LogToConsole()
                .Build();
        Console.WriteLine($"Now upgrading TestTemplateAI1.");
        if (env == "Development")
        {
            upgraderTestTemplateAI1.MarkAsExecuted("0000_AzureSqlContainedUser.sql");
        }
        var resultTestTemplateAI1 = upgraderTestTemplateAI1.PerformUpgrade();

        if (!resultTestTemplateAI1.Successful)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"TestTemplateAI1 upgrade error: {resultTestTemplateAI1.Error}");
            Console.ResetColor();
            return -1;
        }

        // Uncomment the below sections if you also have an Identity Server project in the solution.
        /*
        var connectionStringTestTemplateAI1Identity = string.IsNullOrWhiteSpace(args.FirstOrDefault())
            ? config["ConnectionStrings:TestTemplateAI1IdentityDb"]
            : args.FirstOrDefault();

        var upgraderTestTemplateAI1Identity =
            DeployChanges.To
                .SqlDatabase(connectionStringTestTemplateAI1Identity)
                .WithScriptsFromFileSystem(
                    scriptsPath != null
                        ? Path.Combine(scriptsPath, "TestTemplateAI1IdentityScripts")
                        : Path.Combine(Environment.CurrentDirectory, "TestTemplateAI1IdentityScripts"))
                .LogToConsole()
                .Build();
        Console.WriteLine($"Now upgrading TestTemplateAI1 Identity.");
        if (env != "Development")
        {
            upgraderTestTemplateAI1Identity.MarkAsExecuted("0004_InitialData.sql");
            Console.WriteLine($"Skipping 0004_InitialData.sql since we are not in Development environment.");
            upgraderTestTemplateAI1Identity.MarkAsExecuted("0005_Initial_Configuration_Data.sql");
            Console.WriteLine($"Skipping 0005_Initial_Configuration_Data.sql since we are not in Development environment.");
        }
        var resultTestTemplateAI1Identity = upgraderTestTemplateAI1Identity.PerformUpgrade();

        if (!resultTestTemplateAI1Identity.Successful)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"TestTemplateAI1 Identity upgrade error: {resultTestTemplateAI1Identity.Error}");
            Console.ResetColor();
            return -1;
        }
        */

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Success!");
        Console.ResetColor();
        return 0;

        void InitializeParameters()
        {
            // Local database, populated from .env file.
            if (args.Length == 0)
            {
                connectionString = config["TestTemplateAI1Db_Migrations_Connection"];
                dbUser = config["DbUser"];
                dbPassword = config["DbPassword"];
            }

            // Deployed database
            else if (args.Length == 5)
            {
                connectionString = args[0];
                dbUser = args[1];
                dbPassword = args[2];
                scriptsPath = args[3];
                sqlUsersGroupName = args[4];
            }
        }
    }
}
