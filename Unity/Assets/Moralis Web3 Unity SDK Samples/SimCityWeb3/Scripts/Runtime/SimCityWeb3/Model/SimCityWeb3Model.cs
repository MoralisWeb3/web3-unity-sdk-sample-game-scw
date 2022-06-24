using System.Collections.Generic;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
using UnityEngine;

namespace MoralisUnity.Samples.SimCityWeb3.Model
{
	/// <summary>
	/// Replace with comments...
	/// </summary>
	public class SimCityWeb3Model 
	{
		// Events -----------------------------------------
		public PropertyDatasUnityEvent PropertyDatasUnityEvent = new PropertyDatasUnityEvent();
		
		
		// Properties -------------------------------------
		public List<PropertyData> PropertyDatas { get { return _propertyDatas; } set { _propertyDatas = value; } }

		
		// Fields -----------------------------------------
		private List<PropertyData> _propertyDatas = new List<PropertyData>();

		
		// Initialization Methods -------------------------
		public SimCityWeb3Model()
		{
		}

		
		// General Methods --------------------------------
		public bool HasAnyData()
		{
			return PropertyDatas.Count > 0;
		}
		
		
		public void ResetAllData()
		{
			_propertyDatas.Clear();
			PropertyDatasUnityEvent.Invoke(_propertyDatas);
		}
		
		
		public void AddPropertyData(PropertyData propertyData)
		{
			PropertyDatas.Add(propertyData);
			PropertyDatasUnityEvent.Invoke(_propertyDatas);
		}
		
		public void RemovePropertyData(PropertyData propertyData)
		{
			PropertyDatas.Remove(propertyData);
			PropertyDatasUnityEvent.Invoke(_propertyDatas);
		}
		
		// Event Handlers ---------------------------------


	}
}
