using System;
using System.Linq;

namespace AlphabetCipher
{
    public class Cypher
    {
        public static string Crypto(bool encrypt, string alfabet, string passphrase, string message)
        {
            return encrypt ? Encrypt(alfabet, passphrase, message) : Decrypt(alfabet, passphrase, message);
        }

        public static string Ascii()
        {
            return Enumerable.Range(0, 256).Select(x => (char)x).Aggregate("", (accm, x) => accm + x);
        }

        public static string Alphabet()
        {
            return "abcdefghijklmnopqrstuvwxyz";
        }

        public static string Base64()
        {
            return "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
        }

        public static string AlphabetShift(string alphabet, int shiftBy)
        {
            return alphabet[shiftBy..] + alphabet[0..shiftBy];
        }

        public static string Chart(string alphabet)
        {
            return alphabet
                  .Select((x, i) => AlphabetShift(alphabet, i) + Environment.NewLine)
                  .Aggregate("", (accm, x) => accm + x);
        }


        public static string Decrypt(string alphabet, string secret, string message)
        {
            return Fold(alphabet, FullSecret(secret, message.Length), message, Decrypt);
        }

        public static string Decrypt(string alphabet, char row, char column)
        {
            var tranposition = alphabet.IndexOf(column) - alphabet.IndexOf(row);

            var index = tranposition <= 0 ? tranposition + alphabet.Length : tranposition;

            return alphabet.Substring(index, 1);
        }

        public static string Encrypt(string alphabet, string secret, string message)
        {
            return Fold(alphabet, FullSecret(secret, message.Length), message, Encrypt);
        }

        public static string Encrypt(string alphabet, char row, char column)
        {
            int alphaLength = alphabet.Length;
            var tranposition = alphabet.IndexOf(column) + alphabet.IndexOf(row);

            var index = tranposition >= alphaLength ? tranposition - alphaLength : tranposition;

            return alphabet.Substring(index, 1);
        }

        public static string Fold(string alphabet, string passphrase, string text, Func<string, char, char, string> apply)
        {
            return passphrase.Zip(text)
                .Select(x => apply(alphabet, x.First, x.Second))
                .Aggregate("", (accm, x) => accm + x);
        }

        private static string FullSecret(string secret, int messageLength)
        {
            var copiesNeeded = (int)Math.Ceiling(messageLength / (double)secret.Length);

            return Enumerable.Range(0, copiesNeeded)
                .Aggregate("", (accm, x) => accm + secret)
                .Substring(0, messageLength);
        }
    }
}
