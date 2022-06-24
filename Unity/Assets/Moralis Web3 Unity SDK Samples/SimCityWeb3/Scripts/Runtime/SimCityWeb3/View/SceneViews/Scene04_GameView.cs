using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Microsoft.Geospatial;
using Microsoft.Maps.Unity;
using MoralisUnity.Platform.Objects;
using MoralisUnity.Samples.SimCityWeb3.Model.Data.Types;
using MoralisUnity.Sdk.Exceptions;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS1998
namespace MoralisUnity.Samples.SimCityWeb3.View.UI
{
	public enum GameMode
	{
		Null,
		Default,
		Buying,
		Selecting,
		Selling
	}
	
	/// <summary>
	/// Replace with comments...
	/// </summary>
	public class Scene04_GameView : BaseSceneView
	{
		// Properties -------------------------------------
		private GameMode GameMode
		{
			get { return ___gameMode; }
			set { ___gameMode = value; RefreshUI();}
		}

		// Fields -----------------------------------------
		[Header ("References (Scene)")]
		[SerializeField] 
		private MapUI _mapUI = null;
		
		[SerializeField] 
		private Button _backButton = null;

		[SerializeField] 
		private Button _centerButton = null;

		[SerializeField] 
		private Button _zoomInButton = null;

		[SerializeField] 
		private Button _zoomOutButton = null;

		[SerializeField] 
		private Button _buyButton = null;

		[SerializeField] 
		private Button _sellButton = null;

		[SerializeField] 
		private Button _acceptButton = null;

		[SerializeField] 
		private Button _cancelButton = null;

		private MapPropertyUI _pendingCreationMapPropertyUI = null;
		private MapPropertyUI _pendingSellingMapPropertyUI = null;
		private List<MapPropertyUI> _mapPropertyUIs = new List<MapPropertyUI>();
		private LatLon _mapUICenterOnStart = new LatLon();
		private float _mapUIZoomLevelOnStart = 0;
		
		/// <summary>
		/// Determines the current UI state and the allowable
		/// user gestures
		/// </summary>
		// The "___" means, do not reference this directly. Use property
		private GameMode ___gameMode = GameMode.Null;


