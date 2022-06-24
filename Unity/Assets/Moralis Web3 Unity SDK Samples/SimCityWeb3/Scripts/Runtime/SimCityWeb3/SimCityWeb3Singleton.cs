using Cysharp.Threading.Tasks;
using MoralisUnity.Platform.Objects;
using MoralisUnity.Samples.SimCityWeb3.Model.Data;
using MoralisUnity.Samples.Shared.DesignPatterns.Creational.Singleton.SingletonMonobehaviour;
using MoralisUnity.Samples.SimCityWeb3.Controller;
using MoralisUnity.Samples.SimCityWeb3.Model;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
using MoralisUnity.Samples.SimCityWeb3.Service;

namespace MoralisUnity.Samples.SimCityWeb3
{
	/// <summary>
	/// Replace with comments...
	/// </summary>
	public class SimCityWeb3Singleton : BaseGameSingletonMonobehaviour<SimCityWeb3Singleton>
	{
		// Properties -------------------------------------
		private SimCityWeb3Model SimCityWeb3Model  { get { return _simCityWeb3Model; }}
		private SimCityWeb3View SimCityWeb3View  { get { return _simCityWeb3View; }}
		public SimCityWeb3Controller SimCityWeb3Controller  { get { return _simCityWeb3Controller; }}
		private ISimCityWeb3Service SimCityWeb3Service  { get { return _simCityWeb3Service; }}
		
		// Fields -----------------------------------------
		private SimCityWeb3Model _simCityWeb3Model;
		private SimCityWeb3View _simCityWeb3View;
		private SimCityWeb3Controller _simCityWeb3Controller;
		private ISimCityWeb3Service _simCityWeb3Service;
		
		// Initialization Methods -------------------------
		public override void InstantiateCompleted()
		{
			// Model
			_simCityWeb3Model = new SimCityWeb3Model();
			
			// View
			SimCityWeb3View prefab = SimCityWeb3Configuration.Instance.SimCityWeb3ViewPrefab;
			_simCityWeb3View = SimCityWeb3Helper.InstantiatePrefab (prefab, transform);
			
			// Service
			SimCityWeb3ServiceType simCityWeb3ServiceType = 
				SimCityWeb3Configuration.Instance.SimCityWeb3ServiceType;
			
			_simCityWeb3Service = new SimCityWeb3ServiceFactory().
				Create(simCityWeb3ServiceType);

			// Controller
			_simCityWeb3Controller = new SimCityWeb3Controller(
				_simCityWeb3Model, 
				_simCityWeb3View,
				_simCityWeb3Service);
			
		}

		
		// General Methods --------------------------------
		
		public async UniTask<bool> HasMoralisUserAsync()
		{
			// Determines if Moralis is logged in with an active user.
			MoralisUser moralisUser = await GetMoralisUserAsync();
			return moralisUser != null;
		}
		
		public async UniTask<MoralisUser> GetMoralisUserAsync()
		{
			return await Moralis.GetUserAsync();
		}
		
		public bool HasAnyData()
		{
			return _simCityWeb3Model.HasAnyData();
		}
		
		public async UniTask ResetAllData()
		{
			await _simCityWeb3Controller.DeleteAllPropertyDatas();
			_simCityWeb3Model.ResetAllData();
		}
		
		public bool WasActiveSceneLoadedDirectly()
		{
			return _simCityWeb3View.SceneManagerComponent.WasActiveSceneLoadedDirectly();
		}
		
		// Event Handlers ---------------------------------


	
	}
}
