
namespace MoralisUnity.Samples.SimCityWeb3.Model.Data.Types
{
	/// <summary>
	/// At edit-time, toggle this with the <see cref="SimCityWeb3Configuration"/> in the Unity inspector.
	/// This determines if the game runs off of the Moralis database (development) or Web3 Contracts (production)
	/// </summary>
	public enum SimCityWeb3ServiceType
	{
		Null,
		Database,
		Contract
	}
}
