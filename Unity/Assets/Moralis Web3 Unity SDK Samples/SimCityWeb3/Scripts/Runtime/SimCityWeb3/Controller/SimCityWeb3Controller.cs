using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MoralisUnity.Samples.Shared.Components;
using MoralisUnity.Samples.Shared.Data.Types;
using MoralisUnity.Samples.SimCityWeb3.Model;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
using MoralisUnity.Samples.SimCityWeb3.Service;
using UnityEngine;

namespace MoralisUnity.Samples.SimCityWeb3.Controller
{
	/// <summary>
	/// Stores data for the game
	///		* See <see cref="SimCityWeb3Singleton"/> - Handles the core functionality of the game
	/// </summary>
	public class SimCityWeb3Controller
	{
		// Properties -------------------------------------
		public PendingMessage PendingMessageForDeletion { get { return _simCityWeb3Service.PendingMessageForDeletion; }}
		public PendingMessage PendingMessageForSave { get { return _simCityWeb3Service.PendingMessageForSave; }}


		// Fields -----------------------------------------
		private readonly SimCityWeb3Model _simCityWeb3Model = null;
		private readonly SimCityWeb3View _simCityWeb3View = null;
		private readonly ISimCityWeb3Service _simCityWeb3Service = null;


		// Initialization Methods -------------------------
		public SimCityWeb3Controller(
			SimCityWeb3Model simCityWeb3Model,
			SimCityWeb3View simCityWeb3View,
			ISimCityWeb3Service simCityWeb3Service)
		{
			_simCityWeb3Model = simCityWeb3Model;
			_simCityWeb3View = simCityWeb3View;
			_simCityWeb3Service = simCityWeb3Service;
			
			_simCityWeb3View.SceneManagerComponent.OnSceneLoadingEvent.AddListener(SceneManagerComponent_OnSceneLoadingEvent);
			_simCityWeb3View.SceneManagerComponent.OnSceneLoadedEvent.AddListener(SceneManagerComponent_OnSceneLoadedEvent);
		}




		// General Methods --------------------------------
		
		///////////////////////////////////////////
		// Related To: Model
		///////////////////////////////////////////
		public void AddPropertyData(PropertyData propertyData)
		{
			_simCityWeb3Model.AddPropertyData(propertyData);
		}
		
		
		public void RemovePropertyData(PropertyData propertyData)
		{
			_simCityWeb3Model.RemovePropertyData(propertyData);
		}

		
		///////////////////////////////////////////
		// Related To: View
		///////////////////////////////////////////
		public void PlayAudioClipClick()
		{
			_simCityWeb3View.PlayAudioClipClick();
		}
		
		
		public async void LoadIntroSceneAsync()
		{
			// Wait, So click sound is audible
			await UniTask.Delay(100);

			string sceneName = _simCityWeb3View.SimCityWeb3Configuration.IntroSceneData.SceneName;
			_simCityWeb3View.SceneManagerComponent.LoadScene(sceneName);
		}
		
		
		public async void LoadAuthenticationSceneAsync()
		{
			// Wait, So click sound is audible
			await UniTask.Delay(100);

			string sceneName = _simCityWeb3View.SimCityWeb3Configuration.AuthenticationSceneData.SceneName;
			_simCityWeb3View.SceneManagerComponent.LoadScene(sceneName);
		}
		
		
		public async void LoadSettingsSceneAsync()
		{
			// Wait, So click sound is audible
			await UniTask.Delay(100);

			string sceneName = _simCityWeb3View.SimCityWeb3Configuration.SettingsSceneData.SceneName;
			_simCityWeb3View.SceneManagerComponent.LoadScene(sceneName);
		}
		
		
		public async void LoadGameSceneAsync()
		{
			// Wait, So click sound is audible
			await UniTask.Delay(100);

			string sceneName = _simCityWeb3View.SimCityWeb3Configuration.GameSceneData.SceneName;
			_simCityWeb3View.SceneManagerComponent.LoadScene(sceneName);
		}

		
		public async void LoadPreviousSceneAsync()
		{
			// Wait, So click sound is audible before scene changes
			await UniTask.Delay(100);

			_simCityWeb3View.SceneManagerComponent.LoadScenePrevious();
		}
		
		
		public async UniTask ShowLoadingDuringMethodAsync(
			bool isVisibleInitial, 
			bool isVisibleFinal, 
			string message, 
			Func<UniTask> task)
		{
			await _simCityWeb3View.ShowLoadingDuringMethodAsync(isVisibleInitial, isVisibleFinal, message, task);
		}

		
		///////////////////////////////////////////
		// Related To: Service
		///////////////////////////////////////////
		public async UniTask<List<PropertyData>> LoadPropertyDatasAsync()
		{
			List<PropertyData> propertyDatas = await _simCityWeb3Service.LoadPropertyDatasAsync();

			_simCityWeb3Model.SetPropertyDatas(propertyDatas);

			return _simCityWeb3Model.GetPropertyDatas();
		}

		
		public async UniTask<PropertyData> SavePropertyDataAsync (PropertyData propertyData)
		{
			return await _simCityWeb3Service.SavePropertyDataAsync(propertyData);
		}
		
		
		public async UniTask DeletePropertyDataAsync(PropertyData propertyData)
		{
			await _simCityWeb3Service.DeletePropertyDataAsync(propertyData);
		}
		
		
		public async UniTask DeleteAllPropertyDatasAsync()
		{
			List<PropertyData> propertyDatas = _simCityWeb3Model.GetPropertyDatas();
			await _simCityWeb3Service.DeleteAllPropertyDatasAsync(propertyDatas);
		}


		// Event Handlers ---------------------------------
		private void SceneManagerComponent_OnSceneLoadingEvent(SceneManagerComponent sceneManagerComponent)
		{
			if (_simCityWeb3View.ScreenCoverUI.IsVisible)
			{
				_simCityWeb3View.ScreenCoverUI.IsVisible = false;
			}
		
		}
		
		private void SceneManagerComponent_OnSceneLoadedEvent(SceneManagerComponent sceneManagerComponent)
		{
			// Do anything?
		}


		public void QuitGame()
		{
			if (Application.isEditor)
			{
#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
#endif //UNITY_EDITOR
			}
			else
			{
				Application.Quit();
			}
		}
	}
}
