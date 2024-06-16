using System.ComponentModel;
using System.Globalization;
using EverythingCli.API;
using EverythingSearchClient;
using Humanizer;
using Spectre.Console;
using Spectre.Console.Cli;

namespace EverythingCli.Commands;

public class SearchCommand : Command<SearchCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [Description("Search query to send to Everything"), CommandArgument(0, "[Query]")]
        public string Query { get; init; } = "";
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        try
        {
            var result = EverythingApi.Search(settings.Query);

            OutputResult(result);
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex);
            return -1;
        }

        return 0;
    }

    private static void OutputResult(ResultSet result)
    {
        var table = new Table();
        table.AddColumn("Name");
        table.AddColumn("Path");
        table.AddColumn("Size");
        table.AddColumn("Date modified");

        foreach (var item in result)
            table.AddRow(
                item.Name,
                item.Path,
                $"{item.Bytes.Bytes().Kilobytes} kB",
                item.DateModified.ToLongDateString());

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine($"Query: [Yellow]{result.Query}[/]. Found [green]{result.Count}[/] item(s).");
    }
}