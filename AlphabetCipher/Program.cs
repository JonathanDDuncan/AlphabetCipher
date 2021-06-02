using System;

namespace AlphabetCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            var encrypt = Args.IsEnCrypt(args);
            var decrypt = Args.IsDeCrypt(args);
            var passphrase = Args.PassPhrase(args);
            var message = Args.Message(args);

            if (!(encrypt && decrypt) && !(!encrypt && !decrypt)
                && !string.IsNullOrEmpty(passphrase)
                && !string.IsNullOrEmpty(message))
            {
                Console.WriteLine(Cypher.Crypto(encrypt, passphrase, message));
            }
            else
            {
                DisplayUsage();
            }
        }

        private static void DisplayUsage()
        {
            Console.WriteLine("There has been an error, please check your arguments.");
            Console.WriteLine("-e: encrypt, -d:decrypt");
            Console.WriteLine("usage: AlphabetCipher [-e|-d] passphrase message");
        }
    }
}
