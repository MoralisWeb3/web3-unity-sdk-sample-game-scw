using System;
using System.Collections.Generic;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
using UnityEngine;

namespace MoralisUnity.Samples.SimCityWeb3.Model
{
	/// <summary>
	/// Stores data for the game
	///		* See <see cref="SimCityWeb3Singleton"/>
	/// </summary>
	public class SimCityWeb3Model 
	{
		// Properties -------------------------------------

		
		// Fields -----------------------------------------
		private List<PropertyData> _propertyDatas = new List<PropertyData>();

		
		// Initialization Methods -------------------------
		public SimCityWeb3Model()
		{
		}

		
		// General Methods --------------------------------
		public bool HasAnyData()
		{
			return _propertyDatas.Count > 0;
		}
		
		
		public void ResetAllData()
		{
			_propertyDatas.Clear();
		}
		
		public void SetPropertyDatas(List<PropertyData> propertyDatas)
		{
			bool hasDuplicate = false;
			for (int i = 0; i < propertyDatas.Count - 1; i++)
			{
				for (int j = i + 1; j < propertyDatas.Count; j++)
				{
					if (propertyDatas[i].Equals(propertyDatas[j]))
					{
						hasDuplicate = true;
						break;
					}
				}
			}
			
			if (hasDuplicate)
			{
				throw new Exception($"PropertyData duplicates MUST NOT exist before setting");
			}
			
			_propertyDatas = propertyDatas;
		}
		
		public List<PropertyData> GetPropertyDatas()
		{
			return _propertyDatas.GetRange(0, _propertyDatas.Count); //return a copy per encapsulation
		}
		
		public void AddPropertyData(PropertyData propertyData)
		{
			int foundIndex = _propertyDatas.FindIndex( nextPropertyData => nextPropertyData.Equals(propertyData));

			if (foundIndex != -1)
			{
				throw new Exception($"PropertyData MUST NOT exist before adding");
			}
			
			_propertyDatas.Add(propertyData);
		}
		
		public void RemovePropertyData(PropertyData propertyData)
		{
			int foundIndex = _propertyDatas.FindIndex( nextPropertyData => nextPropertyData.Equals(propertyData));

			if (foundIndex == -1)
			{
				throw new Exception($"PropertyData MUST exist before removing");
			}
			
			_propertyDatas.Remove(propertyData);
		}
		
		// Event Handlers ---------------------------------


	}
}
