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
	public class Scene02_AuthenticationUI : Scene_BaseUI
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
			
			await SetupMoralisAsync();
			
			SimCityWeb3Singleton.Instantiate();
		}
		
		// General Methods --------------------------------
		private async UniTask SetupMoralisAsync()
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
			SimCityWeb3Singleton.Instance.SimCityWeb3Controller.PlayAudioClipClick();
			
			SimCityWeb3Singleton.Instance.SimCityWeb3Controller.LoadIntroSceneAsync();
		}
		
		private async void AuthenticationKit_OnStateChanged(AuthenticationKitState authenticationKitState)
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
					// Wait for cosmetics
					await UniTask.Delay(1000);
					
					// The user went from LOGGED OUT TO LOGGED IN
					// Success! So go back to the previous scene
					SimCityWeb3Singleton.Instance.SimCityWeb3Controller.LoadIntroSceneAsync();
				}
				else if (_wasLoggedInAtSetupMoralis == true &&
				         authenticationKitState == AuthenticationKitState.Initialized)
				{
					
					// Wait for cosmetics
					await UniTask.Delay(1000);
					
					// The user went from LOGGED IN TO LOGGED OUT
					// Success! So go back to the previous scene
					SimCityWeb3Singleton.Instance.SimCityWeb3Controller.LoadIntroSceneAsync();
				}
			}
		}
	}
}
