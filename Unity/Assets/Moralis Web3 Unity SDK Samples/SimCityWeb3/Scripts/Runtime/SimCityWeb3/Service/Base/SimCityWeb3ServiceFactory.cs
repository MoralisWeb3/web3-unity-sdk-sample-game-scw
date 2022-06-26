using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
using MoralisUnity.Sdk.Exceptions;
using UnityEngine;

namespace MoralisUnity.Samples.SimCityWeb3.Service
{
	/// <summary>
	/// Creates a concrete <see cref="ISimCityWeb3Service"/>
	/// based on <see cref="SimCityWeb3ServiceType"/>
	/// </summary>
	public class SimCityWeb3ServiceFactory
	{
		// Properties -------------------------------------
		
		// Fields -----------------------------------------
		
		// Initialization Methods -------------------------
		public SimCityWeb3ServiceFactory()
		{
		}

		
		// General Methods --------------------------------
		public ISimCityWeb3Service Create (SimCityWeb3ServiceType simCityWeb3ServiceType)
		{
			Debug.Log($"SimCityWeb3ServiceFactory.Create() type = {simCityWeb3ServiceType}");
			
			ISimCityWeb3Service simCityWeb3Service = null;
			switch (simCityWeb3ServiceType)
			{
				case SimCityWeb3ServiceType.Database:
					simCityWeb3Service = new SimCityWeb3DatabaseService();
					break;
				case SimCityWeb3ServiceType.Contract:
					simCityWeb3Service = new SimCityWeb3ContractService();
					break;
				default:
					SwitchDefaultException.Throw(simCityWeb3ServiceType);
					break;
			}

			return simCityWeb3Service;
		}

		
		// Event Handlers ---------------------------------
		public void Target_OnCompleted(string message)
		{

		}
	}
}
