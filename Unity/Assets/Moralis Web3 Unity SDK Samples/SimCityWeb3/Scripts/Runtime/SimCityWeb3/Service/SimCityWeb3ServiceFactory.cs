using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
using MoralisUnity.Sdk.Exceptions;
using MoralisUnity.Web3Api.Models;
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
		
		
		// General Methods --------------------------------
		public ISimCityWeb3Service Create (SimCityWeb3ServiceType simCityWeb3ServiceType, ChainList chainList)
		{
			Debug.Log($"SimCityWeb3ServiceFactory.Create() " +
			          $"type = {simCityWeb3ServiceType}, chainList = {chainList}");
			
			ISimCityWeb3Service simCityWeb3Service = null;
			switch (simCityWeb3ServiceType)
			{
				case SimCityWeb3ServiceType.Database:
					simCityWeb3Service = new SimCityWeb3DatabaseService();
					break;
				case SimCityWeb3ServiceType.Contract:
					simCityWeb3Service = new SimCityWeb3ContractService(chainList);
					break;
				case SimCityWeb3ServiceType.LocalDiskStorage:
					simCityWeb3Service = new SimCityWeb3LocalDiskStorageService();
					break;
				default:
					SwitchDefaultException.Throw(simCityWeb3ServiceType);
					break;
			}

			return simCityWeb3Service;
		}

		
		// Event Handlers ---------------------------------
	}
}
