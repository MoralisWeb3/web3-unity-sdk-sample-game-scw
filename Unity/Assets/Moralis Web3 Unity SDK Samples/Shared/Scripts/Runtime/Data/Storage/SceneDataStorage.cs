#if UNITY_EDITOR
using System.Collections.Generic;
using MoralisUnity.Samples.Shared.Attributes;
using MoralisUnity.Samples.Shared.DesignPatterns.Creational.Singleton.CustomSingletonScriptableObject;
using MoralisUnity.Samples.SimCityWeb3;
using UnityEditor;
using UnityEngine;

namespace MoralisUnity.Samples.Shared.Data.Storage
{
	[ReferenceByGuid (Guid = "81d335281c7572a41b9d84c3deede854")]
	[CreateAssetMenu( menuName = SimCityWeb3Constants.PathCreateAssetMenu + "/" + Title,  fileName = Title)]
    public class SceneDataStorage: CustomSingletonScriptableObject<SceneDataStorage>
	{
        //  Properties ------------------------------------
        public List<SceneAsset> SceneAssets { get { return _sceneAssets; } }

        //  Fields ----------------------------------------
        private const string Title = "SceneDataStorage";

        [SerializeField]
        private List<SceneAsset> _sceneAssets = null;

        //  Methods ---------------------------------------
    }
}
#endif // UNITY_EDITOR