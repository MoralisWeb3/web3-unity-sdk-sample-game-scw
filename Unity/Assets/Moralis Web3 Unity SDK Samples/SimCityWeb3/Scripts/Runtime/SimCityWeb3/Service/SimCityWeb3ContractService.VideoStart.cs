/*
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MoralisUnity.Samples.Shared.Data.Types;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
using MoralisUnity.Web3Api.Models;
using UnityEngine;

namespace MoralisUnity.Samples.SimCityWeb3.Service
{
	/// <summary>
	/// Handles communication with external sources (e.g. database/servers/contracts)
	///		* See <see cref="SimCityWeb3Singleton"/> 
	/// </summary>
	public class SimCityWeb3ContractService : ISimCityWeb3Service
	{
		// Properties -------------------------------------
		public PendingMessage PendingMessageForDeletion { get { return _pendingMessageForDeletion; }}
		public PendingMessage PendingMessageForSave { get { return _pendingMessageForSave; }}
		
		
		// Fields -----------------------------------------
		private readonly PendingMessage _pendingMessageForDeletion = new PendingMessage("Please confirm transaction in your wallet", 0);
		private readonly PendingMessage _pendingMessageForSave = new PendingMessage("Please confirm transaction in your wallet", 0);
		private readonly PropertyContract _propertyContract = null;


		// Initialization Methods -------------------------
		public SimCityWeb3ContractService()
		{
			_propertyContract = new PropertyContract();
		}
		
		
		// General Methods --------------------------------
		public async UniTask<List<PropertyData>> LoadPropertyDatasAsync()
		{
			// Create Method Return Value
			List<PropertyData> propertyDatas = new List<PropertyData>();
			
			// Check System Status
			
			// Get NFT Info
			
			// Create Method Return Value
		
			// Finalize Method Return Value
			return propertyDatas;
		}

		
		public async UniTask<PropertyData> SavePropertyDataAsync(PropertyData propertyData)
		{
			// Mint the NFT
			
			// Update Method Return Value

			// Finalize Method Return Value
			return propertyData;
		}

		
		public async UniTask DeletePropertyDataAsync(PropertyData propertyData)
		{
			// Burn the NFT
		}

		
		public async UniTask DeleteAllPropertyDatasAsync(List<PropertyData> propertyDatas)
		{
			// Burn the NFT List
	
		}


		// Event Handlers ---------------------------------
	}
}

*/