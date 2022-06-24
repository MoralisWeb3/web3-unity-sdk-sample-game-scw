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
		private List<PropertyData> _propertydatasAtStart = new List<PropertyData>();
		
		
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

			_propertydatasAtStart = 
				await SimCityWeb3Singleton.Instance.SimCityWeb3Controller.LoadPropertyDatas();
			
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
			bool hasPropertyDatas = _propertydatasAtStart.Count > 0;

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
