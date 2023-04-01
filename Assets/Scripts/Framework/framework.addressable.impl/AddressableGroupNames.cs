using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "AddressableGroupNames", menuName = "Addressables/Group Names", order = 1)]
public class AddressableGroupNames : ScriptableObject
{
    public List<string> GroupNames;
}