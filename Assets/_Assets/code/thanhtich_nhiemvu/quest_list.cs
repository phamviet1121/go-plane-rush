using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DataList", menuName = "ScriptableObjects/Quests", order = 1)]

public class quest_list : ScriptableObject
{
    [SerializeField]
    public List<dataquest> dataquestslist;
}
