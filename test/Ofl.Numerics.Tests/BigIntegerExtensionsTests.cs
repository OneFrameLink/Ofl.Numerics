using System;
using System.Numerics;
using Xunit;

namespace Ofl.Numerics.Tests
{
    public class BigIntegerExtensionsTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(10)]
        [InlineData(100)]
        public void Test_Unchecked_PositiveOverflow(int iterations)
        {
            // Seed the big int and the int.
            int intValue = 0;
            BigInteger bigint = 0;

            // Allow overflow.
            unchecked
            {
                // Loop.
                for (int index = 0; index < iterations; ++index)
                {
                    // Add Max value, and 1.  Overflow each time.
                    intValue += int.MaxValue;
                    intValue += 2;

                    // Update bigint.
                    bigint = (bigint + int.MaxValue).Unchecked(4);
                    bigint = (bigint + 2).Unchecked(4);

                    // Are equal.
                    Assert.Equal(intValue, bigint);
                }
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(10)]
        [InlineData(100)]
        public void Test_Unchecked_Negative(int iterations)
        {
            // Seed the big int and the int.
            int intValue = 0;
            BigInteger bigint = 0;

            // Allow overflow.
            unchecked
            {
                // Loop.
                for (int index = 0; index < iterations; ++index)
                {
                    // Subtract Max value, and 1.  Overflow each time.
                    intValue -= int.MaxValue;
                    intValue -= 2;

                    // Update bigint.
                    bigint = (bigint - int.MaxValue).Unchecked(4);
                    bigint = (bigint - 2).Unchecked(4);

                    // Are equal.
                    Assert.Equal(intValue, bigint);
                }
            }
        }
    }
}
