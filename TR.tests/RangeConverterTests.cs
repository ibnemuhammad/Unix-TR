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
}
