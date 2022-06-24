
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;

namespace MoralisUnity.Samples.SimCityWeb3.Service
{
	/// <summary>
	/// Replace with comments...
	/// </summary>
	public interface ISimCityWeb3Service 
	{
		// Properties -------------------------------------

		// General Methods --------------------------------
		UniTask<List<PropertyData>> LoadPropertyDatas();
		UniTask SavePropertyData(PropertyData propertyData);
		UniTask DeletePropertyData(PropertyData propertyData);
		UniTask DeleteAllPropertyDatas(List<PropertyData> propertyDatas);
	}
}
