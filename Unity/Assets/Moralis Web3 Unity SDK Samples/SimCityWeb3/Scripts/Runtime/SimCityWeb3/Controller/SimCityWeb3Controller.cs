using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
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
		
		
		public async void LoadIntroScene()
		{
			// Wait, So click sound is audible
			await UniTask.Delay(100);

			string sceneName = _simCityWeb3View.SimCityWeb3Configuration.IntroSceneData.SceneName;
			_simCityWeb3View.SceneManagerComponent.LoadScene(sceneName);
		}
		
		
		public async void LoadAuthenticationScene()
		{
			// Wait, So click sound is audible
			await UniTask.Delay(100);

			string sceneName = _simCityWeb3View.SimCityWeb3Configuration.AuthenticationSceneData.SceneName;
			_simCityWeb3View.SceneManagerComponent.LoadScene(sceneName);
		}
		
		
		public async void LoadSettingsScene()
		{
			// Wait, So click sound is audible
			await UniTask.Delay(100);
			
			string sceneName = _simCityWeb3View.SimCityWeb3Configuration.SettingsSceneData.SceneName;
			_simCityWeb3View.SceneManagerComponent.LoadScene(sceneName);
		}
		
		
		public async void LoadGameScene()
		{
			// Wait, So click sound is audible
			await UniTask.Delay(100);

			string sceneName = _simCityWeb3View.SimCityWeb3Configuration.GameSceneData.SceneName;
			_simCityWeb3View.SceneManagerComponent.LoadScene(sceneName);
		}

		
		public async void LoadPreviousScene()
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
		public async UniTask<List<PropertyData>> LoadPropertyDatas()
		{
			List<PropertyData> propertyDatas = await _simCityWeb3Service.LoadPropertyDatas();

			Debug.Log($"LoadPropertyDatas() Count = {propertyDatas.Count}");
			_simCityWeb3Model.PropertyDatas = propertyDatas;

			return _simCityWeb3Model.PropertyDatas;
		}

		
		public async UniTask<PropertyData> SavePropertyData (PropertyData propertyData)
		{
			return await _simCityWeb3Service.SavePropertyData(propertyData);
		}
		
		
		public async UniTask DeletePropertyData(PropertyData propertyData)
		{
			await _simCityWeb3Service.DeletePropertyData(propertyData);
		}
		
		
		public async UniTask DeleteAllPropertyDatas()
		{
			List<PropertyData> propertyDatas = _simCityWeb3Model.PropertyDatas;
			await _simCityWeb3Service.DeleteAllPropertyDatas(propertyDatas);
		}

		
		public bool HasMessageForSavePropertyData()
		{
			return _simCityWeb3Service.HasMessageForDeletePropertyData();
		}
		
		
		public string GetMessageSavePropertyData()
		{
			return _simCityWeb3Service.GetMessageForDeletePropertyData();
		}
		
		
		public bool HasMessageForDeletePropertyData()
		{
			return _simCityWeb3Service.HasMessageForDeletePropertyData();
		}
		
		
		public string GetMessageForDeletePropertyData()
		{
			return _simCityWeb3Service.GetMessageForDeletePropertyData();
		}

		// Event Handlers ---------------------------------
	}
}
