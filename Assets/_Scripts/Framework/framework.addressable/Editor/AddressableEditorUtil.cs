using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Editor
{
    public class AddressableEditorUtil : UnityEditor.Editor
    {
        [MenuItem("Addressable/Clear Addressable Cache")]
        public static void ClearAddressableCache()
        {
            Caching.ClearCache();
        }

        [MenuItem("Addressable/Open Addressable RemoteBuild Path")]
        public static void OpenRemoteBuildPath()
        {
            var fullPath = OpenBuildPath("Remote.BuildPath");
            OpenInFileBrowser(fullPath);
        }

        [MenuItem("Addressable/Open Addressable LocalBuild Path")]
        public static void OpenLocalBuildPath()
        {
            var fullPath = OpenBuildPath("Local.BuildPath");
            OpenInFileBrowser(fullPath);
        }

        private static string OpenBuildPath(string buildType)
        {
            var settings = AddressableAssetSettingsDefaultObject.Settings;

            if (settings == null)
            {
                Debug.LogError("AddressableAssetSettings not found.");
                return string.Empty;
            }

            var buildPathTemplate =
                settings.profileSettings.GetValueByName(settings.activeProfileId, buildType);
            var buildTargetName = GetBuildTargetName();
            var buildPath = buildPathTemplate.Replace("[BuildTarget]", buildTargetName);
            var fullPath = Path.Combine(Application.dataPath, "../", buildPath);
            return fullPath;
        }

        private static string GetBuildTargetName()
        {
            var buildTarget = EditorUserBuildSettings.activeBuildTarget;
            return buildTarget.ToString();
        }

        [MenuItem("Addressable/Open Sandbox Path")]
        public static void OpenSandboxPath()
        {
            var path = "";

            switch (Application.platform)
            {
                // 根据平台选择沙盒路径
                case RuntimePlatform.WindowsEditor:
                {
                    var localAppData =
                        System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
                    var fullName = Directory.GetParent(localAppData)?.FullName;
                    if (fullName != null)
                    {
                        var localLowPath = Path.Combine(fullName, "LocalLow");
                        path = Path.Combine(localLowPath, "Unity",
                            $"{Application.companyName}_{Application.productName}");
                    }

                    break;
                }
                case RuntimePlatform.OSXEditor:
                    path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                        "Library/Application Support", Application.companyName, Application.productName);
                    break;
                case RuntimePlatform.LinuxEditor:
                    path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                        ".config/unity3d", Application.companyName, Application.productName);
                    break;
                default:
                    Debug.LogError("Project Sandbox path is not supported on this platform.");
                    return;
            }

            // 打开文件浏览器
            OpenInFileBrowser(path);
        }

        private static void OpenInFileBrowser(string path)
        {
            // 根据平台选择打开文件浏览器的方式
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                Process.Start("explorer.exe", $"/open,{Path.GetFullPath(path)}");
            }
            else if (Application.platform == RuntimePlatform.OSXEditor)
            {
                Process.Start("open", $"\"{path}\"");
            }
            else if (Application.platform == RuntimePlatform.LinuxEditor)
            {
                Process.Start("xdg-open", $"\"{path}\"");
            }
            else
            {
                Debug.LogError("File browser is not supported on this platform.");
            }
        }
    }
}