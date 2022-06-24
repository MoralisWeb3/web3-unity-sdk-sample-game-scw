using UnityEngine;
using UnityEngine.SceneManagement;

namespace MoralisUnity.Samples.Shared.Components
{
	/// <summary>
	/// Determines "was the active scene loaded directly?
	/// * (true) Loaded directly
	/// * (false) Loaded indirectly at runtime
	/// </summary>
	public class SceneManagerComponent : MonoBehaviour
	{
		// Properties -------------------------------------

		// Fields -----------------------------------------
		private static string _sceneNameLoadedDirectly = "";
		private static string _sceneNamePrevious = "";

		// Unity Methods ----------------------------------
		protected void Awake ()
		{
			_sceneNameLoadedDirectly = SceneManager.GetActiveScene().name;
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
		
		// Event Handlers ---------------------------------

		public void LoadScene(string sceneName)
		{
			if (string.IsNullOrEmpty(sceneName))
			{
				Debug.LogWarning($"Cannot LoadScene() when sceneName={sceneName}. That is ok.");
				return;
			}
			
			_sceneNamePrevious = SceneManager.GetActiveScene().name;
			SceneManager.LoadScene(sceneName);
		}
	}
}
