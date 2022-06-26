using System;
using Cysharp.Threading.Tasks;
using MoralisUnity.Samples.Shared.Audio;
using MoralisUnity.Samples.Shared.Components;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
using MoralisUnity.Samples.SimCityWeb3.View.UI;
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
		public ScreenCoverUI ScreenCoverUI { get { return _screenCoverUI;}}
		
		
		// Fields -----------------------------------------
		[Header("References (Scene)")] 
		[SerializeField] 
		private SceneManagerComponent _sceneManagerComponent = null;
		
		[SerializeField] 
		private ScreenCoverUI _screenCoverUI = null;

		[Header("References (Project)")] 
		[SerializeField]
		private SimCityWeb3Configuration _simCityWeb3Configuration = null;
	
		// General Methods --------------------------------
		/// <summary>
		/// Show a loading screen, during method execution
		/// </summary>
		public async UniTask ShowLoadingDuringMethodAsync(
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

		/// <summary>
		/// Play generic click sound
		/// </summary>
		public void PlayAudioClipClick()
		{
			SoundManager.Instance.PlayAudioClip(0);
		}
		
		// Event Handlers ---------------------------------

	}
}
