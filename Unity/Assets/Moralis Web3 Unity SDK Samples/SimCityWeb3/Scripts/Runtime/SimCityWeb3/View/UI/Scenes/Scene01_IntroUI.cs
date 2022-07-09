using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS1998
namespace MoralisUnity.Samples.SimCityWeb3.View.UI
{
	/// <summary>
	/// Main Entry Point For: Scene01_Intro
	/// </summary>
	public class Scene01_IntroUI : Scene_BaseUI
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

		[SerializeField] 
		private Button _hiddenQuitGameButton = null;

		
		private bool _hasMoralisUserAtMoralisSetup = false;
		
		// Unity Methods ----------------------------------
		protected override void Awake ()
		{
			base.Awake();

		}

		protected override async void Start()
		{
			base.Start();
			
			await SetupMoralisAsync();
			
			_authenticateButton.onClick.AddListener(AuthenticateButton_OnClicked);
			_settingsButton.onClick.AddListener(SettingsButton_OnClicked);
			_viewMapButtonUIText.onClick.AddListener(ViewMapButtonUIText_OnClicked);
			_hiddenQuitGameButton.onClick.AddListener(HiddenQuitGameButton_OnClicked);

			RefreshUIAsync();
		}
		
		// General Methods --------------------------------

		private async UniTask SetupMoralisAsync()
		{
			Moralis.Start();
			
			// This scene is allowed to run without a MoralisUser
			_hasMoralisUserAtMoralisSetup = await SimCityWeb3Singleton.Instance.HasMoralisUserAsync();
		}
		
		private async void RefreshUIAsync()
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
			SimCityWeb3Singleton.Instance.SimCityWeb3Controller.PlayAudioClipClick();
			SimCityWeb3Singleton.Instance.SimCityWeb3Controller.LoadAuthenticationSceneAsync();
		}
		
		
		private async void SettingsButton_OnClicked()
		{
			SimCityWeb3Singleton.Instance.SimCityWeb3Controller.PlayAudioClipClick();
			SimCityWeb3Singleton.Instance.SimCityWeb3Controller.LoadSettingsSceneAsync();
		}
		
		
		private void ViewMapButtonUIText_OnClicked()
		{
			SimCityWeb3Singleton.Instance.SimCityWeb3Controller.PlayAudioClipClick();
			SimCityWeb3Singleton.Instance.SimCityWeb3Controller.LoadGameSceneAsync();
		}

		
		private void HiddenQuitGameButton_OnClicked()
		{
			SimCityWeb3Singleton.Instance.SimCityWeb3Controller.QuitGame();
		}
	}
}
