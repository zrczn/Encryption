using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5
{
    public class AlgorytmAES
    {

        public string Zaszyfruj(string Dane, byte[] Klucz, byte[] IV)
        {

            byte[] zaszyfrowaneDane;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Klucz;
                aes.IV = IV;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(Dane);
                        }
                    }

                    zaszyfrowaneDane = ms.ToArray();

                }
            }

            return Convert.ToBase64String(zaszyfrowaneDane);

        }

        public string Odszyfruj(string DaneZaszyfrowane, string Klucz, string IV)
        {

            string odszyfrowaneDane;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(Klucz);
                aes.IV = Convert.FromBase64String(IV);

                byte[] szyfr = Convert.FromBase64String(DaneZaszyfrowane);

                using (MemoryStream ms = new MemoryStream(szyfr))
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            odszyfrowaneDane = sr.ReadToEnd();
                        }
                    }

                }
            }

            return odszyfrowaneDane;

        }



    }
}
