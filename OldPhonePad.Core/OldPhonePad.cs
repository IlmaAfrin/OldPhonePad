
using System.Text;

namespace OldPhonePad.Core;

public static class OldPhonePad
{
    private static readonly Dictionary<char, string> Keypad = new()
    {
        ['2'] = "ABC",
        ['3'] = "DEF",
        ['4'] = "GHI",
        ['5'] = "JKL",
        ['6'] = "MNO",
        ['7'] = "PQRS",
        ['8'] = "TUV",
        ['9'] = "WXYZ",
        ['0'] = " "
    };

    public static string Decode(string input)
    {
        ValidateInput(input);

        string message = input[..^1];

        return DecodeMessage(message);
    }

    private static void ValidateInput(string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        if (!input.EndsWith('#'))
        {
            throw new ArgumentException(
                "Input must end with '#'.",
                nameof(input));
        }

        foreach (char c in input)
        {
            if (!char.IsDigit(c) &&
                c != ' ' &&
                c != '*' &&
                c != '#')
            {
                throw new ArgumentException(
                    "Input contains invalid characters. Only digits, spaces, '*', and '#' are allowed.",
                    nameof(input));
            }
        }
    }

    private static string DecodeMessage(string message)
    {
        StringBuilder output = new();

        char? currentKey = null;
        int pressCount = 0;

        for (int i = 0; i < message.Length; i++)
        {
            char current = message[i];

            if (current == ' ')
            {
                if (currentKey != null)
                {
                    output.Append(DecodeKey(currentKey.Value, pressCount));
                    currentKey = null;
                    pressCount = 0;
                }

                continue;
            }

            if (current == '*')
            {
                if (currentKey != null)
                {
                    output.Append(DecodeKey(currentKey.Value, pressCount));
                    currentKey = null;
                    pressCount = 0;
                }

                if (output.Length > 0)
                {
                    output.Length--;
                }

                continue;
            }

            if (currentKey == null)
            {
                currentKey = current;
                pressCount = 1;
                continue;
            }

            if (current == currentKey)
            {
                pressCount++;
                continue;
            }

            output.Append(DecodeKey(currentKey.Value, pressCount));

            currentKey = current;
            pressCount = 1;
        }

        if (currentKey != null)
        {
            output.Append(DecodeKey(currentKey.Value, pressCount));
        }

        return output.ToString();
    }

    private static char DecodeKey(char key, int pressCount)
    {
        string letters = Keypad[key];

        int index = (pressCount - 1) % letters.Length;

        return letters[index];
    }
}
