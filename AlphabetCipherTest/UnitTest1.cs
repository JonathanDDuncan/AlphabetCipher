using AlphabetCipher;
using System;
using Xunit;

namespace AlphabetCipherTest
{
    public class UnitTest1
    {
        [Fact]
        public void AlphabetTest()
        {
            var result = Cipher.Alphabet();
            var expected = "abcdefghijklmnopqrstuvwxyz";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AlphabetOffByOneTest()
        {
            var result = Cipher.AlphabetShift(1);
            var expected = "bcdefghijklmnopqrstuvwxyza";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AlphabetOffByTwelveTest()
        {
            var result = Cipher.AlphabetShift(12);
            var expected = "mnopqrstuvwxyzabcdefghijkl";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AlphabetChartTest()
        {
            var result = Cipher.Chart();
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
        public void ReplaceAETest()
        {
            var result = Cipher.Replace('a', 'e');
            var expected = "e";
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void ReplaceTWTest()
        {
            var result = Cipher.Replace('t', 'w');
            var expected = "p";
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void ReplaceAETWTest()
        {
            var result = Cipher.Replace("at", "ew");
            var expected = "ep";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReplaceMessageTest()
        {
            var message = "meetmebythetree";
            var secret = "sconessconessco";
            var result = Cipher.Replace(secret, message);
            var expected = "egsgqwtahuiljgs";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CryptifyTest()
        {
            var message = "meetmebythetree";
            var secret = "scones";
            var result = Cipher.Cryptify(secret, message);
            var expected = "egsgqwtahuiljgs";
            Assert.Equal(expected, result);
        }
    }
}
