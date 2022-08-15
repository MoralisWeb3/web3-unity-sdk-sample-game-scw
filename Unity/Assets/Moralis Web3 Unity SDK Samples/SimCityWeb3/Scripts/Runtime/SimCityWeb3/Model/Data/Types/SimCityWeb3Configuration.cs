using MoralisUnity.Examples.Sdk.Shared.Data.Types.Storage;
using MoralisUnity.Samples.Shared.Attributes;
using MoralisUnity.Samples.Shared.Data.Types.Storage;
using MoralisUnity.Samples.Shared.DesignPatterns.Creational.Singleton.CustomSingletonScriptableObject;
using MoralisUnity.Samples.SimCityWeb3.View.UI;
using MoralisUnity.Sdk.Exceptions;
using MoralisUnity.Web3Api.Models;
using MyBox;
using UnityEngine;

#pragma warning disable 
namespace MoralisUnity.Samples.SimCityWeb3.Model.Data.Types
{
    /// <summary>
    /// Main configuration for the game. Click the instance of this class in the project to view/edit
    /// </summary>
    [ReferenceByGuid (Guid = "259c0de8152c6974e811ad9ec6e1cb58")]
    [CreateAssetMenu( menuName = SimCityWeb3Constants.PathCreateAssetMenu + "/" + Title,  fileName = Title)]
    public class SimCityWeb3Configuration : CustomSingletonScriptableObject<SimCityWeb3Configuration>
    {
        // Properties -------------------------------------
        public SimCityWeb3View SimCityWeb3ViewPrefab { get { return _simCityWeb3ViewPrefab; } }
        public MapPropertyUI MapPropertyUIPrefab { get { return _mapPropertyUIPrefab; } }
        public SceneDataStorage SceneDataStorage { get { return _sceneDataStorage;}}
        public SceneData IntroSceneData { get { return SceneDataStorage.SceneDatas[0];}}
        public SceneData AuthenticationSceneData { get { return SceneDataStorage.SceneDatas[1];}}
        public SceneData SettingsSceneData { get { return SceneDataStorage.SceneDatas[2];}}
        public SceneData GameSceneData { get { return SceneDataStorage.SceneDatas[3];}}
        public SimCityWeb3ServiceType SimCityWeb3ServiceType { get { return _simCityWeb3ServiceType;}}

        /// <summary>
        /// Convert <see cref="SimCityWeb3ChainList"/> to <see cref="Web3Api.Models.ChainList"/>
        /// </summary>
        public ChainList ChainList
        {
            get
            {
                ChainList chainList = ChainList.mumbai; //Arbitrary default
                switch (_simCityWeb3ChainList)
                {
                    case SimCityWeb3ChainList.PolygonMumbai:
                        chainList = ChainList.mumbai;
                        break;
                    case SimCityWeb3ChainList.CronosTestnet:
                        chainList = ChainList.cronos_testnet;
                        break;
                    default:
                        SwitchDefaultException.Throw(_simCityWeb3ChainList);
                        break;
                }

                return chainList;
            }
        }
        
        // Fields -----------------------------------------
        public const string Title = SimCityWeb3Constants.ProjectName + " Configuration";

        [Header("References (Project)")]
        [SerializeField]
        private SimCityWeb3View _simCityWeb3ViewPrefab = null;

        [SerializeField]
        private MapPropertyUI _mapPropertyUIPrefab = null;

        [SerializeField] 
        private SceneDataStorage _sceneDataStorage = null;

        [Header("Settings (Edit-Time Only)")]
        
        [Tooltip("For dev choose `Database` or `LocalDiskStorage`. For dev or production choose `Contract`.")]
        [SerializeField]
        private SimCityWeb3ServiceType _simCityWeb3ServiceType = SimCityWeb3ServiceType.Null;

        [ConditionalField(nameof(_simCityWeb3ServiceType), false, SimCityWeb3ServiceType.Contract)] 
        [SerializeField]
        private SimCityWeb3ChainList _simCityWeb3ChainList = SimCityWeb3ChainList.Null;
        
        
        // Unity Methods ----------------------------------

        
        // General Methods --------------------------------

		
        // Event Handlers ---------------------------------
    }
}