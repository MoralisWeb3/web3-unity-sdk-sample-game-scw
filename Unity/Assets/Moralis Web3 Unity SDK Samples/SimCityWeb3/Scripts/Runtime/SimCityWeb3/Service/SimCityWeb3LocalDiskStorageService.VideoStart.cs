// using System.Collections.Generic;
// using Cysharp.Threading.Tasks;
// using MoralisUnity.Samples.Shared.Data.Types;
// using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
//
// namespace MoralisUnity.Samples.SimCityWeb3.Service
// {
// 	
// 	/// <summary>
// 	/// Depending on <see cref="SimCityWeb3ServiceType"/> this is enabled.
// 	///		* Handles connection to external resource of Moralis Database
// 	/// </summary>
// 	public class SimCityWeb3LocalDiskStorageService : ISimCityWeb3Service
// 	{
// 		// Properties -------------------------------------
// 		public PendingMessage PendingMessageForDeletion { get { return _pendingMessageForDeletion; }}
// 		public PendingMessage PendingMessageForSave { get { return _pendingMessageForSave; }}
// 		
// 		
// 		// Fields -----------------------------------------
// 		private readonly PendingMessage _pendingMessageForDeletion = new PendingMessage("Deleting Object From LocalDiskStorage", 500);
// 		private readonly PendingMessage _pendingMessageForSave = new PendingMessage("Saving Object To LocalDiskStorage", 500);
// 		
// 		
// 		// Initialization Methods -------------------------
// 		public SimCityWeb3LocalDiskStorageService()
// 		{
//
// 		}
// 		
// 		
// 		// General Methods --------------------------------
// 		public async UniTask<List<PropertyData>> LoadPropertyDatasAsync()
// 		{
// 			return new List<PropertyData>();
// 		}
//
// 		
// 		public async UniTask<PropertyData> SavePropertyDataAsync(PropertyData propertyData)
// 		{
// 			// Return the original, untouched
// 			// The method signature is more helpful for the
// 			// ContractService which adds the token address
// 			return propertyData;
// 		}
// 		
// 		
// 		public async UniTask DeletePropertyDataAsync(PropertyData propertyData)
// 		{
// 			///////////////////////////////////////////
// 			// Execute: Remove
// 			///////////////////////////////////////////
// 		}
//
// 		
// 		public async UniTask DeleteAllPropertyDatasAsync(List<PropertyData> propertyDatas)
// 		{
// 			///////////////////////////////////////////
// 			// Execute: Remove
// 			///////////////////////////////////////////
// 		}
// 		
// 		// Event Handlers ---------------------------------
//
// 	}
// }