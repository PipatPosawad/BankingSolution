using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Service.Test
{
    public class ReverseTests
    {
        [Fact]
        public void Reverse()
        {
            var input = "ABCDE";

            var result = "";

            var inputChars = input.ToCharArray();
            for(int i = inputChars.Length - 1; i >= 0; i--)
            {
                result += inputChars[i];
            }

            var output = "EDCBA";

            Assert.Equal(output, result);
        }

        [Fact]
        public void ImproveReverse()
        {
            var input = "ABCDE";

            var start = 0;
            var end = input.Length - 1;
            var result = input.ToCharArray();
            while(start < end)
            {
                var temp = result[end];
                result[end] = result[start];
                result[start] = temp;
                start++;
                end--;
            }

            var output = "EDCBA";

            Assert.Equal(output, string.Join("", result));
        }
    }
}
