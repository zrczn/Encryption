using Szyfrowanie;

namespace TestSzyfrowania
{
    public class ROT13Test
    {
        [Fact]
        public void TestSzyfrowania()
        {
            string a = "Hello World";

            string b = ROT13.Szyfrowanie(a);

            string c = "Uryyb Jbeyq";

            Assert.Equal(b, c);
        }
        [Fact]
        public void TestDeszyfrowania()
        {
            string a = "Uryyb Jbeyq";

            string b = ROT13.Deszyfrowanie(a);

            string c = "Hello World";

            Assert.Equal(b, c);
        }

    }
}