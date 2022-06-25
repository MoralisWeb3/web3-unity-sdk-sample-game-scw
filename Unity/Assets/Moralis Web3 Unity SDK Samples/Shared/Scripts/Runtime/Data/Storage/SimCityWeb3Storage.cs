#if UNITY_EDITOR
using System.Collections.Generic;
using MoralisUnity.Samples.Shared.DesignPatterns.Creational.Singleton.CustomSingletonScriptableObject;
using MoralisUnity.Samples.SimCityWeb3;
using UnityEditor;
using UnityEngine;

namespace MoralisUnity.Samples.Shared.Data.Storage
{

	[CreateAssetMenu( menuName = SimCityWeb3Constants.PathCreateAssetMenu + "/" + Title,  fileName = Title)]
    public class SimCityWeb3Storage: CustomSingletonScriptableObject<SimCityWeb3Storage>
	{
        //  Properties ------------------------------------
        public List<SceneAsset> SceneAssets { get { return _sceneAssets; } }

        //  Fields ----------------------------------------
        private const string Title = SimCityWeb3Constants.ProjectName + " Storage";

        [SerializeField]
        private List<SceneAsset> _sceneAssets = null;

        //  Methods ---------------------------------------
    }
}
#endif // UNITY_EDITOR