using System.Text.RegularExpressions;

namespace MoralisUnity.Samples.Shared.Utilities
{
    /// <summary>
    /// Provides runtime validators
    /// </summary>
    public static class SharedValidators
    {
        public static bool IsValidWeb3TokenAddressFormat(string tokenAddress)
        {
            // 66 Total Characters
            Regex regex = new Regex("^0x[0-9a-f]{64}$");
            return regex.Match(tokenAddress).Success;
        }
    }
}