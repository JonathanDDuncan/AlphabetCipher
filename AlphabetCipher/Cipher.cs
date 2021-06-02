using System;
using System.Linq;

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
            return Alphabet()[shiftBy..] + Alphabet()[0..shiftBy];
        }

        public static string Chart()
        {
            return Alphabet()
                  .Select((x, i) => AlphabetShift(i) + Environment.NewLine)
                  .Aggregate("", (accm, x) => accm + x);
        }


        public static string Decrypt(string secret, string message)
        {
            return Fold(FullSecret(secret, message), message, Decrypt);
        }

        public static string Decrypt(char row, char column)
        {
            var alphabet = Alphabet();

            var tranposition = alphabet.IndexOf(column) - alphabet.IndexOf(row);

            var index = tranposition <= 0 ? tranposition + alphabet.Length : tranposition;

            return alphabet.Substring(index, 1);
        }

        public static string Encrypt(string secret, string message)
        {
            return Fold(FullSecret(secret, message), message, Encrypt);
        }

        public static string Encrypt(char row, char column)
        {
            var alphabet = Alphabet();

            int alphaLength = alphabet.Length;
            var tranposition = alphabet.IndexOf(column) + alphabet.IndexOf(row);

            var index = tranposition >= alphaLength ? tranposition - alphaLength : tranposition;

            return alphabet.Substring(index, 1);
        }

        public static string Fold(string passphrase, string text, Func<char, char, string> apply)
        {
            return passphrase.Zip(text)
                .Select(x => apply(x.First, x.Second))
                .Aggregate("", (accm, x) => accm + x);
        }

        private static string FullSecret(string secret, string message)
        {
            var copiesNeeded = (int)Math.Ceiling(message.Length / (double)secret.Length);

            return Enumerable.Range(0, copiesNeeded)
                .Aggregate("", (accm, x) => accm + secret)
                .Substring(0, message.Length);
        }
    }
}
