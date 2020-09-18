using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MAC_Attack
{
    public class CustomSHA1
    {
        private const uint MESSAGESIZE = 2 ^ 64;  //in Bits
        private const int BLOCKSIZE = 64;  //in Bytes
        private const uint WORDSIZE = 4;  //in Bytes
        private const int REMAINDER = 56; // in Bytes
        private readonly uint[] K = { 0x5a827999, 0x6ed9eba1, 0x8f1bbcdc, 0xca62c1d6 };
        private uint[] InitHash = { 0x67452301, 0xefcdab89, 0x98badcfe, 0x10325476, 0xc3d2e1f0 };  //H
        private byte[,] workSchedule = new byte[80,4];
        private uint[] resultHash = new uint[5];
        private byte[,] workHash = new byte[16, 4];
        private byte[] workMessage;
        private byte[] a, b, c, d, e = new byte[4];
        private SHA1Managed sha1 = new SHA1Managed();

        public string Hash(string input)//, uint[] IV)
        {
            //uint[] result = new uint[5];
            StringBuilder Valid;

            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                Valid = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    Valid.Append(b.ToString("X2"));
                }
            }
            //set initial value section 5.3.1
            //pad message section 5
            Console.WriteLine(input);
            Console.WriteLine(input.Length);
            workMessage = padMessage(input);
            Console.WriteLine(input);
            setNextChunck();
            //build key schedule
            for (int i = 0; i < 80; i++)
            {
                if(i < 16)
                {
                    workSchedule[i, 0] = workMessage[4 * i + 0];
                    workSchedule[i, 1] = workMessage[4 * i + 1];
                    workSchedule[i, 2] = workMessage[4 * i + 2];
                    workSchedule[i, 3] = workMessage[4 * i + 3];
                }
                if(i > 16)
                {
                    //ROTL1(Wt-3 ^ Wt-8 ^ Wt-14 ^ Wt-16)
                    workSchedule[i, 0] = BitConverter.GetBytes(workSchedule[i - 3, 0] ^ workSchedule[i - 8, 0] ^ workSchedule[i - 14, 0] ^ workSchedule[i - 16, 0])[0];
                    workSchedule[i, 1] = BitConverter.GetBytes(workSchedule[i - 3, 1] ^ workSchedule[i - 8, 1] ^ workSchedule[i - 14, 1] ^ workSchedule[i - 16, 1])[0];
                    workSchedule[i, 2] = BitConverter.GetBytes(workSchedule[i - 3, 2] ^ workSchedule[i - 8, 2] ^ workSchedule[i - 14, 2] ^ workSchedule[i - 16, 2])[0];
                    workSchedule[i, 3] = BitConverter.GetBytes(workSchedule[i - 3, 3] ^ workSchedule[i - 8, 3] ^ workSchedule[i - 14, 3] ^ workSchedule[i - 16, 3])[0];
                    ROTL(i, 1);
                }
            }
            a = BitConverter.GetBytes( InitHash[0]);
            b = BitConverter.GetBytes(InitHash[1]);
            c = BitConverter.GetBytes(InitHash[2]);
            d = BitConverter.GetBytes(InitHash[3]);
            e = BitConverter.GetBytes(InitHash[4]);

            for (int i = 0; i < 80; i++)
            {

            }

            return Valid.ToString();
        }

        private void setNextChunck()
        {
            if(workMessage.Length == BLOCKSIZE)
            {
                for (int i = 0; i < 16; i++)
                {
                    for (int d = 0; d < 4; d++)
                    {
                        uint test = BitConverter.ToUInt32(workMessage, i * sizeof(uint));
                        Console.WriteLine(test);
                        workHash[i,d] = workMessage[4*i+d];
                    }
                }
            }
        }

        /// <summary>
        /// The rotate Left (circular Left shift) operation, where x is a w-bit word
        ///  and n is an integer with 0<=n<w, is defined by ROTR n (x)=(x << n) or (x >> w - n).
        /// </summary>
        /// <param name="x"></param>
        /// <param name="word"></param>
        public void ROTL(int index, int shitNumber)
        {
            var bits = new BitArray(new byte[] { workHash[index, 0], workHash[index, 1], workHash[index, 2], workHash[index, 3] });
            for (int i = 0; i < index; i++)
            {

            }
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

        private byte[] padMessage(string input)
        {
            long length = (input.Length * 8);
            Console.WriteLine(input);
            byte[] result = Encoding.ASCII.GetBytes(input);
            byte tmp = 0x80;
            result.Append(tmp);
            if(REMAINDER > input.Length)
            {
               result = addPadd(result, REMAINDER - input.Length, input.Length);
            }
            var lenBytes = BitConverter.GetBytes(length);
            for (int i = 0; i < lenBytes.Length ; i++)
            {
                result[(BLOCKSIZE - 1) - i] = lenBytes[i];
            }

            return result;
        }

        private Byte[] addPadd(byte[] input, int apendLength, int messageLength)
        {
            Array.Resize<byte>(ref input, BLOCKSIZE);
            input[messageLength] = 0x80;
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
