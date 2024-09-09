using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class view_quest : MonoBehaviour
{
    public quest_list Quest_list;
    public data_list Ddatalist;
    public get_quest get_Quest;
    public Transform vitri;
    public GameObject mau;
    private Dictionary<int, get_quest> questDictionary = new Dictionary<int, get_quest>();
    // Start is called before the first frame update
    public void Start()
    {
        Ddatalist.LoadAll();
        foreach (var data in Quest_list.dataquestslist)
        {
    
            taora(data);
        }
        mau.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void taora(dataquest dataquest)
    {
        var quest = Instantiate(get_Quest, vitri);
        quest.Setdata(dataquest);
        questDictionary[dataquest.id] = quest;
    }
    public void CapNhatGiaoDien(int id)
    {
        if (questDictionary.TryGetValue(id, out get_quest quest))
        {
           
            var data = Quest_list.dataquestslist.Find(d => d.id == id);
            if (data != null)
            {
                quest.Setdata(data);
            }
        }
    }
}
