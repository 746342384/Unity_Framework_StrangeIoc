using System.Linq;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEngine;

public class SaveAddressableGroupNames : UnityEditor.Editor
{
    [MenuItem("Addressable/Save Group Names")]
    public static void SaveGroupNames()
    {
        var groupNamesObject = Resources.Load<GroupNameConfig>("AddressableGroupNames");
        if (groupNamesObject == null)
        {
            Debug.LogError(
                $"not load [AddressableGroupNames] [ScriptableObject] in resources fileFolder,please create [AddressableGroupNames] [ScriptableObject] in resources");
            return;
        }

        var addressableAssetGroups = AddressableAssetSettingsDefaultObject.Settings.groups;
        groupNamesObject.GroupNames = (from addressableAssetGroup in addressableAssetGroups
            where !addressableAssetGroup.ReadOnly
            select addressableAssetGroup.Name).ToArray();
        EditorUtility.SetDirty(groupNamesObject);
        AssetDatabase.SaveAssetIfDirty(groupNamesObject);
        AssetDatabase.Refresh();
    }
}