using System.Text.RegularExpressions;

namespace MoralisUnity.Samples.Shared.Utilities
{
    /// <summary>
    /// Provides runtime validators
    /// </summary>
    public static class SharedValidators
    {
        /// <summary>
        /// Imperfect check to validate a Web3Address format
        /// https://ethereum.stackexchange.com/questions/15811/how-to-test-if-a-transactionhash-is-valid-using-web3
        /// </summary>
        /// <param name="tokenAddress"></param>
        /// <returns></returns>
        public static bool IsValidWeb3TokenAddressFormat(string tokenAddress)
        {
            // 66 Total Characters
            Regex regex = new Regex("^0x[0-9a-f]{64}$");
            return regex.Match(tokenAddress).Success;
        }
    }
}