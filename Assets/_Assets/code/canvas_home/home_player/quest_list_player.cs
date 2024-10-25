using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DataList", menuName = "ScriptableObjects/Quests", order = 1)]
public class quest_list_player : ScriptableObject
{
    [SerializeField]
    public List<data_quet_player> DataQuestListPlayer;
}

