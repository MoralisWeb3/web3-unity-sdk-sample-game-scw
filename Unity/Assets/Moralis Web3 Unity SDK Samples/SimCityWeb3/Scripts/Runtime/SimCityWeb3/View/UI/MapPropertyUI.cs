using Microsoft.Maps.Unity;
using MoralisUnity.Samples.SimCityWeb3.Model;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
using UnityEngine;
using UnityEngine.Events;

namespace MoralisUnity.Samples.SimCityWeb3.View.UI
{
	public class MapPropertyUIUnityEvent : UnityEvent<MapPropertyUI>
	{
		
	}
	
	/// <summary>
	/// Replace with comments...
	/// </summary>
	public class MapPropertyUI : MonoBehaviour
	{
		// Events -----------------------------------------
		public MapPropertyUIUnityEvent OnClicked = new MapPropertyUIUnityEvent();
		
		// Properties -------------------------------------
		public MapPin MapPin { get { return _mapPin;}}
		public PropertyData PropertyData { get { return _propertyData;} set { _propertyData = value;}}

		public bool IsSelected
		{
			get
			{
				return _isSelected;
			}
			set
			{
				_isSelected = value;

				if (_isSelected)
				{
					_renderer.material = _selectedMaterial;
				}
				else
				{
					_renderer.material = _unselectedMaterial;
				}
			}
		}
		
		// Fields -----------------------------------------
		[SerializeField] 
		private MapPin _mapPin = null;
		
		[SerializeField] 
		private Renderer _renderer = null;
		
		[SerializeField] 
		private Material _selectedMaterial = null;
		
		[SerializeField] 
		private Material _unselectedMaterial = null;

		[SerializeField] 
		[HideInInspector]
		private PropertyData _propertyData = null;

		private bool _isSelected = false;
		
		// Unity Methods ----------------------------------
		protected void Start()
		{
			IsSelected = false;
		}

		protected void OnMouseDown()
		{
			Debug.Log($"Click on {this}");
			OnClicked.Invoke(this);
		}


		// General Methods --------------------------------
	
		
		// Event Handlers ---------------------------------
	}
}
