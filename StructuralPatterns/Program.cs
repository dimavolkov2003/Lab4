using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace StructuralPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            string original = "Here is some data to encrypt!";

            using (AesManaged myAes = new AesManaged())
            {

                byte[] encrypted = EncryptionFacade.EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);
                string roundtrip = EncryptionFacade.DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);
                Print(original, encrypted, roundtrip);
       
            }
        }

        static public void Print(string original, byte[] encrypted, string roundtrip)
        {
            Console.WriteLine("Original:   {0}", original);
            Console.WriteLine("encrypted:");
            for (int i = 0; i < encrypted.Length; i++)
            {
                Console.Write(encrypted[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Round Trip: {0}", roundtrip);
        }
    }
}




