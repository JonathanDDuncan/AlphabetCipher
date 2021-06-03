using AlphabetCipher;
using System;
using Xunit;

namespace AlphabetCipherTest
{
    public class CypherTests
    {
        [Fact]
        public void AlphabetTest()
        {
            var result = Cypher.Alphabet();
            var expected = "abcdefghijklmnopqrstuvwxyz";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AlphabetOffByOneTest()
        {
            var result = Cypher.AlphabetShift(Cypher.Alphabet(), 1);
            var expected = "bcdefghijklmnopqrstuvwxyza";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AlphabetOffByTwelveTest()
        {
            var result = Cypher.AlphabetShift(Cypher.Alphabet(), 12);
            var expected = "mnopqrstuvwxyzabcdefghijkl";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AlphabetChartTest()
        {
            var result = Cypher.Chart(Cypher.Alphabet());
            var expected = @"abcdefghijklmnopqrstuvwxyz
bcdefghijklmnopqrstuvwxyza
cdefghijklmnopqrstuvwxyzab
defghijklmnopqrstuvwxyzabc
efghijklmnopqrstuvwxyzabcd
fghijklmnopqrstuvwxyzabcde
ghijklmnopqrstuvwxyzabcdef
hijklmnopqrstuvwxyzabcdefg
ijklmnopqrstuvwxyzabcdefgh
jklmnopqrstuvwxyzabcdefghi
klmnopqrstuvwxyzabcdefghij
lmnopqrstuvwxyzabcdefghijk
mnopqrstuvwxyzabcdefghijkl
nopqrstuvwxyzabcdefghijklm
opqrstuvwxyzabcdefghijklmn
pqrstuvwxyzabcdefghijklmno
qrstuvwxyzabcdefghijklmnop
rstuvwxyzabcdefghijklmnopq
stuvwxyzabcdefghijklmnopqr
tuvwxyzabcdefghijklmnopqrs
uvwxyzabcdefghijklmnopqrst
vwxyzabcdefghijklmnopqrstu
wxyzabcdefghijklmnopqrstuv
xyzabcdefghijklmnopqrstuvw
yzabcdefghijklmnopqrstuvwx
zabcdefghijklmnopqrstuvwxy
";
            Assert.Equal(expected, result);
        }
        [Fact]
        public void ReplaceEncryptAETest()
        {
            var result = Cypher.Encrypt(Cypher.Alphabet(), 'a', 'e');
            var expected = "e";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReplaceEncryptTWTest()
        {
            var result = Cypher.Encrypt(Cypher.Alphabet(), 't', 'w');
            var expected = "p";
            Assert.Equal(expected, result);
        }
        [Fact]
        public void ReplaceDecryptAETest()
        {
            var result = Cypher.Encrypt(Cypher.Alphabet(), 'a', 'e');
            var expected = "e";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReplaceDecryptTWTest()
        {
            var result = Cypher.Decrypt(Cypher.Alphabet(), 't', 'p');
            var expected = "w";
            Assert.Equal(expected, result);
        }
        [Fact]
        public void ReplaceAETWTest()
        {
            var result = Cypher.Encrypt(Cypher.Alphabet(), "at", "ew");
            var expected = "ep";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReplaceMessageTest()
        {
            var message = "meetmebythetree";
            var secret = "sconessconessco";
            var result = Cypher.Encrypt(Cypher.Alphabet(), secret, message);
            var expected = "egsgqwtahuiljgs";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CryptifyEncryptTest()
        {
            var message = "meetmebythetree";
            var secret = "scones";
            var result = Cypher.Encrypt(Cypher.Alphabet(), secret, message);
            var expected = "egsgqwtahuiljgs";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CryptifyDecryptTest()
        {
            var message = "egsgqwtahuiljgs";
            var secret = "scones";
            var result = Cypher.Decrypt(Cypher.Alphabet(), secret, message);
            var expected = "meetmebythetree";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CryptifyEncryptSpanishTest()
        {
            var message = "esteesunmensajesecretonolodivulguesanadie";
            var secret = "holausted";
            var result = Cypher.Encrypt(Cypher.Alphabet(), secret, message);
            var expected = "lgeeyknrplbdadwlifyseohgesgpjflamxwduooiy";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CryptifyDecryptSpanishTest()
        {
            var message = "lgeeyknrplbdadwlifyseohgesgpjflamxwduooiy";
            var secret = "holausted";
            var result = Cypher.Decrypt(Cypher.Alphabet(), secret, message);
            var expected = "esteesunmensajesecretonolodivulguesanadie";
            Assert.Equal(expected, result);
        }
    }
}
