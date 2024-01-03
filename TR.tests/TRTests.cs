

using FluentAssertions;

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
        [InlineData("CoDiNg ChallEnGes", "A-Z", "a-z", "coding challenges")]
        [InlineData("coding challenges", "a-z", "A-Z", "CODING CHALLENGES")]
        [InlineData("coding challenges 012", "0-9", "A-J", "coding challenges ABC")]
        [InlineData("coding challenges 1235", "12345", "ABCDE", "coding challenges ABCE")]
        [InlineData("coding challenges 1235", "[:lower:]", "[:upper:]", "CODING CHALLENGES 1235")]
        [InlineData("CODING CHALLENGES 1235", "[:upper:]", "[:lower:]", "coding challenges 1235")]
        [InlineData("coding challenges 1235", "0-9", "A-J", "coding challenges BCDF")]
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
        [InlineData("CoDiNg ChallEnGes", "A-Z", "")]
        public void Replace_ShouldThrowIfFindOrReplaceIsNotProvided(string testStringToOperateOn,
            string find,
            string replace) {

            var trUtility = new TRUTility(testStringToOperateOn);

            Action act = () => trUtility.ReplaceRange(find, replace);

            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("coding challenges", "abc", "oding hllenges")]
        [InlineData("1st Coding Challenge 123 go...", "1st ", "CodingChallenge23go...")]
        [InlineData("Coding Challenges", "[:upper:]", "oding hallenges")]
        [InlineData("1st Coding Challenge 123 go...", "[:digit:]", "st Coding Challenge  go...")]
        [InlineData("The Project Gutenberg eBook of The Art of WarThis ebook is for the use of anyone anywhere in the United States and", 
            "War",
                    "The Poject Gutenbeg eBook of The At of This ebook is fo the use of nyone nywhee in the United Sttes nd")]

        public void Delete_RemovesSpecifiedCharactersFromString(string input, string find, string expected) {
            var trUtility = new TRUTility(input);

            var stringAfterDeleteOperation = trUtility.Delete(find);

            stringAfterDeleteOperation.Should().Be(expected);
        }


        [Theory]
        [InlineData("AAABBBCCC", "AB", "ABCCC")]
        [InlineData("Duuplicate", "u", "Duplicate")]
        public void Squash_ShouldReplaceConsectiveOccurancesFromString(string input, string find, string expected)
        {
            var trUtility = new TRUTility(input);

            var squashResult = trUtility.Squash(find);

            squashResult.Should().Be(expected);
        }

        [Fact]    
        public void Squash_ShouldReplaceConsectiveOccurancesFromStringEvenIfASingleSpaceIsGivenToSquash()
        {
            var trUtility = new TRUTility("Duplicate Spaces   removed");

            var squashResult = trUtility.Squash(" ");

            squashResult.Should().Be("Duplicate Spaces removed");
        }







    }
}