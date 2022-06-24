using MoralisUnity.Platform.Objects;
using UnityEngine;

namespace MoralisUnity.Samples.SimCityWeb3.Model.Data.Types
{
	/// <summary>
	/// Replace with comments...
	/// </summary>
	public class PropertyDataMoralisObject : MoralisObject
	{
		// Properties -------------------------------------
		public PropertyData PropertyData { get { return _propertyData;} set { _propertyData = value;}}
		
		// Fields -----------------------------------------
		[SerializeField]
		private PropertyData _propertyData;

		// Initialization Methods -------------------------
		public PropertyDataMoralisObject() : base ("PropertyDataMoralisObject")
		{
		}


		// General Methods --------------------------------

		
		// Event Handlers ---------------------------------
	}
}
