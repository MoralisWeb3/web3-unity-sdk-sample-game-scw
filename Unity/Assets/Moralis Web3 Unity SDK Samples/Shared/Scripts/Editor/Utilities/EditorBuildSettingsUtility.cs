using System.Collections.Generic;
using System.Linq;
using MoralisUnity.Samples.Shared.Data.Types.Storage;
using UnityEditor;

namespace MoralisUnity.Samples.Shared.Utilities
{
    /// <summary>
    /// Helpers for Unity Build settings
    /// </summary>
    public static class EditorBuildSettingsUtility  
    {
        //  Properties ------------------------------------
        
        //  Fields ----------------------------------------
        
        //  Methods ---------------------------------------
        public static void AddScenesToBuildSettings(List<SceneData> sceneDatas)
        {
            // Find valid Scene paths and make a list of EditorBuildSettingsScene
            List<EditorBuildSettingsScene> existingScenes = EditorBuildSettings.scenes.ToList();
            
            foreach (SceneData sceneData in sceneDatas)
            {
                string scenePath = AssetDatabase.GetAssetPath(sceneData.Scene);
                
                // Remove if exists (to improve sort)
                bool alreadyExists = existingScenes.Any(item => item.path == scenePath);
                if (alreadyExists)
                {
                    existingScenes.RemoveAll(item => item.path == scenePath);
                }
                
                // Add 
                if (!string.IsNullOrEmpty(scenePath))
                {
                    existingScenes.Add(new EditorBuildSettingsScene(scenePath, true)); 
                }
            }

            // Set the Build Settings window Scene list
            EditorBuildSettings.scenes = existingScenes.ToArray();
        }
    }
}
