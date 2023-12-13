using System.Text.RegularExpressions;

namespace AcademiaFS.CSharp.Tuesday._Features.ContadorCaracteres
{
    public partial class ContadorCaracteresService
    {
        public ContadorCaracteresService()
        {

        }

        public int CountCharacters(string input)
        {
            string fixedInput = RegexCleanExtraSpaces().Replace(input, " ");
            return fixedInput.Length;
        }

        private static readonly char[] separator = [' '];

        public int CountWords(string input)
        {
            return input.Split(separator, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        [GeneratedRegex(@"\s+")]
        private static partial Regex RegexCleanExtraSpaces();
    }
}
