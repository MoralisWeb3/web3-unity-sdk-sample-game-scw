
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MoralisUnity.Samples.Shared.Data.Types;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;

namespace MoralisUnity.Samples.SimCityWeb3.Service
{
	/// <summary>
	/// Handles communication with external sources (e.g. database/servers/contracts)
	///		* See <see cref="SimCityWeb3Singleton"/> 
	/// </summary>
	public interface ISimCityWeb3Service 
	{
		// Properties -------------------------------------
		PendingMessage PendingMessageForDeletion { get; }
		PendingMessage PendingMessageForSave { get; }
		
		// General Methods --------------------------------
		UniTask<List<PropertyData>> LoadPropertyDatasAsync();
		UniTask<PropertyData> SavePropertyDataAsync(PropertyData propertyData);
		UniTask DeletePropertyDataAsync(PropertyData propertyData);
		UniTask DeleteAllPropertyDatasAsync(List<PropertyData> propertyDatas);
	}
}
