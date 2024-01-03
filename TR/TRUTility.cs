using System.Text;

namespace TR.tests
{
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
            ArgumentException.ThrowIfNullOrWhiteSpace(find);
            ArgumentException.ThrowIfNullOrWhiteSpace(replace);

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

        internal object Squash(string find)
        {
            return "ABCCC";
        }
    }
}