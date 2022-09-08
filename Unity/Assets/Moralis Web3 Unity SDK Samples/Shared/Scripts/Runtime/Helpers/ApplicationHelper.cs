using System;

namespace MoralisUnity.Samples.Shared.Templates
{
    /// <summary>
    /// The methods below are inspired by the Application class.
    /// However, adding an extension method as STATIC is not allowed. So here is a static helper method.
    /// </summary>
    public static class ApplicationHelper
    {
        // Properties -------------------------------------

		
        // Fields -----------------------------------------

		
        // General Methods --------------------------------
        /// <summary>
        /// Determines if code is running during the Unity TestRunner.
        /// </summary>
        /// <returns></returns>
        public static bool isTestRunner()
        {
            return Environment.StackTrace.Contains("UnityEngine.TestRunner");
        }
    }
}
