using System;
using System.Text;
using Cysharp.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using UnityEngine;
using WalletConnectSharp.Unity;

namespace MoralisUnity.Samples.Shared.Data.Types
{
	/// <summary>
	/// Wrapper class for a Web3API Eth Contract.
	/// </summary>
	public class Contract
	{

		// Properties -------------------------------------
		public string Address
		{
			get { return _address; }
		}

		public string Abi
		{
			get { return _abi; }
		}


		// Fields -----------------------------------------
		private readonly string _address;
		private readonly string _abi;


		// Initialization Methods -------------------------
		public Contract(string address, string abi)
		{
			_address = address;
			_abi = abi;
		}


		// General Methods --------------------------------
		protected async UniTask<string> ExecuteContractFunction(string functionName, object[] args, bool isLogging)
		{
			if (WalletConnect.Instance == null)
			{
				throw new Exception(
					$"ExecuteContractFunction() failed. " +
					$"WalletConnect.Instance must not be null. " +
					$"Add the WalletConnect.prefab to your scene.");
			}

			await Moralis.SetupWeb3();
			
			// Estimate the gas
			HexBigInteger value = new HexBigInteger(0);
			HexBigInteger gas = new HexBigInteger(0);
			HexBigInteger gasPrice = new HexBigInteger(0);

			if (isLogging)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine($"Contract.ExecuteContractFunction()...");
				stringBuilder.AppendLine($"");
				stringBuilder.AppendLine($"\taddress		= {_address}");
				stringBuilder.AppendLine($"\tabi.Length		= {_abi.Length}");
				stringBuilder.AppendLine($"\tfunctionName	= {functionName}");
				stringBuilder.AppendLine($"\targs		= {args}");
				stringBuilder.AppendLine($"\tvalue		= {value}");
				stringBuilder.AppendLine($"\tgas		= {gas}");
				stringBuilder.AppendLine($"\tgasPrice	= {gasPrice}");
				Debug.Log($"{stringBuilder.ToString()}");
				
				Debug.Log($"Moralis.ExecuteContractFunction() START");
			}
			
			// Related Documentation
			// Call Method (Read/Write) - https://docs.moralis.io/moralis-dapp/web3/blockchain-interactions-unity
			// Call Method (Read Only) - https://docs.moralis.io/moralis-dapp/web3-api/native#runcontractfunction
			string result = await Moralis.ExecuteContractFunction(_address, _abi, functionName, args, value, gas, gasPrice);

			if (isLogging)
			{
				Debug.Log($"Moralis.ExecuteContractFunction() FINISH. result={result}");
			}

			return result;
		}
	}

}
