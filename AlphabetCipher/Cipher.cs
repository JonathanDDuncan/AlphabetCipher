using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphabetCipher
{
    public class Cipher
    {
        public static string Alphabet()
        {
            return "abcdefghijklmnopqrstuvwxyz";
        }

        public static string AlphabetShift(int shiftBy)
        {
            return Alphabet().Substring(shiftBy) + Alphabet().Substring(0, shiftBy);
        }

        public static string Chart()
        {
            var count = 0;
            var sb = new StringBuilder();

            foreach (var item in Alphabet())
            {
                sb.AppendLine(AlphabetShift(count));
                count++;
            }

            return sb.ToString();
        }

        public static string Replace(char row, char column)
        {
            var rowNum = (int)row - 97;
            var columnNum = (int)column - 97;
            var alphabetRow = AlphabetShift(rowNum);
            var result = alphabetRow.Substring(columnNum, 1);

            return result;
        }

        public static string Replace(string lookup, string text)
        {
            var count = 0;
            var sb = new StringBuilder();

            foreach (var row in lookup)
            {
                var col = text.Substring(count, 1).FirstOrDefault();
                sb.Append(Replace(row, col));
                count++;
            }

            return sb.ToString();
        }

        public static string Cryptify(string secret, string message)
        {
            var copies = (int) Math.Ceiling((double)message.Length / (double)secret.Length);
            var fullSecret = new String(secret, copies);
        }
    }
}
