using UnityEngine;

namespace MoralisUnity.Samples.Shared.DesignPatterns.Creational.Singleton.SingletonScriptableObject2
{
    /// <summary>
    /// TODO: Update this implementation per inner comments
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
}