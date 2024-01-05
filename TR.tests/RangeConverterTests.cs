namespace TR.tests;

public class RangeConverterTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Converter_ShouldConvertRangeOfCharacters_ToArray(string range, char[] expectedOutputArray) {
        
        char[] actualResultArray = RangeConverter.Convert(range);

        actualResultArray.Should().Equal(expectedOutputArray);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { "A-B", new char[] { 'A', 'B' } };
        yield return new object[] { "A-D", new char[] { 'A', 'B', 'C', 'D' } };
        yield return new object[] { "a-b", new char[] { 'a', 'b' } };
        yield return new object[] { "a-c", new char[] { 'a', 'b', 'c' } };
        yield return new object[] { "a-d", new char[] { 'a', 'b', 'c', 'd' } };
        yield return new object[] { "a-e", new char[] { 'a', 'b', 'c', 'd', 'e' } };
        yield return new object[] { "0-3", new char[] { '0', '1', '2', '3' } };
        yield return new object[] { "0-5", new char[] { '0', '1', '2', '3', '4', '5' } };
        yield return new object[] { "a-a", new char[] { 'a' } };
        yield return new object[] { "0-", new char[] { '0' } };
        yield return new object[] { "05", new char[] { '0', '5' } };
        yield return new object[] { "AD", new char[] { 'A', 'D' } };
        yield return new object[] { "WAR", new char[] { 'W', 'A', 'R' } };
        yield return new object[] { "aeiou", new char[] { 'a', 'e', 'i', 'o', 'u' } };
        yield return new object[] { "a", new char[] { 'a' } };
    }
    


}
