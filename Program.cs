using System;
using System.Linq;
using System.Text;

class Cipher
{
    private string _input;
    private int _n;
    private string _output;

    public string Input
    {
        get => _input;
        set => _input = value;
    }

    public int N
    {
        get => _n;
        set => _n = value;
    }

    public Cipher(string s, int n)
    {
        _input = s;
        _n = n;
        _output = string.Empty;
    }

    public void Encode()
    {
        StringBuilder builder = new StringBuilder();
        foreach (char c in _input)
        {
            int shifted = ((c - 'A' + _n + 26) % 26) + 'A';
            builder.Append((char)shifted);
        }
        _output = builder.ToString();
    }

    public string Print()
    {
        return _output;
    }

    public int[] InputCode()
    {
        return _input.Select(c => (int)c).ToArray();
    }

    public int[] OutputCode()
    {
        return _output.Select(c => (int)c).ToArray();
    }

    public string Sort()
    {
        return new string(_input.OrderBy(c => c).ToArray());
    }
}

class Program
{
    static void Main()
    {
        string input;
        int n;

        // Input validation for string
        do
        {
            Console.Write("Enter a string (only capital letters, max 40): ");
            input = Console.ReadLine();
        } while (string.IsNullOrEmpty(input) || input.Length > 40 || !input.All(char.IsUpper));

        // Input validation for integer
        Console.Write("Enter a number between -25 and 25: ");
        while (!int.TryParse(Console.ReadLine(), out n) || n < -25 || n > 25)
        {
            Console.WriteLine("Invalid input. Please enter a valid number between -25 and 25:");
        }

        // Create and encode
        Cipher cipher = new Cipher(input, n);
        cipher.Encode();

        // Display results
        Console.WriteLine("\n--- ENCODED ---");
        Console.WriteLine("Encoded Output: " + cipher.Print());
        Console.WriteLine("Input ASCII Values: " + string.Join(", ", cipher.InputCode()));
        Console.WriteLine("Output ASCII Values: " + string.Join(", ", cipher.OutputCode()));
        Console.WriteLine("Sorted Input: " + cipher.Sort());

        // Reverse test
        Console.WriteLine("\n--- DECODED ---");
        Cipher reverse = new Cipher(cipher.Print(), -n);
        reverse.Encode();
        Console.WriteLine("Decoded Output: " + reverse.Print());

        // Prevent auto-close in some IDEs
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
