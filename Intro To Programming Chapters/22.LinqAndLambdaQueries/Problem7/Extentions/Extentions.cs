using System.Text;

namespace Problem7.Extentions
{
    public static class Extentions
    {
        private static bool IsLetterOrDigitExt(string s, int index)
        {
            return !IsAtStringBoundaries(s, index) && char.IsLetterOrDigit(s[index]);
        }

        private static bool IsWordSeparator(string s, int index)
        {
            if (!IsAtStringBoundaries(s, index))
            {
                if (s[index] == '\'' && IsLetterOrDigitExt(s, index - 1))
                {
                    return false;
                }
                else
                {
                    return !IsLetterOrDigitExt(s, index);
                }
            }
            else
            {
                return true;
            }
        }
        private static bool IsAtStringBoundaries(string s, int index)
        {
            return index == -1 || index == s.Length;
        }

        public static string ToTitleCase(this string s)
        {
            var output = new StringBuilder(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                output.Append(IsWordSeparator(s, i - 1) ? char.ToUpper(s[i]) : char.ToLower(s[i]));
            }

            return output.ToString();
        }
    }
}
