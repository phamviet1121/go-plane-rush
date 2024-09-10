using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class update_quest : MonoBehaviour
{
    public quest_list quest_list;
    public data_list datalist;
    public InputField idd;
    public InputField tiendo;
    public Button capnhat;
    //public void OnCollisionEnter2D(Collision2D collision)
    //{

    //}
    public void OnCapnhatClick()
    {
        int a = int.Parse(idd.text);
        foreach (var data in quest_list.dataquestslist)
        {
            if (data.id == a)
            {
                data.tiendo_txt = tiendo.text;
                if (int.Parse(data.tiendo_txt.ToString()) >= int.Parse(data.tiendo_hoanthanh_txt.ToString()))
                {
                    data.tiendo_txt = data.tiendo_hoanthanh_txt;
                    Debug.Log("dahoanthanh");
                    data.trangthai_txt = "DANHAN";

                }
                else
                {
                    data.trangthai_txt = "CHUAHOANTHANH";
                    Debug.Log("CHUA HOAN THANH DAU");
                }
                //FindObjectOfType<click_btn>().UpdateButtonState(data.id);
            }

        }
        datalist.save();
        //FindObjectOfType<view_quest>().CapNhatGiaoDien();
        FindObjectOfType<view_quest>().CapNhatGiaoDien(a);
    }
}
