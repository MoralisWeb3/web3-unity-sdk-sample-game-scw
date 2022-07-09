using MoralisUnity.Samples.Shared.Data.Types;
using UnityEditor;
using UnityEngine;

namespace MoralisUnity.Samples.Shared.PropertyDrawers
{
	/// <summary>
	/// Renders the <see cref="SceneData"/> nicely inside
	/// any MonoBehaviours which contain it.
	///
	/// PROS
	/// * No click-to-unfold arrow in the inspector
	/// 
	/// </summary>
	[CustomPropertyDrawer(typeof(SceneData))]
	public class SceneDataPropertyDrawer : PropertyDrawer
	{
		// Properties -------------------------------------
		private const float LineHeight = 16f;
		private const float Pad = 4f;
		private const float LineCount = 2;

		// Fields -----------------------------------------

		// General Methods --------------------------------
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return base.GetPropertyHeight(property, label) + LineHeight + Pad;
		}


		/// <summary>
		/// * The _scene provides drag and drop in the editor. But its not available in a Windows build.
		/// * The _scenePath is available in a windows build
		/// </summary>
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			// Render object
			position.height = LineHeight + Pad;
			EditorGUI.PropertyField(position, property.FindPropertyRelative("_scene"), new GUIContent ("Scene"));
			position.y += LineHeight + Pad; 

			// Update string to match object
			property.FindPropertyRelative("_sceneName").stringValue = property.FindPropertyRelative("_scene").objectReferenceValue.name;

			// Render string as not editable
			EditorGUI.BeginDisabledGroup(true);
			EditorGUI.PropertyField(position, property.FindPropertyRelative("_sceneName"), new GUIContent("Name"));
			EditorGUI.EndDisabledGroup();
		}

		// Event Handlers ---------------------------------
	}
}
