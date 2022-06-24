using MoralisUnity.Samples.Shared.Audio;
using UnityEngine;

namespace MoralisUnity.Samples.SimCityWeb3.View.UI
{
	/// <summary>
	/// Replace with comments...
	/// </summary>
	public class BaseSceneView : MonoBehaviour
	{
		// Properties -------------------------------------
		public ScreenCoverUI ScreenCoverUI { get { return _screenCoverUI;}}
		
		
		// Fields -----------------------------------------
		[Header("Base References")]
		[SerializeField] 
		private ScreenCoverUI _screenCoverUI = null;
		
		// Unity Methods ----------------------------------
		protected virtual void Awake ()
		{

		}
		
		protected virtual void Start()
		{

		}
		
		
		// General Methods --------------------------------
		protected void PlayAudioClipClick()
		{
			SoundManager.Instance.PlayAudioClip(0);
		}
		
		
		// Event Handlers ---------------------------------
	}
}
