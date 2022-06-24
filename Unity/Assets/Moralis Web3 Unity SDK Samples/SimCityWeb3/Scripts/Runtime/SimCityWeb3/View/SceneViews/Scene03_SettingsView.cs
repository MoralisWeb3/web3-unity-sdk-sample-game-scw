using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS1998
namespace MoralisUnity.Samples.SimCityWeb3.View.UI
{
	/// <summary>
	/// Replace with comments...
	/// </summary>
	public class Scene03_SettingsView : BaseSceneView
	{
		// Properties -------------------------------------
		
		
		// Fields -----------------------------------------
		[SerializeField] 
		private Button _resetButtonUI = null;
		
		[SerializeField] 
		private Button _backButtonUI = null;

		
		// Unity Methods ----------------------------------
		protected override void Awake ()
		{
			base.Awake();
			_resetButtonUI.onClick.AddListener(ResetButtonUI_OnClicked);
			_backButtonUI.onClick.AddListener(BackButtonUI_OnClicked);
		}

		protected override async void Start()
		{
			base.Start();
			
			await SetupMoralis();
			
			SimCityWeb3Singleton.Instantiate();

			RefreshUI();
		}
		
		// General Methods --------------------------------
		private async UniTask SetupMoralis()
		{
			Moralis.Start();
		}

		private async void RefreshUI()
		{
			// Check the user
			bool hasMoralisUser = await SimCityWeb3Singleton.Instance.HasMoralisUserAsync();
			
			// Populate the Model With Live Data
			await SimCityWeb3Singleton.Instance.SimCityWeb3Controller.LoadPropertyDatas();
			
			// Check the Model
			bool hasAnyData = SimCityWeb3Singleton.Instance.HasAnyData();
			
			_resetButtonUI.interactable = hasMoralisUser && hasAnyData;
			_backButtonUI.interactable = true;

		}
		
		// Event Handlers ---------------------------------
		private async void ResetButtonUI_OnClicked()
		{
			PlayAudioClipClick();
			
			await SimCityWeb3Singleton.Instance.ResetAllData();
			
			RefreshUI();
		}
		
		private void BackButtonUI_OnClicked()
		{
			PlayAudioClipClick();
			SimCityWeb3Singleton.Instance.SimCityWeb3Controller.LoadIntroScene();
		}
	}
}
