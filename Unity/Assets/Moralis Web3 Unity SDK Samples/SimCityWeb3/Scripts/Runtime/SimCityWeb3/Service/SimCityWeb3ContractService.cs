using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MoralisUnity.Samples.Shared.Utilities;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
using MoralisUnity.Sdk.Utilities;
using MoralisUnity.Web3Api.Models;
using UnityEngine;

namespace MoralisUnity.Samples.SimCityWeb3.Service
{
	/// <summary>
	/// Replace with comments...
	/// </summary>
	public class SimCityWeb3ContractService : ISimCityWeb3Service
	{
		// Properties -------------------------------------

		
		// Fields -----------------------------------------
		private readonly PropertyContract _propertyContract = null;
		
		
		// Initialization Methods -------------------------
		public SimCityWeb3ContractService()
		{
			_propertyContract = new PropertyContract();
		}

		
		// General Methods --------------------------------
		public async UniTask<List<PropertyData>> LoadPropertyDatas()
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

		public async UniTask<PropertyData> SavePropertyData(PropertyData propertyData)
		{
			string newTokenAddress = await _propertyContract.MintPropertyNft(propertyData);

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

		public async UniTask DeletePropertyData(PropertyData propertyData)
		{
			string result = await _propertyContract.BurnPropertyNft(propertyData);
		}

		public async UniTask DeleteAllPropertyDatas(List<PropertyData> propertyDatas)
		{
			foreach (PropertyData propertyData in propertyDatas)
			{
				string result = await _propertyContract.BurnPropertyNft(propertyData);
				Debug.Log($"Result={result}");
			}
		}

		public string GetMessageForDeletePropertyData()
		{
			return "Please confirm transaction in your wallet";
		}
		
		public bool HasMessageForDeletePropertyData()
		{
			return true;
		}
		
		public string GetMessageSavePropertyData ()
		{
			return "Please confirm transaction in your wallet";
		}
		
		public bool HasMessageForSavePropertyData()
		{
			return true;
		}

		// Event Handlers ---------------------------------

	}
}
