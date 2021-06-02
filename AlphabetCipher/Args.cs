using System.Linq;

namespace AlphabetCipher
{
    public class Args
    {
        public static bool IsEnCrypt(string[] args)
        {
            return args.Select(x => x.ToLower()).Any(x => x == "-e");
        }

        public static bool IsDeCrypt(string[] args)
        {
            return args.Select(x => x.ToLower()).Any(x => x == "-d");
        }

        public static string PassPhrase(string[] args)
        {
            return args.Where(x => !x.StartsWith('-')).FirstOrDefault();
        }

        public static string Message(string[] args)
        {
            return args.Where(x => !x.StartsWith('-')).Skip(1).FirstOrDefault();
        }
    }
}