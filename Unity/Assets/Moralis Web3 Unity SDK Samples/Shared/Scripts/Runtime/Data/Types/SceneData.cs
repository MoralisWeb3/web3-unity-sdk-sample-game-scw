using System;
using UnityEngine;

namespace MoralisUnity.Samples.Shared.Data.Types
{
	/// <summary>
	/// Stores info about Scenes
	/// </summary>
	[Serializable]
	public class SceneData
	{
		// Properties -------------------------------------
		public string SceneName
		{
			get
			{
				return _scene.name;
			}
		}

		// Fields -----------------------------------------
		
		[SerializeField] 
		private UnityEngine.Object _scene = null;


		// General Methods --------------------------------


		// Event Handlers ---------------------------------
	}
}
