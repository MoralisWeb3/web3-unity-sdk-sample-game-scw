using System;
using MoralisUnity.Samples.Shared.Attributes;
using UnityEngine;

namespace MoralisUnity.Samples.Shared.Data.Types
{
	/// <summary>
	/// Replace with comments...
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
