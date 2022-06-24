using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MoralisUnity.Samples.SimCityWeb3.Model;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
using MoralisUnity.Samples.SimCityWeb3.Service;
using MoralisUnity.Samples.SimCityWeb3.View.UI;
using UnityEngine;

namespace MoralisUnity.Samples.SimCityWeb3.Controller
{
	/// <summary>
	/// Replace with comments...
	/// </summary>
	public class SimCityWeb3Controller
	{
		// Properties -------------------------------------


		// Fields -----------------------------------------
		private SimCityWeb3Model _simCityWeb3Model;
		private SimCityWeb3View _simCityWeb3View;
		private ISimCityWeb3Service _simCityWeb3Service;


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
		public async UniTask<List<PropertyData>> LoadPropertyDatas()
		{
			List<PropertyData> propertyDatas = await _simCityWeb3Service.LoadPropertyDatas();

			Debug.Log($"LoadPropertyDatas() Count = {propertyDatas.Count}");
			_simCityWeb3Model.PropertyDatas = propertyDatas;

			return _simCityWeb3Model.PropertyDatas;
		}

		
		public async UniTask SavePropertyData (PropertyData propertyData)
		{
			await _simCityWeb3Service.SavePropertyData(propertyData);
			Debug.Log($"SavePropertyDatas() propertyData = {propertyData}");
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
		
		public void AddPropertyData(PropertyData propertyData)
		{
			_simCityWeb3Model.AddPropertyData(propertyData);
		}

		
		public void RemovePropertyData(PropertyData propertyData)
		{
			_simCityWeb3Model.RemovePropertyData(propertyData);
		}

		
		public void RenderPropertyDatas(Scene04_GameView scene04GameView)
		{
			foreach (PropertyData propertyDatas in _simCityWeb3Model.PropertyDatas)
			{
				scene04GameView.RenderPropertyData(propertyDatas, false);
			}
		}



		// Event Handlers ---------------------------------
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
			// Wait, So click sound is audible
			await UniTask.Delay(100);

			_simCityWeb3View.SceneManagerComponent.LoadScenePrevious();
		}

	}

}
