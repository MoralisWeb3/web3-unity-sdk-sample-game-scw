using Cysharp.Threading.Tasks;
using Nethereum.Hex.HexTypes;

namespace MoralisUnity.Samples.Shared.Data.Types
{
	/// <summary>
	/// Wrapper class for a Web3API Eth Contract.
	/// </summary>
	public class EthContract
	{
		// Properties -------------------------------------

		
		// Fields -----------------------------------------
		private readonly string _address;
		private readonly string _abi;

		
		// Initialization Methods -------------------------
		public EthContract (string address, string abi)
		{
			_address = address;
			_abi = abi;
		}
		
		
		// General Methods --------------------------------
		protected async UniTask RunContactFunction (string functionName, object[] args)
		{
			// Estimate the gas
			HexBigInteger value = new HexBigInteger(0);
			HexBigInteger gas = new HexBigInteger(0);
			HexBigInteger gasPrice = new HexBigInteger(0);
			
			await Moralis.ExecuteContractFunction(_address, _abi, functionName, args, value, gas, gasPrice);
		}

		// Event Handlers ---------------------------------
		
	}
}
