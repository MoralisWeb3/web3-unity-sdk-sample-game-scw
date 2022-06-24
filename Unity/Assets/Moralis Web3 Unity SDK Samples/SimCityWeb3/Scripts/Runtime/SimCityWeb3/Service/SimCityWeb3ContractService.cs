using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
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
			Debug.Log("LoadPropertyDatas()...");
			
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
				string owner = nftOwner.OwnerOf;
				string metadata = nftOwner.TokenUri;
				propertyDatas.Add(PropertyData.CreateNewPropertyDataFromMetadata(owner, metadata));
			}
			
		
			return propertyDatas;
		}

		public async UniTask SavePropertyData(PropertyData propertyData)
		{
			string result = await _propertyContract.MintPropertyNft(propertyData);
		}

		public async UniTask SavePropertyData(List<PropertyData> propertyDatas)
		{
			foreach (PropertyData propertyData in propertyDatas)
			{
				string result = await _propertyContract.MintPropertyNft(propertyData);
			}
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

		// Event Handlers ---------------------------------

	}
}
