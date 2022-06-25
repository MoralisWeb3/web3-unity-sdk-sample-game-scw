
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;

namespace MoralisUnity.Samples.SimCityWeb3.Service
{
	/// <summary>
	/// SHandles communication with external sources (e.g. database/servers/contracts)
	///		* See <see cref="SimCityWeb3Singleton"/> 
	/// </summary>
	public interface ISimCityWeb3Service 
	{
		// Properties -------------------------------------

		// General Methods --------------------------------
		UniTask<List<PropertyData>> LoadPropertyDatas();
		UniTask<PropertyData> SavePropertyData(PropertyData propertyData);
		UniTask DeletePropertyData(PropertyData propertyData);
		UniTask DeleteAllPropertyDatas(List<PropertyData> propertyDatas);
		string GetMessageForDeletePropertyData();
		bool HasMessageForDeletePropertyData();
		string GetMessageSavePropertyData();
		bool HasMessageForSavePropertyData();
	}
}
