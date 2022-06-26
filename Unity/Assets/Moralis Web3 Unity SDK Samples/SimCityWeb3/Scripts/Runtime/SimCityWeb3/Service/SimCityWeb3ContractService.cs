using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MoralisUnity.Samples.Shared.Data.Types;
using MoralisUnity.Samples.Shared.Utilities;
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
			bool hasMoralisUser = await SimCityWeb3Singleton.Instance.HasMoralisUserAsync();
			if (!hasMoralisUser)
			{
				Debug.LogError(SimCityWeb3Constants.ErrorMoralisUserRequired);
				return null;
			}
			
			List<PropertyData> propertyDatas = new List<PropertyData>();
			
			NftOwnerCollection nftOwnerCollection2 = await Moralis.Web3Api.Token.GetNFTOwners(
				_propertyContract.Address,
				ChainList.mumbai);
			
			foreach (NftOwner nftOwner in nftOwnerCollection2.Result)
			{
				string ownerAddress = nftOwner.OwnerOf;
				string tokenAddress = nftOwner.TokenAddress;
				string metadata = nftOwner.TokenUri;
				propertyDatas.Add(PropertyData.CreateNewPropertyDataFromMetadata(ownerAddress, tokenAddress, metadata));
			}
			
		
			return propertyDatas;
		}

		public async UniTask<PropertyData> SavePropertyDataAsync(PropertyData propertyData)
		{
			string newTokenAddress = await _propertyContract.MintPropertyNftAsync(propertyData);

			if (SharedValidators.IsValidWeb3TokenAddressFormat(newTokenAddress))
			{
				propertyData = PropertyData.CreateNewPropertyDataFromMetadata(propertyData.OwnerAddress, newTokenAddress, propertyData.GetMetadata());
			}
			else
			{
				Debug.LogError("SavePropertyData() worked, but return value may be malformatted. newTokenAddress = {newTokenAddress}");
			}

			return propertyData;
		}

		public async UniTask DeletePropertyDataAsync(PropertyData propertyData)
		{
			string result = await _propertyContract.BurnPropertyNftAsync(propertyData);
			Debug.Log($"DeletePropertyDataAsync() Result = {result}");
		}

		public async UniTask DeleteAllPropertyDatasAsync(List<PropertyData> propertyDatas)
		{
			foreach (PropertyData propertyData in propertyDatas)
			{
				string result = await _propertyContract.BurnPropertyNftAsync(propertyData);
				Debug.Log($"DeleteAllPropertyDatasAsync() result = {result}");
			}
		}



		// Event Handlers ---------------------------------

	}
}
