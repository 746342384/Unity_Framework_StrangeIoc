using System;
using System.IO;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

public class AddressableAssetAutomation : MonoBehaviour
{
    private const string BaseFolderPath = "Assets/ResPackage";

    [MenuItem("Assets/Add Selected to Addressable Group", true)]
    private static bool ValidateAddSelectedToAddressablesGroup()
    {
        // 检查当前选中的对象是否为文件夹或资源文件
        return AssetDatabase.IsValidFolder(AssetDatabase.GetAssetPath(Selection.activeObject)) ||
               !string.IsNullOrEmpty(AssetDatabase.GetAssetPath(Selection.activeObject));
    }

    [MenuItem("Assets/Add Selected to Addressable Group")]
    public static void AddSelectedToAddressablesGroup()
    {
        // 获取选中的对象路径
        var selectedPath = AssetDatabase.GetAssetPath(Selection.activeObject);

        // 获取选中对象的父文件夹路径

        if (!selectedPath.StartsWith(BaseFolderPath))
        {
            Debug.LogError("Selected item is not inside the 'Assets/ResPackage' folder.");
            return;
        }

        if (selectedPath.Equals(BaseFolderPath))
        {
            var groupNames = Directory.GetDirectories(selectedPath, "*", SearchOption.TopDirectoryOnly);
            foreach (var path in groupNames)
            {
                var groupName = GetGroupName(path);
                AddGroup(groupName, path);
            }
        }
        else
        {
            var groupName = GetGroupName(selectedPath);
            AddGroup(groupName, selectedPath);
        }
    }

    private static string GetGroupName(string selectedPath)
    {
        var replace = selectedPath.Replace("\\", "/");
        var folderPath = BaseFolderPath + "/";
        var startIndex = replace.IndexOf(folderPath, StringComparison.Ordinal) + folderPath.Length;
        var result = replace[startIndex..];
        var endIndex = result.IndexOf('/');
        var groupName = endIndex == -1 ? result : result[..endIndex];
        return groupName;
    }

    private static void AddGroup(string groupName, string selectedPath)
    {
        // 获取Addressable Asset Settings
        var settings = AddressableAssetSettingsDefaultObject.Settings;

        // 查找或创建组
        var group = settings.FindGroup(groupName);
        if (group == null)
        {
            group = settings.CreateGroup(groupName, false, false, true, settings.DefaultGroup.Schemas);
        }

        var labels = settings.GetLabels();
        if (!labels.Contains(groupName))
        {
            settings.AddLabel(groupName);
        }

        // 获取所有要添加到组的资源文件路径
        var assetPaths = AssetDatabase.IsValidFolder(selectedPath)
            ? Directory.GetFiles(selectedPath, "*", SearchOption.AllDirectories)
            : new[] { selectedPath };

        // 将资源添加到组并应用标签
        foreach (var assetPath in assetPaths)
        {
            if (AssetDatabase.IsValidFolder(assetPath)) continue;

            var guid = AssetDatabase.AssetPathToGUID(assetPath);
            var entry = settings.CreateOrMoveEntry(guid, group, false, false);
            entry?.SetLabel(groupName, true);
        }

        // 保存设置
        settings.SetDirty(AddressableAssetSettings.ModificationEvent.BatchModification, null, true);
    }
}