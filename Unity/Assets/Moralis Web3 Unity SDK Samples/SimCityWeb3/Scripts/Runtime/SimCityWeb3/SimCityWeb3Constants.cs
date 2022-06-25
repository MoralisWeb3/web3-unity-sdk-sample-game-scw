
using MoralisUnity.Sdk.Constants;

namespace MoralisUnity.Samples.SimCityWeb3
{
    /// <summary>
    /// Helper Values
    /// </summary>
    public static class SimCityWeb3Constants
    {
        // Fields -----------------------------------------
        public const string ProjectName = "Sim City Web3";
        public const string PathCreateAssetMenu = MoralisConstants.PathMoralisSamplesCreateAssetMenu + "/" + ProjectName;
        
        // Display Text
        public const string Authenticate = "Authenticate";
        public const string Logout = "Logout";
        
        // Errors
        public static string ErrorMoralisUserRequired = "MoralisUser is required for this Scene. Stop this Scene. Choose another Scene.";
        
        ///////////////////////////////////////////
        // MenuItem Path
        ///////////////////////////////////////////
        public const string Moralis = "Moralis";
        public const string OpenReadMe = MoralisConstants.Open + " " + "ReadMe";
        private const string PathMoralisCreateAssetMenu = Moralis + "/" + MoralisConstants.Web3UnitySDK;
        private const string PathMoralisWindowMenu = "Window/" + Moralis + "/" + MoralisConstants.Web3UnitySDK;

        ///////////////////////////////////////////
        // MenuItem Priority
        ///////////////////////////////////////////

        // Skipping ">10" shows a horizontal divider line.
        public const int PriorityMoralisWindow_Primary = 10;
        public const int PriorityMoralisWindow_Secondary = 100;
        public const int PriorityMoralisWindow_Examples = 1000;
        public const int PriorityMoralisWindow_Samples = 10000;
        
    }
}