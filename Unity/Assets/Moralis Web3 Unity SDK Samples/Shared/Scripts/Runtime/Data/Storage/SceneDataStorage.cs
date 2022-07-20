using System.Collections.Generic;
using MoralisUnity.Samples.Shared.Attributes;
using MoralisUnity.Samples.Shared.Data.Types.Storage;
using MoralisUnity.Samples.Shared.DesignPatterns.Creational.Singleton.CustomSingletonScriptableObject;
using MoralisUnity.Samples.SimCityWeb3;
using UnityEngine;

#pragma warning disable CS0414
namespace MoralisUnity.Examples.Sdk.Shared.Data.Types.Storage
{
    [ReferenceByGuid (Guid = "81d335281c7572a41b9d84c3deede854")]
    [CreateAssetMenu( menuName = SimCityWeb3Constants.PathCreateAssetMenu + "/" + Title,  fileName = Title)]
    public class SceneDataStorage: CustomSingletonScriptableObject<SceneDataStorage>
    {
        //  Properties ------------------------------------
        public List<SceneData> SceneDatas { get { return _sceneDatas; } }

        //  Fields ----------------------------------------
        private const string Title = "SceneDataStorage";

        [Header("References (Project)")] 
        
        [InspectorComment("Note: The SceneDatas[0] will appear first in builds.")]
        [SerializeField]
        private string _dummy = "dummy";

        [SerializeField]
        private List<SceneData> _sceneDatas = null;

        //  Methods ---------------------------------------
    }
}
