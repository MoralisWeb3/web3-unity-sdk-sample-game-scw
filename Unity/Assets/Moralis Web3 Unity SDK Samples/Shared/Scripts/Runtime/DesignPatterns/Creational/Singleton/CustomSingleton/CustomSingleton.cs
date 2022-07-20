
using UnityEngine;
using UnityEngine.Events;

namespace MoralisUnity.Samples.Shared.DesignPatterns.Creational.Singleton.CustomSingleton
{
    public interface ICustomSingletonParent
    {
        //  Properties ------------------------------------
        
        //  General Methods -------------------------------
        void OnInstantiatedBase();
        void OnInstantiatedChild();
    }
    
    public abstract class CustomSingletonParent : System.Object, ICustomSingletonParent
    {
        //  Properties ------------------------------------
        public UnityEvent OnInstantiated = new UnityEvent();
        
        //  General Methods -------------------------------
        void ICustomSingletonParent.OnInstantiatedBase()
        {
            (this as ICustomSingletonParent).OnInstantiatedChild();
            OnInstantiated.Invoke();
            
        }
        
        void ICustomSingletonParent.OnInstantiatedChild()
        {
            //Override 
        }
    }

    //TODO: Add to Web3 Unity SDK - srivello
    /// <summary>
    /// Custom Singleton Pattern: See <a href="https://en.wikipedia.org/wiki/Singleton_pattern">https://en.wikipedia.org/wiki/Singleton_pattern</a>
    ///
    /// This version is designed for situations: Non-Monobehaviour, Non-ScriptableObject
    /// </summary>
    public abstract class CustomSingleton<T> : CustomSingletonParent where T : CustomSingletonParent, new()
    {
        //  Properties ------------------------------------

        
        //  Fields ----------------------------------------
        private static T _instance = default(T);
        static readonly object _padlock = new object();
        
        
        //  Initialization Methods-------------------------
        public static T Instance
        {
            get
            {
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new T();
                        (_instance as ICustomSingletonParent).OnInstantiatedBase();
                    }
 
                    return _instance;
                }
            }
        }
        
        public static T Instantiate()
        {
            return Instance;
        }
        
		
        //  General Methods -------------------------------
		
        
        //  Event Handlers --------------------------------
    }
}