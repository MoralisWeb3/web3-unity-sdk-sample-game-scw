using System;
using MoralisUnity.Samples.Shared.Utilities;
using Newtonsoft.Json;
using UnityEngine;

namespace MoralisUnity.Samples.SimCityWeb3.Model.Data.Types
{
	/// <summary>
	/// Represents all data for one real-estate property in the game
	/// </summary>
	[Serializable]
	public class PropertyData 
	{
		// Properties -------------------------------------
		public string OwnerAddress { get { return _ownerAddress;}}
		public int TokenId { get { return _tokenId;}}
		public double Latitude { get { return _latitude;} set { _latitude = value;}}
		public double Longitude { get { return _longitude;} set { _longitude = value;}}
		

		// Fields -----------------------------------------
		[SerializeField]
		private string _ownerAddress;
		
		[SerializeField]
		private int _tokenId;
		
		[SerializeField]
		private double _latitude = 0;
		
		[SerializeField]
		private double _longitude = 0;

		public const int NullTokenAddress = -1;
		
		// Initialization Methods -------------------------
		
		/// <summary>
		/// Created from view by user gesture
		/// </summary>
		public PropertyData(string ownerAddress, double latitude, double longitude)
		{
			Initialize(ownerAddress, NullTokenAddress, latitude, longitude);
		}
		
		/// <summary>
		/// Created from service by loading data
		/// </summary>
		[JsonConstructor]
		public PropertyData(string ownerAddress, int tokenId, double latitude, double longitude)
		{
			Initialize(ownerAddress, tokenId, latitude, longitude);
		}
		
		private void Initialize (string ownerAddress, int tokenId, double latitude, double longitude)
		{
			_ownerAddress = ownerAddress;
			_tokenId = tokenId;
			_latitude = latitude;
			_longitude = longitude;
			
			if (_latitude == 0 || _longitude == 0)
			{
				Debug.Log($"PropertyData.Initialize() failed. " +
				          "latitude = {latitude}, longitude = {longitude}");
				throw new Exception();
			}
			
			//Debug.Log($"PropertyData.Initialize() tokenId = {tokenId}");
		}
		
		// General Methods --------------------------------
		public string GetMetadata()
		{
			return $"{Latitude}|{Longitude}";
		}

		public static PropertyData CreateNewPropertyDataFromMetadata(string ownerAddress, string newTokenIdString, string metadata)
		{
			string[] metadataTokens = metadata.Split("|");
			double latitude = double.Parse(metadataTokens[0]);
			double longitude = double.Parse(metadataTokens[1]);
			int tokenId = NullTokenAddress;
			
			if (!string.IsNullOrEmpty(newTokenIdString) && !SharedValidators.IsValidWeb3TokenAddressFormat(newTokenIdString) )
			{
				tokenId = int.Parse(newTokenIdString);
			}
				
			return new PropertyData(ownerAddress, tokenId, latitude, longitude);
		}
		
		// Event Handlers ---------------------------------

	}
}
