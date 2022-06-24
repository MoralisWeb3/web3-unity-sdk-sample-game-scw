using System;
using UnityEngine;

namespace MoralisUnity.Samples.SimCityWeb3.Model.Data.Types
{
	/// <summary>
	/// Replace with comments...
	/// </summary>
	[Serializable]
	public class PropertyData 
	{
		// Properties -------------------------------------
		public string OwnerAddress { get { return _ownerAddress;}}
		public double Latitude { get { return _latitude;} set { _latitude = value;}}
		public double Longitude { get { return _longitude;} set { _longitude = value;}}
		
		// Fields -----------------------------------------
		[SerializeField]
		private string _ownerAddress;
		
		[SerializeField]
		private double _latitude = 0;
		
		[SerializeField]
		private double _longitude = 0;
		
		// Initialization Methods -------------------------
		public PropertyData(string ownerAddress, double latitude, double longitude)
		{
			_ownerAddress = ownerAddress;
			_latitude = latitude;
			_longitude = longitude;
		}

		
// General Methods --------------------------------
public string GetMetadata()
{
	return $"{Latitude}|{Longitude}";
}

public static PropertyData CreateNewPropertyDataFromMetadata(string address, string metadata)
{
	string[] metadataTokens = metadata.Split("|");
	double latitude = double.Parse(metadataTokens[0]);
	double longitude = double.Parse(metadataTokens[1]);
	if (latitude == 0 || longitude == 0)
	{
		Debug.Log("CreateNewPropertyDataFromMetadata() failed. " +
		          "latitude = {latitude}, longitude = {longitude}");
	}
	return new PropertyData(address, latitude, longitude);
}
		
		// Event Handlers ---------------------------------

	}
}
