using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAC_Attack
{
    public class CustomSHA1
    {
        private const uint MESSAGESIZE = 2 ^ 64;  //in Bits
        private const uint BLOCKSIZE = 512;  //in Bits
        private const uint WORDSIZE = 32;  //in Bits
        private const int REMAINDER = 448;
        private readonly uint[] K = { 0x5a827999, 0x6ed9eba1, 0x8f1bbcdc, 0xca62c1d6 };
        private uint[] InitHash = { 0x67452301, 0xefcdab89, 0x98badcfe, 0x10325476, 0xc3d2e1f0 };
        private uint[] resultHash = new uint[5];

        public uint[] Hash(string input)
        {
            uint[] result = new uint[5];
            //set initial value section 5.3.1
            //pad message section 5
            Console.WriteLine(input);
            Console.WriteLine(input.Length);
            input = padMessage(input);
            Console.WriteLine(input);



            
            return result;
        }

        /// <summary>
        /// The rotate Left (circular Left shift) operation, where x is a w-bit word
        ///  and n is an integer with 0<=n<w, is defined by ROTR n (x)=(x << n) or (x >> w - n).
        /// </summary>
        /// <param name="x"></param>
        /// <param name="word"></param>
        public void ROTL(int x, uint word)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The rotate right (circular right shift) operation, where x is a w-bit word
        ///  and n is an integer with 0<=n<w, is defined by ROTR n (x)=(x >> n) or (x << w - n).
        /// </summary>
        /// <param name="x"></param>
        /// <param name="word"></param>
        public void ROTR(int x, uint word)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The right shift operation, where x is a w-bit word and n is an integer with 0
        //<=n<w, is defined by SHR n(x)=x >> n.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="word"></param>
        public void SHR(int x, uint word)
        {
            throw new NotImplementedException();
        }

        private string padMessage(string input)
        {
            int length = input.Length;
            Console.WriteLine(input);
            input = input + 0x01;
            Console.WriteLine(input);
            if(REMAINDER > input.Length)
            {
               input = addPadd(input, REMAINDER - input.Length);
            }
            //would need to have values that re greater than the REMAINDER for a complete solution
            Console.WriteLine(input);
            input = input + Convert.ToString(length, 2).PadLeft(8, '0'); // 00000011
            Console.WriteLine(input);

            return input;
        }

        private string addPadd(string input, int length)
        {
            for (int i = 0; i < length; i++)
            {
                input += 0;
            }
            return input;
        }

        private static uint GCD(uint a, uint b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a | b;
        }
    }
}
