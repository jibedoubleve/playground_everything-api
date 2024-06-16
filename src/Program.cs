using EverythingCli.Commands;
using Spectre.Console.Cli;

var app = new CommandApp<SearchCommand>();
return app.Run(args);