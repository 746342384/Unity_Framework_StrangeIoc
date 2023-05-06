using System.IO;
using UnityEditor;

public class BuildScript
{
    [MenuItem("Build/Perform Build")]
    public static void PerformBuild()
    {
        var buildPath = "Build"; // 更改为您喜欢的构建输出路径
        string[] scenes = { "Assets/Scenes/Start.unity" }; // 更改为您的项目中使用的场景路径

        if (!Directory.Exists(buildPath))
        {
            Directory.CreateDirectory(buildPath);
        }

        var buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = scenes,
            locationPathName = Path.Combine(buildPath, "StrangeIoc"), // 更改为您的应用名称
            target = BuildTarget.StandaloneWindows64, // 更改为适合您项目的目标平台
            options = BuildOptions.None
        };

        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
}