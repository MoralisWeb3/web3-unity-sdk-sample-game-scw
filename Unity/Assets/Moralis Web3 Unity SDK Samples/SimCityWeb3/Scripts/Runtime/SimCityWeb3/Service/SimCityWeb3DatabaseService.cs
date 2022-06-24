using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using MoralisUnity.Platform.Queries;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;

namespace MoralisUnity.Samples.SimCityWeb3.Service
{
	/// <summary>
	/// Replace with comments...
	/// </summary>
	public class SimCityWeb3DatabaseService : ISimCityWeb3Service
	{
		// Properties -------------------------------------

		
		// Fields -----------------------------------------

		
		// Initialization Methods -------------------------
		public SimCityWeb3DatabaseService()
		{
		}

		
		// General Methods --------------------------------
		public async UniTask<List<PropertyData>> LoadPropertyDatas()
		{
			List<PropertyData> propertyDatas = new List<PropertyData>();
			
			List<PropertyDataMoralisObject> results = await Moralis_Query();
			foreach (PropertyDataMoralisObject result in results)
			{
				propertyDatas.Add(result.PropertyData);
			}

			return propertyDatas;
		}

		
		public async UniTask SavePropertyData(PropertyData propertyData)
		{
			await Moralis_Create(propertyData);
		}

		
		public async UniTask DeletePropertyData(PropertyData propertyDatas)
		{
			await Moralis_DeleteOne(propertyDatas);
		}

		
		public async UniTask DeleteAllPropertyDatas(List<PropertyData> propertyDatas)
		{
			await Moralis_DeleteAll();
		}

		
		// Static Methods ---------------------------------
		private static async UniTask Moralis_Create(PropertyData propertyData)
		{
			///////////////////////////////////////////
			// Execute: Create
			///////////////////////////////////////////
			PropertyDataMoralisObject moralisObject = Moralis.Create<PropertyDataMoralisObject>();
			moralisObject.PropertyData = propertyData;
			await moralisObject.SaveAsync();

		}

		public static async UniTask<PropertyDataMoralisObject> Moralis_QueryOne(PropertyData propertyData)
		{
			List<PropertyDataMoralisObject> results = await Moralis_Query();
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
		
		public static async UniTask<List<PropertyDataMoralisObject>> Moralis_Query()
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
			PropertyDataMoralisObject propertyDataMoralisObject = await Moralis_QueryOne(propertyData);
			await Moralis.GetClient().DeleteAsync<PropertyDataMoralisObject>(propertyDataMoralisObject);
		}
		
		
		private static async UniTask Moralis_DeleteAll()
		{
			List<PropertyDataMoralisObject> results = await Moralis_Query();

			foreach (PropertyDataMoralisObject result in results)
			{
				///////////////////////////////////////////
				// Execute: DeleteAsync
				///////////////////////////////////////////
				await Moralis.GetClient().DeleteAsync<PropertyDataMoralisObject>(result);
			}
		}
		
		public string GetDeletionMessage()
		{
			return "Deleting Object From Database";
		}
		
		public bool HasDeletionMessage()
		{
			return true;
		}
		
		// Event Handlers ---------------------------------

	}
}
