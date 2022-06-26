using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using MoralisUnity.Platform.Queries;
using MoralisUnity.Samples.Shared.Data.Types;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;

namespace MoralisUnity.Samples.SimCityWeb3.Service
{
	/// <summary>
	/// Depending on <see cref="SimCityWeb3ServiceType"/> this is enabled.
	///		* Handles connection to external resource of Moralis Database
	/// </summary>
	public class SimCityWeb3DatabaseService : ISimCityWeb3Service
	{
		// Properties -------------------------------------
		public PendingMessage PendingMessageForDeletion { get { return _pendingMessageForDeletion; }}
		public PendingMessage PendingMessageForSave { get { return _pendingMessageForSave; }}
		
		
		// Fields -----------------------------------------
		private readonly PendingMessage _pendingMessageForDeletion = new PendingMessage("Deleting Object From The Database", 500);
		private readonly PendingMessage _pendingMessageForSave = new PendingMessage("Saving Object To The Database", 500);
		
		
		// Initialization Methods -------------------------
		public SimCityWeb3DatabaseService()
		{
			
		}

		
		// General Methods --------------------------------
		public async UniTask<List<PropertyData>> LoadPropertyDatasAsync()
		{
			List<PropertyData> propertyDatas = new List<PropertyData>();
			
			List<PropertyDataMoralisObject> results = await Moralis_QueryAsync();
			foreach (PropertyDataMoralisObject result in results)
			{
				propertyDatas.Add(result.PropertyData);
			}

			return propertyDatas;
		}

		
		public async UniTask<PropertyData> SavePropertyDataAsync(PropertyData propertyData)
		{
			await Moralis_CreateAsync(propertyData);

			// Return the original, untouched
			// The method signature is more helpful for the ContractService which adds the token address
			return propertyData;
		}

		
		public async UniTask DeletePropertyDataAsync(PropertyData propertyDatas)
		{
			await Moralis_DeleteOne(propertyDatas);
		}

		
		public async UniTask DeleteAllPropertyDatasAsync(List<PropertyData> propertyDatas)
		{
			await Moralis_DeleteAllAsync();
		}

		
		// Static Methods ---------------------------------
		private static async UniTask Moralis_CreateAsync(PropertyData propertyData)
		{
			///////////////////////////////////////////
			// Execute: Create
			///////////////////////////////////////////
			PropertyDataMoralisObject moralisObject = Moralis.Create<PropertyDataMoralisObject>();
			moralisObject.PropertyData = propertyData;
			await moralisObject.SaveAsync();

		}

		public static async UniTask<PropertyDataMoralisObject> Moralis_QueryOneAsync(PropertyData propertyData)
		{
			List<PropertyDataMoralisObject> results = await Moralis_QueryAsync();
			List<PropertyDataMoralisObject> matchingResults = new List<PropertyDataMoralisObject>();
			foreach (PropertyDataMoralisObject result in results)
			{
				if (result.PropertyData.Latitude.Equals(propertyData.Latitude) &&
				    result.PropertyData.Longitude.Equals(propertyData.Longitude) &&
				    result.PropertyData.OwnerAddress.Equals(propertyData.OwnerAddress) 
				   )
				{
					matchingResults.Add(result);
				}
			}

			if (matchingResults.Count == 1)
			{
				return matchingResults[0];
			}
			throw new Exception($"Moralis_DeleteOne() failed. matchingResults.Count must be 1. ");
		}
		
		public static async UniTask<List<PropertyDataMoralisObject>> Moralis_QueryAsync()
		{
			///////////////////////////////////////////
			// Execute: Query
			///////////////////////////////////////////
			MoralisQuery<PropertyDataMoralisObject> moralisQuery1 = await Moralis.Query<PropertyDataMoralisObject>();
			IEnumerable<PropertyDataMoralisObject> result = await moralisQuery1.FindAsync();
			List<PropertyDataMoralisObject> results = result.ToList();
			return results;
		}

		private static async UniTask Moralis_DeleteOne(PropertyData propertyData)
		{
			PropertyDataMoralisObject propertyDataMoralisObject = await Moralis_QueryOneAsync(propertyData);
			await Moralis.GetClient().DeleteAsync<PropertyDataMoralisObject>(propertyDataMoralisObject);
		}
		
		
		private static async UniTask Moralis_DeleteAllAsync()
		{
			List<PropertyDataMoralisObject> results = await Moralis_QueryAsync();

			foreach (PropertyDataMoralisObject result in results)
			{
				///////////////////////////////////////////
				// Execute: DeleteAsync
				///////////////////////////////////////////
				await Moralis.GetClient().DeleteAsync<PropertyDataMoralisObject>(result);
			}
		}

		
		// Event Handlers ---------------------------------

	}
}
