using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Cysharp.Threading.Tasks;
using MoralisUnity.Samples.Shared.Data.Types;
using MoralisUnity.Samples.Shared.Templates;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
using MoralisUnity.Sdk.Utilities;
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

		private bool _hasLoggedOnce = false;
		
		// Initialization Methods -------------------------
		public SimCityWeb3ContractService(ChainList chainList)
		{
			_propertyContract = new PropertyContract(chainList);
		}
		
		
		// General Methods --------------------------------
		public async UniTask<List<PropertyData>> LoadPropertyDatasAsync()
		{
			// Create Method Return Value
			List<PropertyData> propertyDatas = new List<PropertyData>();

			// Check System Status
			bool hasMoralisUser = await SimCityWeb3Singleton.Instance.HasMoralisUserAsync();
			
			if (!hasMoralisUser)
			{
				// Hide error specifically when inside the Unity Unit Test Runner
				if (!ApplicationHelper.isTestRunner())
				{
					Debug.LogError(SimCityWeb3Constants.ErrorMoralisUserRequired);
				}
				return null;
			}

			if (!_hasLoggedOnce)
			{
				_hasLoggedOnce = true;
				string address = Formatters.GetWeb3AddressShortFormat(_propertyContract.Address);
				Debug.Log($"GetNFTOwners() Address = {address}, " +
				          $"ChainList = {_propertyContract.ChainList}");
			}
		
			// Get NFT Info
			NftOwnerCollection  nftOwnerCollection = 
				await Moralis.Web3Api.Token.GetNFTOwners(
					_propertyContract.Address,
					_propertyContract.ChainList);

			// Create Method Return Value
			foreach (NftOwner nftOwner in nftOwnerCollection.Result)
			{
				string ownerAddress = nftOwner.OwnerOf;
				string tokenIdString = nftOwner.TokenId;
				string metadata = nftOwner.TokenUri;
				
				//Debug.Log($"nftOwner ownerAddress={ownerAddress} tokenIdString={tokenIdString} metadata={metadata}");
				propertyDatas.Add(
					PropertyData.CreateNewPropertyDataFromMetadata(ownerAddress, tokenIdString, metadata));
			}

			// Finalize Method Return Value
			return propertyDatas;
		}

		
		public async UniTask<PropertyData> SavePropertyDataAsync(PropertyData propertyData)
		{
			// Mint the NFT
			string newTokenIdString = await _propertyContract.MintPropertyNftAsync(propertyData);
			
			// Update Method Return Value
			propertyData = PropertyData.CreateNewPropertyDataFromMetadata(propertyData.OwnerAddress, newTokenIdString, propertyData.GetMetadata());

			// Finalize Method Return Value
			return propertyData;
		}

		
		public async UniTask DeletePropertyDataAsync(PropertyData propertyData)
		{
			// Burn the NFT
			string result = await _propertyContract.BurnPropertyNftAsync(propertyData);
			Debug.Log($"DeletePropertyDataAsync() Result = {result}");
		}

		
		public async UniTask DeleteAllPropertyDatasAsync(List<PropertyData> propertyDatas)
		{
			// Burn the NFT List
			string result = await _propertyContract.BurnPropertyNftsAsync(propertyDatas);
			Debug.Log($"DeleteAllPropertyDatasAsync() result = {result}");
	
		}

		// Event Handlers ---------------------------------

	}
}
