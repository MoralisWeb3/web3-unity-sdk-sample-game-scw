using System.Collections.Generic;
using MoralisUnity.Samples.Shared.Attributes;
using MoralisUnity.Samples.Shared.Data.Types.Storage;
using MoralisUnity.Samples.Shared.DesignPatterns.Creational.Singleton.CustomSingletonScriptableObject;
using MoralisUnity.Samples.SimCityWeb3.View.UI;
using UnityEngine;

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
        public SceneData IntroSceneData { get { return _introSceneData;}}
        public SceneData AuthenticationSceneData { get { return _authenticationSceneData;}}
        public SceneData SettingsSceneData { get { return _settingsSceneData;}}
        public SceneData GameSceneData { get { return _gameSceneData;}}
        public SimCityWeb3ServiceType SimCityWeb3ServiceType { get { return _simCityWeb3ServiceType;}}

        [SerializeField]
        private List<SceneData> _sceneDatas = null;

        // Fields -----------------------------------------
        [Header("References (Project)")]
        [SerializeField]
        private SimCityWeb3View _simCityWeb3ViewPrefab = null;

        [SerializeField]
        private MapPropertyUI _mapPropertyUIPrefab = null;

        [SerializeField] 
        private SceneData _introSceneData = null;

        [SerializeField] 
        private SceneData _authenticationSceneData = null;

        [SerializeField] 
        private SceneData _settingsSceneData = null;

        [SerializeField] 
        private SceneData _gameSceneData = null;

        [Header("Settings (Edit-Time Only)")]
        
        [Tooltip("Use either Moralis Database (dev) or Moralis Web3 (prod)")]
        [SerializeField]
        public SimCityWeb3ServiceType _simCityWeb3ServiceType = SimCityWeb3ServiceType.Null;

        public const string Title = SimCityWeb3Constants.ProjectName + " Configuration";

        
        // Unity Methods ----------------------------------

        
        // General Methods --------------------------------

		
        // Event Handlers ---------------------------------
    }
}