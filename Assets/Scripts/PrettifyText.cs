using System.Numerics;
using UnityEngine.UI;


public static class PrettifyText {
        
    //I've come to the conclusion that This class will be big enough be used as it's own class.
    //This is why i put it in a separate class.
        
    //TODO: Method which returns K, M, B, T, Q for starters.
    //This method should be a switch or an enum perhaps.
    
    //TODO: Find a way to get the desired suffix based on what amount of numbers we have ATM

    private static char Suffix(string currentGold) {
        var currentGoldString = Converters.BigIntToString(Gold.CurrentGold);
        int affix = (currentGoldString.Length - 1) / 3;

        switch (affix) {
            case 1:
                return 'K';
            case 2:
                return 'M';
            case 3:
                return 'B';
            case 4:
                return 'T';
            case 5:
                return 'Q';
            default:
                return 'X';
        }
    }

    private static string FormatK(string currentGold) {
        string first = currentGold.Substring(0, currentGold.Length - 3);
        string decimals = currentGold.Substring(currentGold.Length - 3);

        return FormatString(first, decimals, 'K');
    }

    private static string FormatString(string first, string decimals, char suffix) {
        return string.Format("{0}.{1}{2}", first, decimals, suffix);
    }

    public static string Format(BigInteger gold) {
        var goldText = Converters.BigIntToString(gold);

        if (goldText.Length < 5) {
            return goldText;
        }

        if (goldText.Length < 7) {
            return FormatK(goldText);
        }

        return FormatDefault(goldText);
    }

    private static string FormatDefault(string currentGold) {
        int firstAmount = (currentGold.Length - 7) % 3 + 1;
        string firstString = currentGold.Substring(0, firstAmount);
        string decimals = currentGold.Substring(firstAmount, 3);

        return FormatString(firstString, decimals, Suffix(currentGold));
    }
    
    #region Old Prettifier 2

    // public static string PrettifyText(BigInteger bigIntegerToConvert) {
    //     var typesOfNumbers = new[] {"", "K", "M"};
    //
    //     BigInteger rate = bigIntegerToConvert;
    //     
    //     var type = 0;
    //
    //     while (rate >= 1000) {
    //         rate /= 1000;
    //         type++;
    //     }
    //
    //     //TODO: add "," and the 2 and 3rd number from currentgold if size is 1
    //     //TODO: Add "," and the 3rd and 4th number from currentgold if size is 2
    //     //TODO: add "," and the 4th and fifth number from currentgold if size is 3
    //     
    //     if (rate > 1 && type != 0) {
    //         return $"{rate} {typesOfNumbers[type]}";
    //     }
    //     
    //     return $"{rate} {typesOfNumbers[type]}";
    // }

    #endregion
    #region Old Prettifier
    // public static string PrettifyText(BigInteger big) {
    //
    //     if (big <= 999) {
    //         return BigIntToString(big);
    //     }
    //     else if (big >= 10000 && big <= 99999) {
    //         var math = big / 10;
    //         var final = BigIntToString(math).Insert(2, ".");
    //         return final + 'K';
    //     }
    //     else if (big >= 100000 && big <= 999999) {
    //         var math = big / 10;
    //         var final = BigIntToString(math).Insert(3, ".");
    //         return final + 'K';
    //     }
    //     else if (big >= 1000000 && big <= 9999999) {
    //         var math = big / 1000;
    //         var final = BigIntToString(math).Insert(1, ".");
    //         return final + 'M';
    //     }
    //     else if (big >= 10000000 && big <= 99999999) {
    //         var math = big / 10000;
    //         var final = BigIntToString(math).Insert(2, ".");
    //         return final + 'M';
    //     }
    //     else if (big >= 100000000 && big <= 999999999) {
    //         var math = big / 10000;
    //         var final = BigIntToString(math).Insert(3, ".");
    //         return final + 'M';
    //     }
    //     else if (big >= 1000000000 && big <= 9999999999) {
    //         var math = big / 1000000;
    //         var final = BigIntToString(math).Insert(1, ".");
    //         return final + 'B';
    //     }
    //     else if (big >= 10000000000 && big <= 99999999999) {
    //         var math = big / 1000000;
    //         var final = BigIntToString(math).Insert(1, ".");
    //         return final + 'B';
    //     }
    //
    //     return BigIntToString(big);
    // }
    #endregion
}