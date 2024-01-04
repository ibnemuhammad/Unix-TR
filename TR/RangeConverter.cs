namespace TR.tests;

public class RangeConverter
{
    public static char[] Convert(string range)
    {
        ArgumentException.ThrowIfNullOrEmpty(range);

        if (range.Contains("-"))
        {
            if (range.Length == 2 && range[1] == '-')
            {
                return new char[] { range[0] };
            }
            else
            {
                char firstItem = range[0];
                char lastItem = range[range.Length - 1];
                return GetCharacterRange(firstItem, lastItem);
            }
        }
        else
        {
            return MatchCharacterRange(range);
        }
    }

    private static char[] MatchCharacterRange(string input)
    {
        switch (input)
        {
            case "[:digit:]":
                return GetCharacterRange('0', '9');
            case "[:alnum:]":
                return GetCharacterRange('a', 'z')
                    .Union(GetCharacterRange('A', 'Z'))
                    .Union(GetCharacterRange('0', '9')).ToArray();
            case "[:space:]":
                return new char[] { ' ', '\t', '\n', '\r', '\f', '\v' };
            case "[:punct:]":
                return GetPunctuationCharacters();
            case "[:lower:]":
                return GetCharacterRange('a', 'z');
            case "[:upper:]":
                return GetCharacterRange('A', 'Z');
            default:
                return input.ToCharArray();
        }
    }

    private static char[] GetPunctuationCharacters()
    {
        return ['!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~'];
    }

    private static char[] GetCharacterRange(char start, char end)
    {
        if (start > end)
        {
            throw new ArgumentException("Range start should be smaller than range end");
        }

        int rangeLength = end - start + 1;
        char[] range = new char[rangeLength];

        for (int i = 0; i < rangeLength; i++)
        {
            range[i] = (char)(start + i);
        }

        return range;
    }
}