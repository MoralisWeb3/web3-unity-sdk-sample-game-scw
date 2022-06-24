
using MoralisUnity.Sdk.Constants;

namespace MoralisUnity.Samples.SimCityWeb3
{
    /// <summary>
    /// Helper Values
    /// </summary>
    public static class SimCityWeb3Constants
    {
        // Fields -----------------------------------------
        public const string ProjectName = "Buy The World";
        public const string PathCreateAssetMenu = MoralisConstants.PathMoralisCreateAssetMenu + "/Samples/" + ProjectName;
        
        // Display Text
        public const string Authenticate = "Authenticate";
        public const string Logout = "Logout";
        
        // Errors
        public static string ErrorMoralisUserRequired = "MoralisUser is required.";
        
    }
}