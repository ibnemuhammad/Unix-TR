using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace TR.tests
{
    public class RangeConverterTests
    {
        [Theory]
        [InlineData("A-B", new char[] { 'A', 'B'})]
        [InlineData("A-D", new char[] { 'A', 'B', 'C', 'D'})]
        [InlineData("a-b", new char[] { 'a', 'b'})]
        [InlineData("a-c", new char[] { 'a', 'b', 'c' })]
        [InlineData("a-d", new char[] { 'a', 'b', 'c', 'd' })]
        [InlineData("a-e", new char[] { 'a', 'b', 'c', 'd', 'e' })]
        [InlineData("0-3", new char[] { '0', '1', '2', '3'})]
        [InlineData("0-5", new char[] { '0', '1', '2', '3', '4', '5'})]
        [InlineData("a-a", new char[] { 'a' })]
        [InlineData("0-" , new char[] { '0' })]
        [InlineData("05" , new char[] { '0', '5' })]
        [InlineData("AD" , new char[] { 'A', 'D' })]
        [InlineData("WAR" , new char[] { 'W', 'A', 'R' })]
        [InlineData("aeiou", new char[] { 'a', 'e', 'i', 'o', 'u'})]
        [InlineData("a", new char[] { 'a'})]

        public void Converter_ShouldConvertRangeOfCharacters_ToArray(string range, char[] expectedOutputArray) {

           
            char[] actualResultArray = RangeConverter.Convert(range);

            actualResultArray.Should().Equal(expectedOutputArray);
        }
        
    }

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
        static char[] MatchCharacterRange(string input)
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
