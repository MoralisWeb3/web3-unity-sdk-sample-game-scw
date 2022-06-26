using UnityEngine;

namespace MoralisUnity.Samples.SimCityWeb3.View.UI
{
	/// <summary>
	/// Replace with comments...
	/// </summary>
	public class MapPropertyUISpawnPoint : MonoBehaviour
	{
		// Events -----------------------------------------
		
		
		// Properties -------------------------------------
		[SerializeField] 
		private GameObject _origin = null;
		
		// Fields -----------------------------------------
		
		
		// Unity Methods ----------------------------------
		protected void Awake()
		{
			_origin.SetActive(false);
		}

		// General Methods --------------------------------
	
		
		// Event Handlers ---------------------------------
	}
}
