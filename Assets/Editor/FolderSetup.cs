using UnityEngine;
using UnityEditor;
using System.IO;


public class FolderSetup
{
    [MenuItem("Tools/Setup Project Folders")]
    public static void SetupProjectFolders()
    {
        // 作成するフォルダのリスト
        string[] folders = new string[] {
            "Animations",
            "Materials",
            "Models",
            "Prefabs",
            "Scripts",
            "Scenes",
            "Textures",
            "Audio",
            "Resources",
            "Editor",
            "Plugins",
            "Shaders",
            "UI",
            "Documentation"
        };
        // Assetsフォルダ内に各フォルダを作成
        foreach (string folder in folders)
        {
            string folderPath = Path.Combine("Assets", folder);
            if (!Directory.Exists(folderPath))
            {
                AssetDatabase.CreateFolder("Assets", folder);
                Debug.Log($"Created folder: {folderPath}");
            }
            else
            {
                Debug.Log($"Folder already exists: {folderPath}");
            }
        }

        // プロジェクトを更新
        AssetDatabase.Refresh();
    }
}