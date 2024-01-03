

using FluentAssertions;
using System.Text;

namespace TR.tests
{
    public class TRTests
    {
        [Fact]
        public void FindAndReplace_ShouldReturnReplaced()
        {
            var testStringToOperateOn = "coding challenges";
            var trUtility = new TRUTility(testStringToOperateOn);

            var replaceResult = trUtility.ReplaceRange("c", "C");
            
            Assert.Equal("Coding Challenges", replaceResult);

        }

        [Theory]
        [InlineData("Coding Challenges", "A-Z", "a-z", "coding challenges")]
        [InlineData("coding challenges", "a-z", "A-Z", "CODING CHALLENGES")]
        [InlineData("coding challenges 012", "0-9", "A-J", "coding challenges ABC")]
        [InlineData("coding challenges 1235", "0-9", "A-J", "coding challenges BCDF")]
        [InlineData("coding challenges 1235", "12345", "ABCDE", "coding challenges ABCE")]
        [InlineData("coding challenges 1235", "[:lower:]", "[:upper:]", "CODING CHALLENGES 1235")]
        [InlineData("CODING CHALLENGES 1235", "[:upper:]", "[:lower:]", "coding challenges 1235")]
        [InlineData("CODING CHALLENGES 1235", "[:digit:]", "abcdefghij", "CODING CHALLENGES bcdf")]
        public void ReplaceRange_ShouldReturnStringWithCharacterRangeReplaced(string testStringToOperateOn,
            string find,
            string replace,
            string expected)
        {
            var trUtility = new TRUTility(testStringToOperateOn);

            var replaceResult = trUtility.ReplaceRange(find, replace);

            Assert.Equal(expected, replaceResult);
        }

        [Theory]
        [InlineData("coding challenges", "abc", "oding hllenges")]
        [InlineData("1st Coding Challenge 123 go...", "1st ", "CodingChallenge23go...")]
        [InlineData("Coding Challenges", "[:upper:]", "oding hallenges")]
        [InlineData("1st Coding Challenge 123 go...", "[:digit:]", "st Coding Challenge  go...")]

        public void Delete_RemovesSpecifiedCharactersFromString(string input, string find, string expected) {
            var trUtility = new TRUTility(input);

            var stringAfterDeleteOperation = trUtility.Delete(find);

            stringAfterDeleteOperation.Should().Be(expected);
        }


    }

    internal class TRUTility(string OperateOn)
    {
        internal string Delete(string find)
        {
            var findCharacters = RangeConverter.Convert(find);
            StringBuilder result = new StringBuilder(OperateOn);

            foreach (var c in findCharacters)
            {
                result.Replace(c.ToString(), string.Empty);
            }

            return result.ToString();

        }

        internal string? ReplaceRange(string find, string replace)
        {
            var findCharacters = RangeConverter.Convert(find);
            var replaceCharacters = RangeConverter.Convert(replace);
            var inputCharacters = OperateOn.ToCharArray();
            for (int i = 0; i < inputCharacters.Length; i++)
            {
                char c = inputCharacters[i];
                int index = Array.IndexOf(findCharacters, c);
                if (index >= 0)
                {
                    inputCharacters[i] = replaceCharacters[index];
                }
            }
            return new string(inputCharacters);
        }

        
    }
}