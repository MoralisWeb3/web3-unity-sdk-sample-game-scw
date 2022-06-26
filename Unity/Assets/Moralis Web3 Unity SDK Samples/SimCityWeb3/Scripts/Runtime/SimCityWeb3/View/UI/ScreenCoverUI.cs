using TMPro;
using UnityEngine;

namespace MoralisUnity.Samples.SimCityWeb3.View.UI
{
	/// <summary>
	/// UI element to cover the full game screen with a "Loading..." type message
	/// </summary>
	public class ScreenCoverUI : MonoBehaviour
	{
		// Properties -------------------------------------
		public bool IsVisible
		{
			get
			{
				return Mathf.Approximately(_canvasGroup.alpha, 1);
			}
			set
			{
				if (value)
				{
					_canvasGroup.alpha = 1;
				}
				else
				{
					_canvasGroup.alpha = 0;
				}
			}
		}
		
		public TMP_Text MessageText { get { return _messageText;}}

		// Fields -----------------------------------------
		[SerializeField]
		private TMP_Text _messageText = null;
		
		[SerializeField]
		private CanvasGroup _canvasGroup = null;
		
		// Unity Methods ----------------------------------
		
		
		// General Methods --------------------------------
		
		
		// Event Handlers ---------------------------------
		
	}
}
