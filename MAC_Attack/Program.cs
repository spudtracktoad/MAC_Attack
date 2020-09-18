using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAC_Attack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomSHA1 sha1 = new CustomSHA1();
            Byte[] Data = new Byte[] {
                          0x4e, 0x6f, 0x20, 0x6f, 0x6e, 0x65, 0x20, 0x68, 0x61, 0x73, 0x20, 0x63, 0x6f, 0x6d, 0x70, 0x6c,
                          0x65, 0x74, 0x65, 0x64, 0x20, 0x50, 0x72, 0x6f, 0x6a, 0x65, 0x63, 0x74, 0x20, 0x23, 0x33, 0x20,
                          0x73, 0x6f, 0x20, 0x67, 0x69, 0x76, 0x65, 0x20, 0x74, 0x68, 0x65, 0x6d, 0x20, 0x61, 0x6c, 0x6c,
                          0x20, 0x61, 0x20, 0x30
                        };
            Byte[] DataHash = new Byte[] { 0xac, 0x94, 0xe7, 0xcf, 0x99, 0x45, 0x6f, 0xbf, 0xe5, 0xe7, 0xaa, 0x79, 0xe9, 0x4d, 0x89, 0x05, 0x78, 0x89, 0xb6, 0x7e };

            string org_Message = "No one has completed Project #3 so give them all a 0";
            string org_Digest = "ac94e7cf99456fbfe5e7aa79e94d89057889b67e";
            string attackMessage = "P.S. Except for Jared, go ahead and give him the full points";
            string test1 = "abc";
            string test2 = "demo";
            string test2Digest = "89e495e7941cf9e40e6980d14a16bf023ccd4c910";


            
            Console.WriteLine( sha1.Hash(test));

            Console.ReadLine();
        }
    }
}
