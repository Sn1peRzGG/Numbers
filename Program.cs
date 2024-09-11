using Spectre.Console;
using System;
using System.Collections.Generic;

class Program
{
    static List<int> randomNumbers = new List<int>();

    static void Main()
    {
        GenerateRandomNumbers();

        AnsiConsole.MarkupLine("[yellow]Generated Numbers:[/]");
        AnsiConsole.MarkupLine(string.Join(", ", randomNumbers));

        int minRange = AnsiConsole.Ask<int>("Enter the minimum value of range:");
        int maxRange = AnsiConsole.Ask<int>("Enter the maximum value of range:");
        int sequenceLength = AnsiConsole.Ask<int>("Enter the length of sequences:");

        Dictionary<int, int> validSequences = new Dictionary<int, int>();

        for (int i = 0; i <= randomNumbers.Count - sequenceLength; i++)
        {
            int sum = 0;
            for (int j = 0; j < sequenceLength; j++)
            {
                sum += randomNumbers[i + j];
            }

            if (sum >= minRange && sum <= maxRange)
            {
                validSequences[i] = sum;
            }
        }

        if (validSequences.Count > 0)
        {
            AnsiConsole.MarkupLine("\n[green]Valid sequences:[/]");
            foreach (var sequence in validSequences)
            {
                AnsiConsole.MarkupLine($"[yellow]Index: {sequence.Key}, Sum: {sequence.Value}[/]");
            }
        }
        else
        {
            AnsiConsole.MarkupLine("[red]No valid sequences found.[/]");
        }
    }

    static void GenerateRandomNumbers()
    {
        Random rand = new Random();
        for (int i = 0; i < 100; i++)
        {
            randomNumbers.Add(rand.Next(100, 901));
        }
    }
}
