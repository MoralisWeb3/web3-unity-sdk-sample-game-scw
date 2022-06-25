using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS1998
namespace MoralisUnity.Samples.SimCityWeb3.View.UI
{
	/// <summary>
	/// Replace with comments...
	/// </summary>
	public class Scene01_IntroView : BaseSceneView
	{
		// Properties -------------------------------------
		
		// Fields -----------------------------------------
		[Header("References (Scene)")] 
		[SerializeField] 
		private Button _authenticateButton = null;
		
		[SerializeField] 
		private Button _settingsButton = null;

		[SerializeField] 
		private Button _viewMapButtonUIText = null;
		
		private bool _hasMoralisUserAtMoralisSetup = false;
		
		// Unity Methods ----------------------------------
		protected override void Awake ()
		{
			base.Awake();

		}

		protected override async void Start()
		{
			base.Start();
			
			await SetupMoralis();
			
			_authenticateButton.onClick.AddListener(AuthenticateButton_OnClicked);
			_settingsButton.onClick.AddListener(SettingsButton_OnClicked);
			_viewMapButtonUIText.onClick.AddListener(ViewMapButtonUIText_OnClicked);

			RefreshUI();
		}
		
		// General Methods --------------------------------

		private async UniTask SetupMoralis()
		{
			Moralis.Start();
			
			// This scene is allowed to run without a MoralisUser
			_hasMoralisUserAtMoralisSetup = await SimCityWeb3Singleton.Instance.HasMoralisUserAsync();
		}
		
		private async void RefreshUI()
		{
			//
			_authenticateButton.interactable = true;
			_settingsButton.interactable = _hasMoralisUserAtMoralisSetup;
			_viewMapButtonUIText.interactable = _hasMoralisUserAtMoralisSetup; 
			
			//
			SimCityWeb3Helper.SetButtonText(_authenticateButton, 
				_hasMoralisUserAtMoralisSetup, 
				SimCityWeb3Constants.Logout, 
				SimCityWeb3Constants.Authenticate);

		}
		
		// Event Handlers ---------------------------------
		private void AuthenticateButton_OnClicked()
		{
			PlayAudioClipClick();
			
			SimCityWeb3Singleton.Instance.SimCityWeb3Controller.LoadAuthenticationScene();
		}
		
		
		private async void SettingsButton_OnClicked()
		{

			PlayAudioClipClick();
		
			SimCityWeb3Singleton.Instance.SimCityWeb3Controller.LoadSettingsScene();
		}
		
		
		private void ViewMapButtonUIText_OnClicked()
		{
			PlayAudioClipClick();
			
			SimCityWeb3Singleton.Instance.SimCityWeb3Controller.LoadGameScene();
		}
		
	}
}
