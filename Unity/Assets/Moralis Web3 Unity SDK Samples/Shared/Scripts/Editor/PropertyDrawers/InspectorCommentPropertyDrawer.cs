using MoralisUnity.Samples.Shared.Attributes;
using UnityEditor;
using UnityEngine;

namespace MoralisUnity.Samples.Shared.PropertyDrawers
{
	/// <summary>
	/// Renders the <see cref="InspectorCommentAttribute"/> comment
	/// </summary>
	[CustomPropertyDrawer(typeof(InspectorCommentAttribute))]
	public class InspectorCommentPropertyDrawer : PropertyDrawer
	{
		// Properties -------------------------------------
		InspectorCommentAttribute _inspectorCommentAttribute { get { return (InspectorCommentAttribute)attribute; } }

		
		// Fields -----------------------------------------
		private const float LineHeight = 20;

		
		// General Methods --------------------------------
		public override float GetPropertyHeight(SerializedProperty prop, GUIContent label) 
		{
			return LineHeight;
		}
		
		public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
		{
			EditorGUI.BeginDisabledGroup(true);
			EditorGUI.TextArea(position, _inspectorCommentAttribute.Comment);
			EditorGUI.EndDisabledGroup();
		}

		
		// Event Handlers ---------------------------------
	}
}
