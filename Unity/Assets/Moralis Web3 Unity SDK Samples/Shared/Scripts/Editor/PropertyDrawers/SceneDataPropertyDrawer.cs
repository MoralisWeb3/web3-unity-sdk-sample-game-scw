using MoralisUnity.Samples.Shared.Data.Types.Storage;
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

		// Fields -----------------------------------------

		// General Methods --------------------------------
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return base.GetPropertyHeight(property, label) + Pad;
		}
		
		/// <summary>
		/// * The _scene provides drag and drop in the editor. But its not available in a Windows build.
		/// * The _scenePath is available in a windows build
		/// </summary>
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			if (property == null)
			{
				return;
			}
			
			// Render object
			position.height = LineHeight + Pad;
			SerializedProperty _scene = property.FindPropertyRelative("_scene");

			if (_scene == null)
			{
				Debug.LogError("Cant find _sceneName. Fix target class");
				return;
			}
			
			EditorGUI.PropertyField(position, _scene, new GUIContent (property.displayName));
			position.y += LineHeight + Pad; 

			// Update string to match object
			SerializedProperty _sceneName = property.FindPropertyRelative("_sceneName");
			
			if (_sceneName == null)
			{
				Debug.LogError("Cant find _sceneName. Fix target class");
				return;
			}

			if (_sceneName.stringValue != _scene.objectReferenceValue.name)
			{
				_sceneName.stringValue = _scene.objectReferenceValue.name;
				property.serializedObject.ApplyModifiedProperties();
			}
			
			// Optional: Enable to debug the values
			// EditorGUI.BeginDisabledGroup(true);
			// EditorGUI.PropertyField(position, _sceneName, new GUIContent("Name"));
			// EditorGUI.EndDisabledGroup();
		}

		// Event Handlers ---------------------------------
	}
}
