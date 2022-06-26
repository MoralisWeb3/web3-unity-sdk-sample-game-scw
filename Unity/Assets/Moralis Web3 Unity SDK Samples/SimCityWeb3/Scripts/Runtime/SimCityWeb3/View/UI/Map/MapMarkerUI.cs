using UnityEngine;

namespace MoralisUnity.Samples.SimCityWeb3.View.UI
{
	/// <summary>
	/// Replace with comments...
	/// </summary>
	public class MapMarkerUI : MonoBehaviour
	{
		// Properties -------------------------------------
		
		
		// Fields -----------------------------------------
		[SerializeField]
		private GameObject _topCube;
		
		
		// Unity Methods ----------------------------------
		protected void Start()
		{
		}
		
		
		protected void Update()
		{
			_topCube.transform.Rotate(new Vector3(0,0.5f, 0), Space.World);
		}
		
		
		// General Methods --------------------------------
		
		
		// Event Handlers ---------------------------------
	}
}
