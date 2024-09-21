using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data_list : MonoBehaviour
{
    [SerializeField]
    public quest_list quest_list;

    [SerializeField]
    public List<save_quest> saveDataQuest = new List<save_quest>();
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [ContextMenu("save")]
    public void save()
    {
       // Debug.Log("chayhamsave");
        saveDataQuest.Clear();

        foreach (var quest in quest_list.dataquestslist)
        {
            //Debug.Log("cochayko");
            var savequest = new save_quest
            {

                id = quest.id,
                anh_img = quest.anh_img,
                ten_nhienvu_txt = quest.ten_nhienvu_txt,
                tiendo_txt = quest.tiendo_txt,
                tiendo_hoanthanh_txt = quest.tiendo_hoanthanh_txt,
                thongtin_nv_txt=quest.thongtin_nv_txt,
                thuong_sao_txt=quest.thuong_sao_txt,
                trangthai_txt = quest.trangthai_txt
            };
            saveDataQuest.Add(savequest);
        }
        string json = JsonUtility.ToJson(new SaveQuestDataList { ListString = saveDataQuest });
        PlayerPrefs.SetString("saveDataQuest", json);
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        save();
    }

    [ContextMenu("LoadAll")]
    public void LoadAll()
    {
        string json = PlayerPrefs.GetString("saveDataQuest", "{}");
        SaveQuestDataList loadedData = JsonUtility.FromJson<SaveQuestDataList>(json);

        if (loadedData != null && loadedData.ListString != null)
        {
            saveDataQuest = loadedData.ListString;


            quest_list.dataquestslist.Clear();
            foreach (var savedData in saveDataQuest)
            {
                var quest = new dataquest
                {
                    id = savedData.id,
                    anh_img = savedData.anh_img,
                    ten_nhienvu_txt = savedData.ten_nhienvu_txt,
                    tiendo_txt = savedData.tiendo_txt,
                    tiendo_hoanthanh_txt = savedData.tiendo_hoanthanh_txt,
                    thongtin_nv_txt = savedData.thongtin_nv_txt,
                    thuong_sao_txt=savedData.thuong_sao_txt,
                    trangthai_txt = savedData.trangthai_txt
                };
                quest_list.dataquestslist.Add(quest);
            }
        }


    }
}
[Serializable]
public class SaveQuestDataList
{
    public List<save_quest> ListString;
}