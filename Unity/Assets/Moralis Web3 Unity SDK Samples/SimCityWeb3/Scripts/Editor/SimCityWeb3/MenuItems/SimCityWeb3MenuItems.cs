using System.Collections.Generic;
using MoralisUnity.Examples.Sdk.Shared.Data.Types.Storage;
using MoralisUnity.Samples.Shared.Data.Types.Storage;
using MoralisUnity.Samples.Shared.Utilities;
using MoralisUnity.Sdk.Constants;
using MoralisUnity.Sdk.UI.ReadMe;
using UnityEditor;
using UnityEngine;

namespace MoralisUnity.Samples.SimCityWeb3.Shared
{
	/// <summary>
	/// The MenuItem attribute allows you to add menu items to the main menu and inspector context menus.
	/// <see cref="https://docs.unity3d.com/ScriptReference/MenuItem.html"/>
	/// </summary>
	public static class SimCityWeb3MenuItems
	{
		[MenuItem(MoralisConstants.PathMoralisSamplesWindowMenu + "/" +
			SimCityWeb3Constants.ProjectName + "/" + SimCityWeb3Constants.OpenReadMe, false,
			SimCityWeb3Constants.PriorityMoralisWindow_Examples)]
		public static void OpenReadMe()
		{
			ReadMeEditor.SelectReadmeGuid("3b4d333465945474ea57ff6e62ba4f37");
		}

		
		[MenuItem(MoralisConstants.PathMoralisSamplesWindowMenu + "/" +
		          SimCityWeb3Constants.ProjectName + "/" + "Add Example Scenes To Build Settings", false,
			SimCityWeb3Constants.PriorityMoralisWindow_Examples)]
		public static void AddAllScenesToBuildSettings()
		{
			Resources.FindObjectsOfTypeAll<SceneDataStorage>();
			List<SceneData> sceneDatas = SceneDataStorage.Instance.SceneDatas;

			Debug.Log($"AddAllScenesToBuildSettings() sceneDatas.Count = {sceneDatas.Count}");
			EditorBuildSettingsUtility.AddScenesToBuildSettings(sceneDatas);
		}


		[MenuItem(MoralisConstants.PathMoralisSamplesWindowMenu + "/" +
		          SimCityWeb3Constants.ProjectName + "/" + "Load Example Layout (16x10)", false,
			SimCityWeb3Constants.PriorityMoralisWindow_Examples)]
		public static void LoadExampleLayout()
		{
			string path = AssetDatabase.GUIDToAssetPath("3672d8be4d6ccc5438f509d05d1dd7c0");
			Debug.Log($"LoadExampleLayout() path = {path}");
			UnityReflectionUtility.UnityEditor_WindowLayout_LoadWindowLayout(path);
		}
	}
}
