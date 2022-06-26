using System;

namespace MoralisUnity.Samples.Shared.Data.Types
{
    /// <summary>
    /// Stores info to show "Please wait while..." messages
    /// </summary>
    [Serializable]
    public class PendingMessage
    {
        // Properties -------------------------------------
        public string Message { get { return _message; } }
        public bool HasMessage { get { return !string.IsNullOrEmpty(_message); } }
        public int DelayDuration { get { return _delayDuration; } }
        
        // Fields -----------------------------------------
        private string _message = null;
        private int _delayDuration = 0;

        // Initialization Methods -------------------------
        public PendingMessage(string message, int delayDuration)
        {
            _message = message;
            _delayDuration = delayDuration;
        }

        // General Methods --------------------------------


        // Event Handlers ---------------------------------
    }
}