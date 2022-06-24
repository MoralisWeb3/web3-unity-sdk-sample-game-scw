using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MoralisUnity.Platform.Objects;
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
			
			MoralisUser moralisUser = await Moralis.GetUserAsync();
			
			NftOwnerCollection nftOwnerCollection1 = await Moralis.Web3Api.Account.GetNFTs(
				moralisUser.ethAddress, ChainList.mumbai);

			foreach (NftOwner nftOwner in nftOwnerCollection1.Result)
			{
				Debug.Log("NFTOwner1: " + nftOwner.TokenAddress);
			}
			
			NftOwnerCollection nftOwnerCollection2 = await Moralis.Web3Api.Token.GetNFTOwners(
				_propertyContract.Address,
				ChainList.mumbai);
			
			foreach (NftOwner nftOwner in nftOwnerCollection2.Result)
			{
				Debug.Log("NFTOwner2: " + nftOwner.TokenAddress);
			}
			
			//WIP - return empty list
			List<PropertyData> propertyDatas = new List<PropertyData>();
			return propertyDatas;
		}

		public async UniTask SavePropertyDatas(List<PropertyData> propertyDatas)
		{
			foreach (PropertyData propertyData in propertyDatas)
			{
				string result = await _propertyContract.MintPropertyNft(propertyData);
				Debug.Log($"Result={result}");
			}
		}

		public UniTask DeleteAllPropertyDatas()
		{
			throw new System.NotImplementedException();
		}

		// Event Handlers ---------------------------------

	}
}
