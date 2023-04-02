using UnityEngine;

[CreateAssetMenu(fileName = "AddressableGroupNames", menuName = "Addressables/Group Names", order = 1)]
public class GroupNameConfig : ScriptableObject
{
    [SerializeField] public string[] GroupNames;
}