using System.Linq;

namespace TernoValve.libgenext
{
    public class Code
    {
        private string nextCode;
        
        public string CurrentCode;

        public Code(string code)
        {
            CurrentCode = code;
        }

        public bool SeekNext()
        {
            string s = CurrentCode;
            string numPart = "";
            string codePart = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(s[i]))
                {
                    numPart += s[i];
                }
                else
                {
                    codePart = s.Substring(0, i + 1);
                    break;
                }
            }
            if (numPart == "")
            {
                return false;
            }
            numPart = new string(numPart.Reverse().ToArray());
            numPart = (int.Parse(numPart) + 1).ToString("D" + numPart.Length);
            nextCode = codePart + numPart;
            return true;
        }

        public string GetNext()
        {
            CurrentCode = nextCode;
            return nextCode;
        }
    }
}
