using System.Numerics;

public static class Converters {
    public static string BigIntToString(BigInteger bigIntegerToConvert) {
        return bigIntegerToConvert.ToString();
    }
    
    public static BigInteger StringToBigInt(string stringToConvert) {
        BigInteger.TryParse(stringToConvert, out var bigInt);
        return bigInt;
    }
}