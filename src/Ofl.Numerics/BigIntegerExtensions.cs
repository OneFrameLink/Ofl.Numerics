using System;
using System.Linq;
using System.Numerics;

namespace Ofl.Numerics
{
    public static class BigIntegerExtensions
    {
        public static BigInteger Unchecked(this BigInteger value, int bytes)
        {
            // Validate parameters.
            if (bytes <= 0)
                throw new ArgumentOutOfRangeException(nameof(bytes), bytes, 
                    $"The { nameof(bytes) } parameter must be a positive value.");

            // SHORTCUT: If value is zero, then just return zero, zero fits in any situation.
            if (value == 0) return value;

            // Get the byte count.
            int byteCount = value.GetByteCount();

            // If the length of the bytes is less than the bits / 8 then
            // return the big integer.
            if (byteCount <= bytes) return value;

            // Allocate a span on the stack to copy the big int into.
            Span<byte> byteArray = stackalloc byte[byteCount];

            // Copy.
            // TODO: Check length and return value?
            value.TryWriteBytes(byteArray, out _);

            // Slice the bytes.
            byteArray = byteArray.Slice(0, bytes);
            
            // Take the last bytes.
            return new BigInteger(byteArray);
        }
    }
}
