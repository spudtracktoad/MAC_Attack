using System;
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

    }
}
