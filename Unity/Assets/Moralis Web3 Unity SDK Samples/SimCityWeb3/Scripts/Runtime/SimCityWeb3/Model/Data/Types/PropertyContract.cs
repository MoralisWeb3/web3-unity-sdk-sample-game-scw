
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using MoralisUnity.Samples.Shared.Data.Types;
using UnityEngine;

namespace MoralisUnity.Samples.SimCityWeb3.Model.Data.Types
{
	/// <summary>
	/// Wrapper class for a Web3API Eth Contract.
	/// </summary>
	public class PropertyContract : Contract
	{
		
		// Properties -------------------------------------

		
		// Fields -----------------------------------------
	
		
		// Initialization Methods -------------------------
		public PropertyContract()
		{
			_address = "";
			_abi = "";
		}
		
		// General Methods --------------------------------
		public async UniTask<string> MintPropertyNftAsync (PropertyData propertyData)
		{
			string metadata = propertyData.GetMetadata();
			Debug.Log($"MintPropertyNft() metadata = {metadata}");
			object[] args =
			{
				metadata
			};
			
			const bool isLogging = true;
			string result = await ExecuteContractFunctionAsync("mintPropertyNft", args, isLogging);
			return result;
		}
		
		public async UniTask<string> BurnPropertyNftAsync (PropertyData propertyData)
		{
			int tokenId = propertyData.TokenId;
			
			Debug.Log("BurnPropertyNftAsync() tokenId: " + tokenId);

			if (tokenId == PropertyData.NullTokenAddress)
			{
				Debug.Log("BurnPropertyNftAsync() failed. tokenId must be NOT null. Was this NFT just created. Leave and return to Scene so it gets loaded from online");
				return "failed";
			}
				
			Debug.Log($"BurnPropertyNftAsync() tokenId = {tokenId}");
			object[] args =
			{
				tokenId
			};
			
			const bool isLogging = true;
			string result = await ExecuteContractFunctionAsync("burnPropertyNft", args, isLogging);
			return result;
		}

		// Event Handlers ---------------------------------

		public async Task<string> BurnPropertyNftsAsync(List<PropertyData> propertyDatas)
		{
			int[] tokenIds = new int[propertyDatas.Count];
			for  (int i = 0; i < propertyDatas.Count; i++)
			{
				int tokenId = propertyDatas[i].TokenId;
			
				//Debug.Log("BurnPropertyNftsAsync() tokenId: " + tokenId + " at i " + i);

				if (tokenId == PropertyData.NullTokenAddress)
				{
					Debug.Log("BurnPropertyNftsAsync() failed. tokenId must be NOT null. Was this NFT just created. Leave and return to Scene so it gets loaded from online");
					return "failed";
				}
			
				tokenIds[i] = tokenId;
			
			}
			
			object[] args =
			{
				tokenIds
			};
			
			Debug.Log($"BurnPropertyNftsAsync() tokenIds.Length = {tokenIds.Length}");
			const bool isLogging = true;
			string result = await ExecuteContractFunctionAsync("burnPropertyNfts", args, isLogging);
			return result;
		}
	}
}
