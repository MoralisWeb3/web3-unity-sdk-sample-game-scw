using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;

namespace MoralisUnity.Samples.SimCityWeb3.Service
{
	/// <summary>
	/// Replace with comments...
	/// </summary>
	public class SimCityWeb3ContractService : ISimCityWeb3Service
	{
		// Properties -------------------------------------

		
		// Fields -----------------------------------------
		private PropertyEthContract _propertyEthContract = null;
		
		// Initialization Methods -------------------------
		public SimCityWeb3ContractService()
		{
			_propertyEthContract = new PropertyEthContract();

		}

		
		// General Methods --------------------------------
		public async UniTask<List<PropertyData>> LoadPropertyDatas()
		{
			throw new System.NotImplementedException();
		}

		public async UniTask SavePropertyDatas(List<PropertyData> propertyDatas)
		{
			foreach (PropertyData propertyData in propertyDatas)
			{
				await _propertyEthContract.RunContactFunction_MintPropertyNft(propertyData);
			}
			
		}

		public async UniTask DeleteAllPropertyDatas()
		{
			throw new System.NotImplementedException();
		}

		// Event Handlers ---------------------------------

	}
}
