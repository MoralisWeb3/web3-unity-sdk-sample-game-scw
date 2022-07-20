// Decompiled with JetBrains decompiler
// Type: UnityEditor.FilePathAttribute
// Assembly: UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 44A70D1B-13CF-47E2-9810-E30F45FFAE08
// Assembly location: D:\Unity\2021.3.6f1\Editor\Data\Managed\UnityEngine\UnityEditor.CoreModule.dll
// XML documentation location: D:\Unity\2021.3.6f1\Editor\Data\Managed\UnityEngine\UnityEditor.CoreModule.xml

using System;
using MoralisUnity.Sdk.Exceptions;
using UnityEngine;

namespace MoralisUnity.Samples.Shared.Attributes
{
    /// <summary>
    /// Determines root of relative pathing 
    /// </summary>
    public enum CustomFilePathLocation
    {
        PersistentDataPath,
        StreamingAssetsPath
    }


    /// <summary>
    /// Used to add relative paths to objects. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomFilePathAttribute : Attribute
    {
        
        //  Properties ------------------------------------
        public string Filepath { get { return filepath; } }
        public CustomFilePathLocation Location { get { return m_Location; } }

        private string filepath
        {
            get
            {
                if (this.m_FilePath == null && this.m_RelativePath != null)
                {
                    this.m_FilePath = CustomFilePathAttribute.CombineFilePath(this.m_RelativePath, this.m_Location);
                    this.m_RelativePath = (string)null;
                }

                return this.m_FilePath;
            }
        }

        
        //  Fields ----------------------------------------
        private string m_FilePath;
        private string m_RelativePath;
        private CustomFilePathLocation m_Location;

        
        //  Initialization Methods-------------------------
        public CustomFilePathAttribute(string relativePath, CustomFilePathLocation location)
        {
            this.m_RelativePath = !string.IsNullOrEmpty(relativePath)
                ? relativePath
                : throw new ArgumentException("Invalid relative path (it is empty)");
            this.m_Location = location;
        }

        
        //  General Methods -------------------------------
        private static string CombineFilePath(string relativePath, CustomFilePathLocation location)
        {
            if (relativePath[0] == '/')
                relativePath = relativePath.Substring(1);
            switch (location)
            {
                case CustomFilePathLocation.PersistentDataPath:
                    return Application.persistentDataPath + "/" + relativePath;
                case CustomFilePathLocation.StreamingAssetsPath:
                    return Application.streamingAssetsPath + "/" + relativePath;
                default:
                    throw new SwitchDefaultException(location);
            }
        }

        
        public static CustomFilePathAttribute GetCustomFilePathAttribute<T>()
        {
            foreach (object customAttribute in typeof(T).GetCustomAttributes(true))
            {
                CustomFilePathAttribute customFilePathAttribute = customAttribute as CustomFilePathAttribute;
                if (customFilePathAttribute != null)
                    return customFilePathAttribute;
            }

            return null;
        }
    }
}