		// Unity Methods ----------------------------------
		protected override void Awake ()
		{
			base.Awake();
		}

		
		protected override async void Start()
		{
			base.Start();
			
			// MAP
			_mapUI.IsInteractable = false;
	
			// UI
			RefreshUI();
			_backButton.onClick.AddListener(BackButton_OnClicked);
			_centerButton.onClick.AddListener(CenterButton_OnClicked);
			_zoomInButton.onClick.AddListener(ZoomInButton_OnClicked);
			_zoomOutButton.onClick.AddListener(ZoomOutButton_OnClicked);
			_buyButton.onClick.AddListener(BuyButton_OnClicked);
			_sellButton.onClick.AddListener(SellButton_OnClicked);
			_acceptButton.onClick.AddListener(AcceptButton_OnClicked);
			_cancelButton.onClick.AddListener(CancelButton_OnClicked);
			
			// Moralis
			await SetupMoralis();
			
			// BTW
			SimCityWeb3Singleton.Instantiate();

			// Store defaults, for center button functionality
			_mapUICenterOnStart = _mapUI.MapRenderer.Center;
			_mapUIZoomLevelOnStart = _mapUI.MapRenderer.ZoomLevel;
			
			// Map
			Debug.Log("Start Loading Map");
			await _mapUI.MapRenderer.WaitForLoad();
			Debug.Log("Done Loading Map");
			_mapUI.IsInteractable = true;
			
			// Pins
			RenderPropertyDatas();
			
			GameMode = GameMode.Default;
		}

		
		// General Methods --------------------------------
		private async UniTask SetupMoralis()
		{
			Moralis.Start();
			
			bool hasMoralisUser = await SimCityWeb3Singleton.Instance.HasMoralisUserAsync();
			if (!hasMoralisUser)
			{
				Debug.LogError(SimCityWeb3Constants.ErrorMoralisUserRequired);
			}
		}
		
		
		private void SelectMapPropertyUI(MapPropertyUI mapPropertyUI)
		{
			// Deselect all
			foreach (MapPropertyUI nextMapPropertyUI in _mapPropertyUIs)
			{
				nextMapPropertyUI.IsSelected = false;
			}

			// Maybe, select just one
			if (mapPropertyUI != null)
			{
				mapPropertyUI.IsSelected = true;
					
				// Set camera
				_mapUI.MapRenderer.Center = new LatLon(
					mapPropertyUI.PropertyData.Latitude,
					mapPropertyUI.PropertyData.Longitude);
			}
		}

		
		private async void RefreshUI()
		{
			// Main Buttons
			_backButton.interactable = GameMode == GameMode.Default || GameMode == GameMode.Selecting;
			_centerButton.interactable = _backButton.interactable;
			_zoomInButton.interactable = _backButton.interactable;
			_zoomOutButton.interactable = _backButton.interactable;
			_buyButton.interactable = GameMode == GameMode.Default;
			_sellButton.interactable = GameMode == GameMode.Selecting;
			
			// Map
			_mapUI.IsInteractable = GameMode == GameMode.Default || GameMode == GameMode.Selecting || GameMode == GameMode.Buying;
			
			// Secondary Buttons
			_acceptButton.interactable = GameMode == GameMode.Buying || GameMode == GameMode.Selling;
			_cancelButton.interactable = _acceptButton.interactable;
			SimCityWeb3Helper.SetButtonVisibility(_acceptButton, _acceptButton.interactable);
			SimCityWeb3Helper.SetButtonVisibility(_cancelButton, _cancelButton.interactable);
		}
		
		
		private async void RenderPropertyDatas()
		{
			await SimCityWeb3Singleton.Instance.SimCityWeb3Controller.LoadPropertyDatas();
			
			SimCityWeb3Singleton.Instance.SimCityWeb3Controller.RenderPropertyDatas(this);
		}
		
		
		public async void RenderPropertyData(PropertyData propertyData, bool isPendingAndFloating)
		{
			MapPropertyUI mapPropertyUIPrefab = SimCityWeb3Configuration.Instance.MapPropertyUIPrefab;
			_pendingCreationMapPropertyUI = Instantiate<MapPropertyUI>(mapPropertyUIPrefab);
			_pendingCreationMapPropertyUI.PropertyData = propertyData;
			
			if (isPendingAndFloating)
			{
				// This is pending (User has not yet click 'Accept')
				// So place it an the APPARENT center of the screen
				Transform pendingTransform = _pendingCreationMapPropertyUI.transform;
				pendingTransform.SetParent(_mapUI.MapPropertyUISpawnPoint.transform);
				pendingTransform.localPosition = new Vector3(0, 0, 0);
			}

			if (!isPendingAndFloating)
			{
				AcceptToBuyPropertyUI(_pendingCreationMapPropertyUI, false);
			}
		}
		
		
		private void AcceptToBuyPropertyUI(MapPropertyUI mapPropertyUI, bool wasPendingAndFloating)
		{
			// DataModel - Update position to match center screen
			if (wasPendingAndFloating)
			{
				mapPropertyUI.PropertyData.Latitude = _mapUI.MapRenderer.Center.LatitudeInDegrees;
				mapPropertyUI.PropertyData.Longitude = _mapUI.MapRenderer.Center.LongitudeInDegrees;
			}
			
			// ViewModel - Update position to match center screen
			mapPropertyUI.MapPin.Location = new LatLon(
				mapPropertyUI.PropertyData.Latitude,
				mapPropertyUI.PropertyData.Longitude);
			
			// Activate scrolling-with-map 
			_mapPropertyUIs.Add(mapPropertyUI);
			_mapUI.PropertyMapPinLayer.MapPins.Add(mapPropertyUI.MapPin);
			mapPropertyUI.OnClicked.AddListener(MapPropertyUI_OnClicked);
		}
		
		
		private async UniTask AcceptToSellPropertyUI()
		{
			// Save to the service
			Debug.Log("START DeletePropertyData() ");
			await SimCityWeb3Singleton.Instance.SimCityWeb3Controller.DeletePropertyData(_pendingSellingMapPropertyUI.PropertyData);
			Debug.Log("END DeletePropertyData() ");
			
			// Update the data model
			SimCityWeb3Singleton.Instance.SimCityWeb3Controller.RemovePropertyData(_pendingSellingMapPropertyUI.PropertyData);
			
			// Remove from scrolling-with-map 
			_mapPropertyUIs.Remove(_pendingSellingMapPropertyUI);
			_mapUI.PropertyMapPinLayer.MapPins.Remove(_pendingSellingMapPropertyUI.MapPin);
			_pendingSellingMapPropertyUI.OnClicked.RemoveListener(MapPropertyUI_OnClicked);
			Destroy(_pendingSellingMapPropertyUI.gameObject);
		}


