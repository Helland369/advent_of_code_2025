using System.Text.RegularExpressions;

namespace Aoc1.Puzzle;

public class Puzzle
{
    private string file = "./input.txt";
    private string[] arr;

    public Puzzle()
    {
        arr = File.ReadAllLines(file);
    }

    private int ExtractInt(string str)
    {
        Match match = Regex.Match(str, @"\d+");
        
        return int.Parse(match.Value);
    }

    public void FindKey()
    {
        int zero = 0;
        int start = 50;
        int left = 0, right = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].Contains('L'))
            {
                int l = ExtractInt(arr[i]);

                start -= l;
            }

            if (arr[i].Contains('R'))
            {
                int r = ExtractInt(arr[i]);

                start += r;
            }

            start = ((start % 100) + 100) % 100;

            if (start == 0)
            {
                zero++;
            }
        }
        Console.WriteLine($"Password: {zero}");
    }
}
