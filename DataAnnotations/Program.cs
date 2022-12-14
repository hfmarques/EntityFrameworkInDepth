// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using DataAnnotations;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>()
    .Build();

var connectionString = configuration.GetConnectionString("Pluto");

Console.WriteLine(connectionString);

using var context = new PlutoContext();

var authors = context.Authors.ToList();

Console.WriteLine(JsonSerializer.Serialize(authors));

Console.ReadLine();