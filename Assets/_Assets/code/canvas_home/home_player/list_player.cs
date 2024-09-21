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
    private void Start()
    {
        load_list_player();
    }

    [SerializeField]
    public List<data_player> save_listdataplayer = new List<data_player>();

    [ContextMenu("save_list_player")]
    public void save_list_player()
    {
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
        string loadedJson = PlayerPrefs.GetString(nameof(save_listdataplayer),"{}");
        savedata_player loadedItemList = JsonUtility.FromJson<savedata_player>(loadedJson);
        save_listdataplayer= loadedItemList.ListString;
    }

}
[Serializable]
public class savedata_player
{
    public List<data_player> ListString;
}