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
		protected async UniTask<string> ExecuteContractFunction(string functionName, object[] args)
		{
			if (WalletConnect.Instance == null)
			{
				throw new Exception(
					$"ExecuteContractFunction() failed. " +
					$"WalletConnect.Instance must not be null. " +
					$"Add the WalletConnect.prefab to your scene.");
			}

			// Estimate the gas
			HexBigInteger value = new HexBigInteger(0);
			HexBigInteger gas = new HexBigInteger(0);
			HexBigInteger gasPrice = new HexBigInteger(0);

			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine($"\t_address = {_address}");
			stringBuilder.AppendLine($"\t_abi.Length = {_abi.Length}");
			stringBuilder.AppendLine($"\tfunctionName = {functionName}");
			stringBuilder.AppendLine($"\tvalue = {value}");
			stringBuilder.AppendLine($"\tgas = {gas}");
			stringBuilder.AppendLine($"\tgasPrice = {gasPrice}");
			Debug.Log($"Contract.ExecuteContractFunction()...\n\n{stringBuilder.ToString()}");

			Debug.Log($"Before... Moralis.SetupWeb3()");
			await Moralis.SetupWeb3();
			Debug.Log($"After... Moralis.SetupWeb3()");

			Debug.Log($"Before... Moralis.ExecuteContractFunction");

			//runcontract = read methods

			//execute = changes state
			string result =
				await Moralis.ExecuteContractFunction(_address, _abi, functionName, args, value, gas, gasPrice);
			Debug.Log($"After... Moralis.ExecuteContractFunction");

			return result;
		}
	}

}
