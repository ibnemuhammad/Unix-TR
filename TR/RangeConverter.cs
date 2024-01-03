namespace TR.tests
{
    internal class RangeConverter
    {
        

        static internal char[] Convert(string range)
        {
            if (!range.Contains("-"))
            {
                return MatchCharacterRange(range);
            }
            else { 
                
                char firstItem = range[0];
                char lastItem = range[range.Length - 1];
                if (lastItem == '-')
                {
                    if (range.Length == 2)
                    {
                        return [firstItem];
                    }
                    
                }
                return GetCharacterRange(firstItem, lastItem);
            }

        }
        private static char[] MatchCharacterRange(string input)
        {
            ArgumentException.ThrowIfNullOrEmpty(input);
            return input switch
            {
                "[:digit:]" => GetCharacterRange('0', '9'),
                "[:alnum:]" => GetCharacterRange('a', 'z')
                                  .Union(GetCharacterRange('A', 'Z'))
                                  .Union(GetCharacterRange('0', '9')).ToArray(),
                "[:space:]" => new char[]{' ', '\t', '\n', '\r', '\f', '\v'}, 
                "[:punct:]" => GetPunctuationCharacters(), // Matches punctuation characters
                "[:lower:]" => GetCharacterRange('a', 'z'), // Matches lowercase letters
                "[:upper:]" => GetCharacterRange('A', 'Z'), // Matches uppercase letters
                _ => input.ToCharArray()
            };
        }

        private static char[] GetMultipleCharacterRange(char v1, char v2, char v3, char v4, char v5, char v6)
        {
            throw new NotImplementedException();
        }

        private static char[] GetPunctuationCharacters()
        {
            return new char[] { '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~' };
        }

        private static char[] GetCharacterRange(char start, char end)
        {
            ArgumentNullException.ThrowIfNull(start);
            ArgumentNullException.ThrowIfNull(end);
            if (start > end)
            {
                throw new ArgumentException("range start should be smaller than range end");
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
}
