using Cysharp.Threading.Tasks;
using MoralisUnity.Kits.AuthenticationKit;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS1998
namespace MoralisUnity.Samples.SimCityWeb3.View.UI
{
	/// <summary>
	/// Main Entry Point For: Scene02_Authentication
	/// </summary>
	public class Scene02_AuthenticationView : BaseSceneView
	{
		// Properties -------------------------------------
		
		
		// Fields -----------------------------------------
		[Header("More")]
		[SerializeField] 
		private AuthenticationKit _authenticationKit = null;
		
		[SerializeField] 
		private RectTransform _authenticationKitRectTransform = null;

		[SerializeField] 
		private Button _cancelButtonUI = null;

		private bool _wasLoggedInAtSetupMoralis = false;
		
		// Unity Methods ----------------------------------
		protected override void Awake ()
		{
			base.Awake();
			_authenticationKit.OnStateChanged.AddListener(AuthenticationKit_OnStateChanged);
			_cancelButtonUI.onClick.AddListener(CancelButtonUI_OnClicked);

		}

		protected override async void Start()
		{
			base.Start();
			
			await SetupMoralis();
			
			SimCityWeb3Singleton.Instantiate();
		}
		
		// General Methods --------------------------------
		private async UniTask SetupMoralis()
		{
			Moralis.Start();
			
			// Move Layout Upwards to allow for custom "Cancel" Button
			_authenticationKitRectTransform.offsetMin = new Vector2(0, 50);
			
			// 
			_wasLoggedInAtSetupMoralis = await SimCityWeb3Singleton.Instance.HasMoralisUserAsync();
		}

		// Event Handlers ---------------------------------
		private void CancelButtonUI_OnClicked()
		{
			PlayAudioClipClick();
			
			SimCityWeb3Singleton.Instance.SimCityWeb3Controller.LoadPreviousScene();
		}
		
		private void AuthenticationKit_OnStateChanged(AuthenticationKitState authenticationKitState)
		{
			// Did you open the scene in the Unity Editor and Press Play?
			// If so, show some helpful state info...
			if (SimCityWeb3Singleton.Instance.WasActiveSceneLoadedDirectly())
			{
				Debug.Log($"State = {authenticationKitState}");
			}
			else
			{
				// Did you open ANOTHER scene in the Unity Editor and Press Play?
				// If so, this scene is designed to handle Auth more completely...
				if (_wasLoggedInAtSetupMoralis == false && 
				    authenticationKitState == AuthenticationKitState.MoralisLoggedIn)
				{
					// You went from NOT LOGGED to CONNECTED...
					// Success! So go back to the previous scene
					SimCityWeb3Singleton.Instance.SimCityWeb3Controller.LoadPreviousScene();
				}
				else if (_wasLoggedInAtSetupMoralis == true &&
				         authenticationKitState == AuthenticationKitState.Disconnected)
				{
					// You went from LOGGED to DISCONNECTED...
					// Success! So go back to the previous scene
					SimCityWeb3Singleton.Instance.SimCityWeb3Controller.LoadPreviousScene();
				}
			}
		}
	}
}
