using MoralisUnity.Samples.Shared.Audio;
using UnityEngine;

namespace MoralisUnity.Samples.SimCityWeb3.View.UI
{
	/// <summary>
	/// Replace with comments...
	/// </summary>
	public class Scene_BaseUI : MonoBehaviour
	{
		// Properties -------------------------------------
		
		
		// Fields -----------------------------------------
		
		
		// Unity Methods ----------------------------------
		protected virtual void Awake ()
		{

		}
		
		
		protected virtual void Start()
		{

		}
		
		
		// General Methods --------------------------------
		/// <summary>
		/// Play generic click sound
		/// </summary>
		protected void PlayAudioClipClick()
		{
			SoundManager.Instance.PlayAudioClip(0);
		}
		
		// Event Handlers ---------------------------------
	}
}
