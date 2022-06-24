using UnityEngine;

namespace MoralisUnity.Samples.Shared.Templates
{
	/// <summary>
	/// Replace with comments...
	/// </summary>
	//[CreateAssetMenu( menuName = Title,  fileName = Title)]
	public class TemplateScriptableObject : ScriptableObject
	{
		
		// Properties -------------------------------------
		public string SamplePublicText
		{
			get { return _samplePublicText; }
		}


		// Fields -----------------------------------------
		private const string Title = "TemplateScriptableObject";
		private string _samplePublicText;


		// Unity Methods ----------------------------------
		protected void OnEnable()
		{

		}

		protected void OnDisable()
		{

		}

		
		// General Methods --------------------------------
		public string SamplePublicMethod(string message)
		{
			return message;
		}

		
		// Event Handlers ---------------------------------
	}
}
