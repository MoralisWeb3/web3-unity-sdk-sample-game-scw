using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace MoralisUnity.Samples.Shared.Components
{
	public class SceneManagerComponentUnityEvent : UnityEvent<SceneManagerComponent> {}
	
	/// <summary>
	/// Determines "was the active scene loaded directly?
	/// * (true) Loaded directly
	/// * (false) Loaded indirectly at runtime
	/// </summary>
	public class SceneManagerComponent : MonoBehaviour
	{
		// Events -----------------------------------------
		public SceneManagerComponentUnityEvent OnSceneLoadingEvent = new SceneManagerComponentUnityEvent();
		public SceneManagerComponentUnityEvent OnSceneLoadedEvent = new SceneManagerComponentUnityEvent();
		
		// Properties -------------------------------------

		// Fields -----------------------------------------
		private static string _sceneNameLoadedDirectly = "";
		private static string _sceneNamePrevious = "";

		// Unity Methods ----------------------------------
		protected void Awake ()
		{
			_sceneNameLoadedDirectly = SceneManager.GetActiveScene().name;
		}
		
		protected void Start ()
		{
			SceneManager.sceneLoaded += SceneManager_OnSceneLoaded;
		}



		// General Methods --------------------------------
		public bool WasActiveSceneLoadedDirectly()
		{
			return _sceneNameLoadedDirectly == SceneManager.GetActiveScene().name;
		}
		
		public void LoadScenePrevious()
		{
			LoadScene(_sceneNamePrevious);
		}
		
		public void LoadScene(string sceneName)
		{
			if (string.IsNullOrEmpty(sceneName))
			{
				Debug.LogWarning($"Cannot LoadScene() when sceneName={sceneName}. That is ok.");
				return;
			}
			
			_sceneNamePrevious = SceneManager.GetActiveScene().name;
			OnSceneLoadingEvent.Invoke(this);
			SceneManager.LoadScene(sceneName);
		}
		
		// Event Handlers ---------------------------------
		private void SceneManager_OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
		{
			OnSceneLoadedEvent.Invoke(this);
		}
	}
}
