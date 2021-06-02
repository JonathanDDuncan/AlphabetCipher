using AlphabetCipher;
using Xunit;

namespace AlphabetCipherTest
{
    public class ArgsTests
    {
        [Fact]
        public void ArgsIsEncryptTest()
        {
            var args = new string[] { "-e" };
            var result = Args.IsEnCrypt(args);
            Assert.True(result);
        }

        [Fact]
        public void ArgsIsDecryptTest()
        {
            var args = new string[] { "-d" };
            var result = Args.IsDeCrypt(args);
            Assert.True(result);
        }

        [Fact]
        public void ArgsPassPhraseTest()
        {
            var args = new string[] { "myPassPhrase" };
            var result = Args.PassPhrase(args);
            Assert.NotNull(result);
        }

        [Fact]
        public void ArgsMessageTest()
        {
            var args = new string[] { "myPassPhrase", "secretmessage" };
            var result = Args.Message(args);
            Assert.NotNull(result);
        }
    }
}
