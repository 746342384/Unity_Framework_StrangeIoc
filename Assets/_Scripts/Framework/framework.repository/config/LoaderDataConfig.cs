using UnityEngine;

[CreateAssetMenu(fileName = "ConfigData", menuName = "Configurations/Config Data", order = 0)]
public class LoaderDataConfig : ScriptableObject
{
    public string Remote;

    public string Local;

    public string Db;

    public ConfigLoaderMode ConfigLoaderMode;
}

public enum ConfigLoaderMode
{
    Remote,
    Local,
    Db
}