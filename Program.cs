using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.IO;
using System.Text;

namespace Decrypt
{
    static class Program
    {
        static int Main(string[] args)
        {
            //try
            {
                //var buffer = File.ReadAllBytes(args[0]);
                //byte[] key = Convert.FromBase64String(args[2]);
                //byte[] iv = Convert.FromBase64String(args[3]);

                var buffer = Convert.FromBase64String("wN4AAmx2kx5cpzZ98KkHOuapfjA//NLBgSxqLwRIcnrWvmzEJBo7UO4ETmlLF60MH1IUj6ceGX4bTxq/b40FDZFgMvIxgUF/S2AuV4LA/UXW814gLC1IjngCNwguxCdSnvLK0YRLFKz7hXkL");
                var key = Convert.FromBase64String("2JDKdLwjKMDLgxXGsI4AxBQ9t7d7of9Jp5gQkdBryoM=");
                var iv = Convert.FromBase64String("HzL3PqQVDY4H1QvMn5KghO+Is8NnJ+ydTYafQb+8HpI=");
                var engine = new RijndaelEngine(256);
                var blockCipher = new CbcBlockCipher(engine);
                var cipher = new BufferedBlockCipher(blockCipher);
                var keyParam = new KeyParameter(key);
                var keyParamWithIV = new ParametersWithIV(keyParam, iv);
                cipher.Init(false, keyParamWithIV);
                var outputBuffer = cipher.DoFinal(buffer);
                //File.WriteAllBytes(args[1], outputBuffer);


                File.WriteAllBytes("output.txt", outputBuffer);
                return 0;
            }
            //catch
            //{
            //    return 1;
            //}
        }
    }
}
