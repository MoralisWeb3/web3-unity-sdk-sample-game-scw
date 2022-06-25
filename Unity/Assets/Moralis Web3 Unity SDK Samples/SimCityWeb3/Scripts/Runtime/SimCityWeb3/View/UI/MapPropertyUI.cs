using Microsoft.Maps.Unity;
using MoralisUnity.Samples.SimCityWeb3.Model;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
using UnityEngine;
using UnityEngine.Events;

namespace MoralisUnity.Samples.SimCityWeb3.View.UI
{
	/// <summary>
	/// Fired when MapPropertyUI is clicked 
	/// </summary>
	public class MapPropertyUIUnityEvent : UnityEvent<MapPropertyUI> {}
	
	/// <summary>
	/// The UI representation of one real-estate property in the game
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
			OnClicked.Invoke(this);
		}


		// General Methods --------------------------------
	
		
		// Event Handlers ---------------------------------
	}
}
