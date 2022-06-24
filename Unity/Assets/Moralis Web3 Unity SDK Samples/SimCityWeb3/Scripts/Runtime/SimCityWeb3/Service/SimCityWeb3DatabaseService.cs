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

		public async UniTask SavePropertyDatas(List<PropertyData> propertyDatas)
		{
			// TODO: Replace this delete-then-add with a more robust add-only-if-new
			
			// Delete
			await Moralis_DeleteAll();

			// Add
			foreach (PropertyData propertyData in propertyDatas)
			{
				await Moralis_Create(propertyData);
			}
		}

		public async UniTask DeleteAllPropertyDatas()
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

		private static async UniTask<PropertyDataMoralisObject> Moralis_Delete(
			PropertyDataMoralisObject moralisObjectToDelete)
		{
			///////////////////////////////////////////
			// Execute: DeleteAsync
			///////////////////////////////////////////
			await Moralis.GetClient().DeleteAsync<PropertyDataMoralisObject>(moralisObjectToDelete);
			
			return moralisObjectToDelete;
		}
		
		private static async UniTask Moralis_DeleteAll()
		{
			///////////////////////////////////////////
			// Execute: DeleteAsync
			///////////////////////////////////////////
			List<PropertyDataMoralisObject> results = await Moralis_Query();

			foreach (PropertyDataMoralisObject result in results)
			{
				await Moralis.GetClient().DeleteAsync<PropertyDataMoralisObject>(result);
			}
		}
		
		// Event Handlers ---------------------------------

	}
}
