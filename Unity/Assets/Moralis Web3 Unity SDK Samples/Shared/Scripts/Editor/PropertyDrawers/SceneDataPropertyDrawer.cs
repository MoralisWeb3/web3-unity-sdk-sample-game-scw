using MoralisUnity.Samples.Shared.Data.Types;
using UnityEditor;
using UnityEngine;

namespace MoralisUnity.Samples.PropertyDrawers
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
		
		// Fields -----------------------------------------

		// General Methods --------------------------------
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.PropertyField(position, property.FindPropertyRelative("_scene"), label);
		}

		// Event Handlers ---------------------------------
	}
}
