using System;
using Cysharp.Threading.Tasks;
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
		/// <summary>
		/// Play generic click sound
		/// </summary>
		protected void PlayAudioClipClick()
		{
			SoundManager.Instance.PlayAudioClip(0);
		}
		
		
		/// <summary>
		/// Show a loading screen, during method execution
		/// </summary>
		protected async UniTask ShowLoadingDuringMethodAsync(
			bool isVisibleInitial, 
			bool isVisibleFinal, 
			string message, 
			Func<UniTask> task)
		{
			//Debug.Log($"START {message} ");
			ScreenCoverUI.IsVisible = isVisibleInitial;	
			ScreenCoverUI.MessageText.text = message;
			await task();
			ScreenCoverUI.IsVisible = isVisibleFinal;
			//Debug.Log($"END {message} ");
		}

		
		// Event Handlers ---------------------------------
	}
}
