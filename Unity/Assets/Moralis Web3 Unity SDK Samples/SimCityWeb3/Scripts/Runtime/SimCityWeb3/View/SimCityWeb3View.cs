using MoralisUnity.Samples.SimCityWeb3.Model.Data;
using MoralisUnity.Samples.Shared.Components;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
using UnityEngine;

namespace MoralisUnity.Samples.SimCityWeb3.Model
{
	/// <summary>
	/// Handles the UI for the game
	///		* See <see cref="SimCityWeb3Singleton"/>
	/// </summary>
	public class SimCityWeb3View : MonoBehaviour
	{
		// Properties -------------------------------------
		public SimCityWeb3Configuration SimCityWeb3Configuration { get { return _simCityWeb3Configuration; } }

		public SceneManagerComponent SceneManagerComponent { get { return _sceneManagerComponent;}}

		
		// Fields -----------------------------------------
		[Header("References (Scene)")] 
		[SerializeField] 
		private SceneManagerComponent _sceneManagerComponent = null;
		
		[Header("References (Project)")] 
		[SerializeField]
		private SimCityWeb3Configuration _simCityWeb3Configuration = null;
	
		
		// Initialization Methods -------------------------
		
		public SimCityWeb3View()
		{
		}

		
		// General Methods --------------------------------
		public string SamplePublicMethod(string message)
		{
			return message;
		}

		
		// Event Handlers ---------------------------------
		public void Target_OnCompleted(string message)
		{

		}


	}
}
