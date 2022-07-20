using System;
using UnityEngine;

#pragma warning disable CS0414
namespace MoralisUnity.Samples.Shared.Data.Types.Storage
{
    /// <summary>
    /// Stores info about Scenes
    /// </summary>
    [Serializable]
    public class SceneData
    {
        // Properties -------------------------------------

        public string SceneName
        {
            get
            {
                return _sceneName;
            }
        }

#if UNITY_EDITOR
        // See NOTE below
        public UnityEngine.Object Scene
        {
            get
            {
                return _scene;
            }
        }
#endif

        // Fields -----------------------------------------

        /// <summary>
        /// NOTE:
        /// * The _scene provides drag and drop in the editor. But its not available in a Windows build.
        /// * The _scenePath is available in a windows build
        /// </summary>
        [SerializeField] 
        private UnityEngine.Object _scene = null;

        [SerializeField]
        private string _sceneName = String.Empty;

        // General Methods --------------------------------
        public override string ToString()
        {
            return $"[(SceneData) (_sceneName = {_sceneName})]";
        }

        // Event Handlers ---------------------------------
    }
}