using GD.MinMaxSlider;
using MoralisUnity.Samples.Shared.Data.Types;
using MoralisUnity.Samples.SimCityWeb3.View.UI;
using UnityEngine;

namespace MoralisUnity.Samples.SimCityWeb3.Model.Data.Types
{
    
    /// <summary>
    /// TODO: Move this to another file after updating its implementation per innner comments
    /// </summary>
    public class SingletonScriptableObject2<T> :ScriptableObject  where T : ScriptableObject
    {
        private static T _Instance = null;
        
        public static bool IsInstantiated
        {
            get
            {
                return _Instance != null;
            }
        }

        public static T Instance
        {
            get
            {
                if (!IsInstantiated)
                {
                    _Instance = Instantiate();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }

        private static T Instantiate()
        {
            //TODO: Refactor this parent class to be general
            //and put this child path in the child class
            T instance = Resources.Load<T>("SimCityWeb3Configuration");
            return instance;
        }
    }
    
    /// <summary>
    /// Replace with comments...
    /// </summary>
    [CreateAssetMenu( menuName = SimCityWeb3Constants.PathCreateAssetMenu + "/" + Title,  fileName = Title)]
    public class SimCityWeb3Configuration : SingletonScriptableObject2<SimCityWeb3Configuration>
    {
		
        // Properties -------------------------------------
        public SimCityWeb3View SimCityWeb3ViewPrefab { get { return _simCityWeb3ViewPrefab; } }
        public MapPropertyUI MapPropertyUIPrefab { get { return _mapPropertyUIPrefab; } }
        public SceneData IntroSceneData { get { return _introSceneData;}}
        public SceneData AuthenticationSceneData { get { return _authenticationSceneData;}}
        public SceneData SettingsSceneData { get { return _settingsSceneData;}}
        public SceneData GameSceneData { get { return _gameSceneData;}}
        public SimCityWeb3ServiceType SimCityWeb3ServiceType { get { return _simCityWeb3ServiceType;}}


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

        
        //TODO: Use this at runtime or remove it
        [Tooltip("Defines the MapZoomLevel for map rendering")]
        [SerializeField] 
        [MinMaxSlider(3, 10)] 
        private Vector2 _mapZoomOverall = new Vector2(3, 10);
        
        //TODO: Use this at runtime or remove it
        [Tooltip("Defines the MapZoomLevel for property rendering")]
        [SerializeField] 
        [MinMaxSlider(3, 10)] 
        private Vector2 _mapZoomForProperty = new Vector2(3,10);


        
        private const string Title = "SimCityWeb3Configuration";

        // Unity Methods ----------------------------------
        protected void OnValidate()
        {
            // Keep _mapZoomLevelRangeForProperty within _mapZoomLevelRange
            float min = _mapZoomForProperty.x;
            float max = _mapZoomForProperty.y;

            min = Mathf.Clamp(min,_mapZoomOverall.x, _mapZoomOverall.y);
            max = Mathf.Clamp(max,_mapZoomOverall.x, _mapZoomOverall.y);

            _mapZoomForProperty = new Vector2(min, max);
        }


        // General Methods --------------------------------
        public string SamplePublicMethod(string message)
        {
            return message;
        }

		
        // Event Handlers ---------------------------------
    }
}