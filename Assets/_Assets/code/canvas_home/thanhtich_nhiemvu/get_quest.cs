using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class get_quest : MonoBehaviour
{
    public dataquest Dataquest;
    public Image icon_img;
    public TextMeshProUGUI ten_nhiemvu_text;
    //public Text tiendo_text;
    //public Text tiendo_hoanthanh_text;
    //public Text thongtin_nv_text;
    public TextMeshProUGUI thuong_sao_text;
    public TextMeshProUGUI nhiemvufull_txt;
    public void Setdata(dataquest dataquest)
    {
        this.Dataquest = dataquest;

        updateUI();
       
    }
    public void updateUI()
    {
        icon_img.sprite = Dataquest.anh_img;
        ten_nhiemvu_text.text = Dataquest.ten_nhienvu_txt;
       // tiendo_text.text = Dataquest.tiendo_txt;
       // tiendo_hoanthanh_text.text = Dataquest.tiendo_hoanthanh_txt;
        //thongtin_nv_text.text= Dataquest.thongtin_nv_txt;
        thuong_sao_text.text = Dataquest.thuong_sao_txt;
        nhiemvufull_txt.text = ($"{Dataquest.tiendo_txt} out of {Dataquest.tiendo_hoanthanh_txt} {Dataquest.thongtin_nv_txt} ");


    }
}
