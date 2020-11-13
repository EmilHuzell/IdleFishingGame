using System.Numerics;

public static class PrettifyText {
    private static string Suffix(string currentGold) {
        var currentGoldString = Converters.BigIntToString(Gold.CurrentGold);
        var affix = (currentGoldString.Length - 1) / 3;

        switch (affix) {
            case 1:
                return "K";
            case 2:
                return "M";
            case 3:
                return "B";
            case 4:
                return "T";
            case 5:
                return "Q";
            case 6:
                return "qU";
            case 7:
                return "S";
            case 8:
                return "O";
            case 9:
                return "N";
            case 10:
                return "D";
            case 11:
                return "U";
            case 12:
                return "dU";
            case 13:
                return "tR";
            case 14:
                return "qUA";
            default:
                return "X";
        }
    }

    private static string FormatK(string currentGold) {
        var first = currentGold.Substring(0, currentGold.Length - 3);
        var decimals = currentGold.Substring(currentGold.Length - 3);

        return FormatString(first, decimals, "K");
    }

    private static string FormatString(string first, string decimals, string suffix) {
        return $"{first}.{decimals}{suffix}";
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
        var firstAmount = (currentGold.Length - 7) % 3 + 1;
        var firstString = currentGold.Substring(0, firstAmount);
        var decimals = currentGold.Substring(firstAmount, 3);

        return FormatString(firstString, decimals, Suffix(currentGold));
    }
}