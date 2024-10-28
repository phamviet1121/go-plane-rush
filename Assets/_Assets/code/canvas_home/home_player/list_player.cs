using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class list_player : MonoBehaviour
{
    //public Text tocdo;
    //public Text tocdoquay;
    //public Text giap;
    public quest_list_player quest_list_player;
    private void Start()
    {

    }

    [SerializeField]
    public List<data_player> save_listdataplayer = new List<data_player>();


    public int onestartplayer;
    [ContextMenu("save_onestartplayer")]
    public void save_onestartplayer()
    {
        PlayerPrefs.SetInt(nameof(onestartplayer), onestartplayer);
        PlayerPrefs.Save();
    }
    [ContextMenu("load_onestartplayert")]
    public void load_onestartplayert()
    {
        onestartplayer = PlayerPrefs.GetInt(nameof(onestartplayer), 0);

    }


    [ContextMenu("save_list_player")]
    public void save_list_player()
    {
        // Debug.Log("chayhamsave");
        save_listdataplayer.Clear();

        foreach (var quest in quest_list_player.DataQuestListPlayer)
        {
            //Debug.Log("cochayko");
            var Data_player = new data_player
            {

                id = quest.id,

                trangthaisohuu = quest.trangthaisohuu,

                gia = quest.gia,

                giap = quest.giap,

                tocdoquay = quest.tocdoquay,

                tocdo = quest.tocdo,

            };
            save_listdataplayer.Add(Data_player);
        }
        string json = JsonUtility.ToJson(new savedata_player { ListString = save_listdataplayer });
        PlayerPrefs.SetString(nameof(save_listdataplayer), json);
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        save_list_player();
    }
    [ContextMenu("load_list_player")]
    public void load_list_player()
    {
        string loadedJson = PlayerPrefs.GetString(nameof(save_listdataplayer), "{}");
        savedata_player loadedItemList = JsonUtility.FromJson<savedata_player>(loadedJson);

        if (loadedItemList != null && loadedItemList.ListString != null)
        {
            save_listdataplayer = loadedItemList.ListString;

            quest_list_player.DataQuestListPlayer.Clear();
            foreach (var savedData in save_listdataplayer)
            {
                var quest = new data_quet_player
                {
                    id = savedData.id,

                    trangthaisohuu = savedData.trangthaisohuu,

                    gia = savedData.gia,

                    giap = savedData.giap,

                    tocdoquay = savedData.tocdoquay,

                    tocdo = savedData.tocdo,
                };
                quest_list_player.DataQuestListPlayer.Add(quest);
            }

        }

    }
   

}
[Serializable]
public class savedata_player
{
    public List<data_player> ListString;
}
// ko lien quan gi