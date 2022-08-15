
using MoralisUnity.Web3Api.Models;

namespace MoralisUnity.Samples.SimCityWeb3.Model.Data.Types
{
	/// <summary>
	/// At edit-time, toggle this with the <see cref="SimCityWeb3Configuration"/> in the Unity inspector.
	/// This determines which blockchain to use. Note this is a small subset of the blockchains which
	/// Moralis can support.
	/// </summary>
	public enum SimCityWeb3ChainList
	{
		Null,
		PolygonMumbai = ChainList.mumbai,
		CronosTestnet = ChainList.cronos_testnet
	};
}
