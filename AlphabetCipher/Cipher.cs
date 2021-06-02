using System;
using System.Linq;
using System.Text;

namespace AlphabetCipher
{
    public class Cypher
    {
        public static string Crypto(bool encrypt, string passphrase, string message)
        {
            return encrypt ? Encrypt(passphrase, message) : Decrypt(passphrase, message);
        }

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
            var sb = new StringBuilder();
            for (int i = 0; i < Alphabet().Length; i++)
            {
                sb.AppendLine(AlphabetShift(i));
            }
            return sb.ToString();
        }


        public static string Decrypt(string secret, string message)
        {
            string fullSecret = FullSecret(secret, message);

            return WalkThrough(fullSecret, message, Decrypt);
        }

        public static string Decrypt(char row, char column)
        {
            var alphabet = Alphabet();
            var rowNum = alphabet.IndexOf(row);
            var columnNum = alphabet.IndexOf(column);

            int alphaLength = alphabet.Length;
            var tranposition = columnNum - rowNum;

            var index = tranposition <= 0 ? tranposition + alphaLength : tranposition;

            return alphabet.Substring(index, 1);
        }

        public static string Encrypt(string secret, string message)
        {
            string fullSecret = FullSecret(secret, message);

            return WalkThrough(fullSecret, message, Encrypt);
        }

        public static string Encrypt(char row, char column)
        {
            var alphabet = Alphabet();
            var rowNum = alphabet.IndexOf(row);
            var columnNum = alphabet.IndexOf(column);

            int alphaLength = alphabet.Length;
            var tranposition = columnNum + rowNum;

            var index = tranposition >= alphaLength ? tranposition - alphaLength : tranposition;

            return alphabet.Substring(index, 1);
        }

        public static string WalkThrough(string passphrase, string text, Func<char, char, string> apply)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                var row = passphrase.Substring(i, 1).FirstOrDefault();
                var col = text.Substring(i, 1).FirstOrDefault();
                sb.Append(apply(row, col));
            }
            return sb.ToString();
        }

        private static string FullSecret(string secret, string message)
        {
            var copies = (int)Math.Ceiling((double)message.Length / (double)secret.Length);
            var fullSecret = "";
            for (int i = 0; i < copies; i++)
            {
                fullSecret += secret;
            }
            fullSecret = fullSecret.Substring(0, message.Length);
            return fullSecret;
        }
    }
}
