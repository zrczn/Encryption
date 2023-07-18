using System.Runtime.CompilerServices;
using System.Text;

namespace Szyfrowanie;

public class ROT13
{
    public static string Szyfrowanie(string input)
    {
        StringBuilder sb = new StringBuilder();


        foreach (char item in input)
        {
            if (item >= 'a' && item <= 'z')
            {
                sb.Append((char)((item - 'a' + 13) % 26 + 'a'));
            }

            else if (item >= 'A' && item <= 'Z')
            {
                sb.Append((char)((item - 'A' + 13) % 26 + 'A'));
            }

            else
                sb.Append(item);
        }

        return sb.ToString();
    }

    public static string Deszyfrowanie(string input) => Szyfrowanie(input);

}