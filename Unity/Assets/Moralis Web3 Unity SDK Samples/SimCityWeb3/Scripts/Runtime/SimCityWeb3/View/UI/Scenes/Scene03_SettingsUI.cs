using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS1998, CS4014
namespace MoralisUnity.Samples.SimCityWeb3.View.UI
{
	/// <summary>
	/// Main Entry Point For: Scene03_Settings
	/// </summary>
	public class Scene03_SettingsUI : Scene_BaseUI
	{
		// Properties -------------------------------------


		// Fields -----------------------------------------
		[SerializeField]
		private ScreenMessageUI _screenMessageUI = null;

		[SerializeField] 
		private Button _resetButtonUI = null;
		
		[SerializeField] 
		private Button _backButtonUI = null;

		private List<PropertyData> _propertyDatas = new List<PropertyData>();
		private string _elipsis_1 = string.Empty;
		private string _elipsis_2 = string.Empty;
		private const int DelayBetweenElipsis = 500;
		private const int DelayBetweenLoads = 5000; //load every 3 seconds
		private bool _isDestroyed = false;
		private bool _isResetPending = false;

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
			
			await SetupMoralisAsync();
			
			SimCityWeb3Singleton.Instantiate();

			// Call once immediatly
			LoadPropertyDatasAsync();
			RefreshUIAsync();

			// Start Auto Refresh
			AutoRefreshMessage();
			AutoRefreshData();
        }

        protected void OnDestroy()
        {
			_isDestroyed = true;
		}


		// General Methods --------------------------------
		private async UniTask AutoRefreshMessage()
		{
			_elipsis_1 = "";
			_elipsis_2 = "";
			UpdateMessageText();
			await UniTask.Delay(DelayBetweenElipsis);

			_elipsis_1 = " ";
			_elipsis_2 = ".";
			UpdateMessageText();
			await UniTask.Delay(DelayBetweenElipsis);

			_elipsis_1 = "  ";
			_elipsis_2 = "..";
			UpdateMessageText();
			await UniTask.Delay(DelayBetweenElipsis);

			_elipsis_1 = "   ";
			_elipsis_2 = "...";
			UpdateMessageText();
			await UniTask.Delay(DelayBetweenElipsis);

			// Restart Auto Refresh Message
			if (_isDestroyed)
			{
				return;
			}
			AutoRefreshMessage();
		}


		private async UniTask AutoRefreshData()
		{
			await UniTask.Delay(DelayBetweenLoads);

			// Restart Auto Refresh Data
			if (_isDestroyed)
			{
				return;
			}
			await LoadPropertyDatasAsync();
			AutoRefreshData();
		}


		private void UpdateMessageText()
		{
			if (_screenMessageUI == null)
            {
				//prevent nullref at OnDestroy
				return;
            }

			_screenMessageUI.MessageText.text = $"{_elipsis_1}Auto Refreshing{_elipsis_2}\n {_propertyDatas.Count} PropertyDatas Found";
		}


		private async UniTask SetupMoralisAsync()
		{
			Moralis.Start();
			
			bool hasMoralisUser = await SimCityWeb3Singleton.Instance.HasMoralisUserAsync();
			if (!hasMoralisUser)
			{
				throw new Exception(SimCityWeb3Constants.ErrorMoralisUserRequired);
			}
		}


		private async UniTask LoadPropertyDatasAsync()
		{
			if (_isDestroyed)
			{
				return;
			}

			//Debug.Log("LoadPropertyDatasAsync()");
			_propertyDatas = await SimCityWeb3Singleton.Instance.SimCityWeb3Controller.LoadPropertyDatasAsync();
			RefreshUIAsync();
		}


		private async void RefreshUIAsync()
		{
			// Check the user
			bool hasMoralisUser = await SimCityWeb3Singleton.Instance.HasMoralisUserAsync();

			// Check the Model
			bool hasAnyData = SimCityWeb3Singleton.Instance.HasAnyData();

			_screenMessageUI.IsVisible = !_isResetPending;
			_resetButtonUI.interactable = hasMoralisUser && hasAnyData && !_isResetPending;
			_backButtonUI.interactable = true;

		}

 

        // Event Handlers ---------------------------------
        private async void ResetButtonUI_OnClicked()
		{
			SimCityWeb3Singleton.Instance.SimCityWeb3Controller.PlayAudioClipClick();
			
			// Update to the service
			bool isVisibleInitial = SimCityWeb3Singleton.Instance.SimCityWeb3Controller.PendingMessageForDeletion.HasMessage;
			int delayDuration = SimCityWeb3Singleton.Instance.SimCityWeb3Controller.PendingMessageForDeletion.DelayDuration;
			string message = SimCityWeb3Singleton.Instance.SimCityWeb3Controller.PendingMessageForDeletion.Message;
			await SimCityWeb3Singleton.Instance.SimCityWeb3Controller.ShowLoadingDuringMethodAsync(
				isVisibleInitial,
				false,
				message, 
				async delegate( )
				{
					_isResetPending = true;
					RefreshUIAsync();
					await SimCityWeb3Singleton.Instance.ResetAllDataAsync();
					await UniTask.Delay(delayDuration);
					_isResetPending = false;
					RefreshUIAsync();
				});
			
			RefreshUIAsync();
		}
		
		private void BackButtonUI_OnClicked()
		{
			SimCityWeb3Singleton.Instance.SimCityWeb3Controller.PlayAudioClipClick();
			SimCityWeb3Singleton.Instance.SimCityWeb3Controller.LoadIntroSceneAsync();
		}
	}
}
