using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car2
{
    class Cryptology
    {
        public static string Encryption(string text,int key)
        {
            char[] a = text.ToCharArray();
            string enText = null;
            foreach(char item in a)
            {
                enText += Convert.ToChar(item + key);
            }
            return enText;
        }
        public static string Decryption(string text,int key)
        {
            char[] a = text.ToCharArray();
            string deText = null;
            foreach (char item in a)
            {
                deText += Convert.ToChar(item - key);
            }
            return deText;
        }
    }
}