		// Event Handlers ---------------------------------
		private void MapPropertyUI_OnClicked(MapPropertyUI mapPropertyUI)
		{
			if ( GameMode == GameMode.Default || GameMode == GameMode.Selecting)
			{
				PlayAudioClipClick();
				
				_pendingSellingMapPropertyUI = mapPropertyUI;

				// Select one, deselect all others
				SelectMapPropertyUI(_pendingSellingMapPropertyUI);

				GameMode = GameMode.Selecting;
			}
		}


		private async void BuyButton_OnClicked()
		{
			bool hasMoralisUser = await SimCityWeb3Singleton.Instance.HasMoralisUserAsync();
			if (!hasMoralisUser)
			{
				Debug.LogError(SimCityWeb3Constants.ErrorMoralisUserRequired);
			}
			
			PlayAudioClipClick();
			
			GameMode = GameMode.Buying;

			MoralisUser moralisUser = await SimCityWeb3Singleton.Instance.GetMoralisUserAsync();
			PropertyData propertyData = new PropertyData
			(
				ownerAddress : moralisUser.ethAddress,
				latitude : _mapUI.MapRenderer.Center.LatitudeInDegrees,
				longitude : _mapUI.MapRenderer.Center.LongitudeInDegrees
			);
			RenderPropertyData(propertyData, true);

		}
		
		
		private void SellButton_OnClicked()
		{
			PlayAudioClipClick();
			
			GameMode = GameMode.Selling;
		}
		
		
		private async void AcceptButton_OnClicked()
		{
	
			switch (GameMode)
			{
				case GameMode.Buying:
					
					if (_pendingCreationMapPropertyUI == null)
					{
						Debug.Log($"AcceptButtonUI_OnClicked() failed. _pendingCreationMapPropertyUI must not be null.");
					}
					else
					{
						
						PlayAudioClipClick();
						
						// Activate scrolling-with-map
						AcceptToBuyPropertyUI(_pendingCreationMapPropertyUI, true);
			
						// Update the data model
						SimCityWeb3Singleton.Instance.SimCityWeb3Controller.AddPropertyData(_pendingCreationMapPropertyUI.PropertyData);
					
						// Save to the service
						await SimCityWeb3Singleton.Instance.SimCityWeb3Controller.SavePropertyData(_pendingCreationMapPropertyUI.PropertyData);
			
						// Clear pending
						_pendingCreationMapPropertyUI = null;
					}
					break;
				
				case GameMode.Selling:
					
					if (_pendingSellingMapPropertyUI == null)
					{
						Debug.Log($"AcceptButtonUI_OnClicked() failed. _pendingSellingMapPropertyUI must not be null.");
					}
					else
					{
						PlayAudioClipClick();
						
						// Update the data model
						await AcceptToSellPropertyUI();
		
						// Clear pending
						_pendingSellingMapPropertyUI = null;
					}
					break;
				default:
					SwitchDefaultException.Throw(GameMode);
					break;
			}

			GameMode = GameMode.Default;
		}
		
		
		private void CancelButton_OnClicked()
		{
			switch (GameMode)
			{
				case GameMode.Buying:
					
					if (_pendingCreationMapPropertyUI == null)
					{
						Debug.Log($"CancelButtonUI_OnClicked() failed. _pendingCreationMapPropertyUI must not be null.");
					}
					else
					{
						PlayAudioClipClick();
						
						Destroy(_pendingCreationMapPropertyUI.gameObject);
					}
					break;
				
				case GameMode.Selling:
					
					if (_pendingSellingMapPropertyUI == null)
					{
						Debug.Log($"CancelButtonUI_OnClicked() failed. _pendingSellingMapPropertyUI must not be null.");
					}
					else
					{
						PlayAudioClipClick();
						
						// Deselect all 
						SelectMapPropertyUI(null);
					}
					break;
				default:
					SwitchDefaultException.Throw(GameMode);
					break;
			}

			
			GameMode = GameMode.Default;
		}
		
		
		private void BackButton_OnClicked()
		{
			PlayAudioClipClick();
			
			SimCityWeb3Singleton.Instance.SimCityWeb3Controller.LoadIntroScene();
		}
		
		private void CenterButton_OnClicked()
		{
			PlayAudioClipClick();
			
			// Set camera
			_mapUI.MapRenderer.Center = _mapUICenterOnStart;
			_mapUI.MapRenderer.ZoomLevel = _mapUIZoomLevelOnStart;
		}
		
		
		private void ZoomInButton_OnClicked()
		{
			PlayAudioClipClick();
			
			_mapUI.ZoomIn();
		}
		
		
		private void ZoomOutButton_OnClicked()
		{
			PlayAudioClipClick();
			
			_mapUI.ZoomOut();
		}
	
	}
}
