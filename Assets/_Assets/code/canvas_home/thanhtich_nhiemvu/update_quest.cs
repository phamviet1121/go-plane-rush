using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class update_quest : MonoBehaviour
{
    public quest_list quest_list;
    public data_list datalist;
    //  public InputField idd;
    // public InputField tiendo;
    // public Button capnhat;

    public database_save_play_thanhtich database_save_play_thanhtich;
    public list_sao list_sao;
    //public void OnCollisionEnter2D(Collision2D collision)
    //{

    //}
    public void OnCapnhatClick()
    {
        //int a = int.Parse(idd.text);
        foreach (var data in quest_list.dataquestslist)
        {
            //if (data.id == a)
            //{
            //    data.tiendo_txt = tiendo.text;
            //    if (int.Parse(data.tiendo_txt.ToString()) >= int.Parse(data.tiendo_hoanthanh_txt.ToString()))
            //    {
            //        data.tiendo_txt = data.tiendo_hoanthanh_txt;
            //        Debug.Log("dahoanthanh");
            //        if (data.trangthai_txt != "danhan")
            //        {
            //            data.trangthai_txt = "dahoanthanh";
            //            if (data.trangthai_txt == "dahoanthanh")
            //            {
            //                sao += int.Parse(data.thuong_sao_txt);
            //                data.trangthai_txt = "danhan";
            //            }
            //        }


            //    }
            //    else
            //    {
            //        data.trangthai_txt = "CHUAHOANTHANH";
            //        Debug.Log("CHUA HOAN THANH DAU");
            //    }
            //    //FindObjectOfType<click_btn>().UpdateButtonState(data.id);
            //}
            if (data.ten_nhienvu_txt == "Long-liver")
            {
                if (database_save_play_thanhtich.minutes >= int.Parse(data.tiendo_txt.ToString()))
                {
                    data.tiendo_txt = database_save_play_thanhtich.minutes.ToString();
                }

                if (int.Parse(data.tiendo_txt.ToString()) >= int.Parse(data.tiendo_hoanthanh_txt.ToString()))
                {
                    data.tiendo_txt = data.tiendo_hoanthanh_txt;
                   
                    if (data.trangthai_txt != "danhan")
                    {
                        data.trangthai_txt = "dahoanthanh";
                        if (data.trangthai_txt == "dahoanthanh")
                        {
                            list_sao.save_int_sao += int.Parse(data.thuong_sao_txt);
                            list_sao.save_sao();
                            list_sao.load_sao();
                            data.trangthai_txt = "danhan";
                        }
                    }


                }
                else
                {
                    data.trangthai_txt = "CHUAHOANTHANH";
                   
                }
            }


            if (data.ten_nhienvu_txt == "Fighter")
            {
                int tiendo = int.Parse(data.tiendo_txt);
                tiendo += database_save_play_thanhtich.rocketsCollide;
                data.tiendo_txt = tiendo.ToString();

                if (int.Parse(data.tiendo_txt.ToString()) >= int.Parse(data.tiendo_hoanthanh_txt.ToString()))
                {
                    data.tiendo_txt = data.tiendo_hoanthanh_txt;
                    
                    if (data.trangthai_txt != "danhan")
                    {
                        data.trangthai_txt = "dahoanthanh";
                        if (data.trangthai_txt == "dahoanthanh")
                        {
                            list_sao.save_int_sao += int.Parse(data.thuong_sao_txt);
                            list_sao.save_sao();
                            list_sao.load_sao();
                            data.trangthai_txt = "danhan";
                        }
                    }


                }
                else
                {
                    data.trangthai_txt = "CHUAHOANTHANH";
                  
                }
            }




            if (data.ten_nhienvu_txt == "Treasurer")
            {
                int tiendo = int.Parse(data.tiendo_txt);
                tiendo += database_save_play_thanhtich.starCollide;
                data.tiendo_txt = tiendo.ToString();

                if (int.Parse(data.tiendo_txt.ToString()) >= int.Parse(data.tiendo_hoanthanh_txt.ToString()))
                {
                    data.tiendo_txt = data.tiendo_hoanthanh_txt;
                   
                    if (data.trangthai_txt != "danhan")
                    {
                        data.trangthai_txt = "dahoanthanh";
                        if (data.trangthai_txt == "dahoanthanh")
                        {
                            list_sao.save_int_sao += int.Parse(data.thuong_sao_txt);
                            list_sao.save_sao();
                            list_sao.load_sao();
                            data.trangthai_txt = "danhan";
                        }
                    }


                }
                else
                {
                    data.trangthai_txt = "CHUAHOANTHANH";
                  
                }
            }



            if (data.ten_nhienvu_txt == "Flash")
            {
                int tiendo = int.Parse(data.tiendo_txt);
                tiendo += database_save_play_thanhtich.speedCollide;
                data.tiendo_txt = tiendo.ToString();

                if (int.Parse(data.tiendo_txt.ToString()) >= int.Parse(data.tiendo_hoanthanh_txt.ToString()))
                {
                    data.tiendo_txt = data.tiendo_hoanthanh_txt;
                    //Debug.Log("dahoanthanh");
                    if (data.trangthai_txt != "danhan")
                    {
                        data.trangthai_txt = "dahoanthanh";
                        if (data.trangthai_txt == "dahoanthanh")
                        {
                            list_sao.save_int_sao += int.Parse(data.thuong_sao_txt);
                            list_sao.save_sao();
                            list_sao.load_sao();
                            data.trangthai_txt = "danhan";
                        }
                    }


                }
                else
                {
                    data.trangthai_txt = "CHUAHOANTHANH";
                    //Debug.Log("CHUA HOAN THANH DAU");
                }
            }


            if (data.ten_nhienvu_txt == "Toughie")
            {
                int tiendo = int.Parse(data.tiendo_txt);
                tiendo += database_save_play_thanhtich.armorCollide;
                data.tiendo_txt = tiendo.ToString();

                if (int.Parse(data.tiendo_txt.ToString()) >= int.Parse(data.tiendo_hoanthanh_txt.ToString()))
                {
                    data.tiendo_txt = data.tiendo_hoanthanh_txt;
                  //  Debug.Log("dahoanthanh");
                    if (data.trangthai_txt != "danhan")
                    {
                        data.trangthai_txt = "dahoanthanh";
                        if (data.trangthai_txt == "dahoanthanh")
                        {
                            list_sao.save_int_sao += int.Parse(data.thuong_sao_txt);
                            list_sao.save_sao();
                            list_sao.load_sao();
                            data.trangthai_txt = "danhan";
                        }
                    }


                }
                else
                {
                    data.trangthai_txt = "CHUAHOANTHANH";
                 //   Debug.Log("CHUA HOAN THANH DAU");
                }
            }
            if (data.ten_nhienvu_txt == "Instant death")
            {
                int tiendo = int.Parse(data.tiendo_txt);
                tiendo += database_save_play_thanhtich.destructionCollide;
                data.tiendo_txt = tiendo.ToString();

                if (int.Parse(data.tiendo_txt.ToString()) >= int.Parse(data.tiendo_hoanthanh_txt.ToString()))
                {
                    data.tiendo_txt = data.tiendo_hoanthanh_txt;
                   // Debug.Log("dahoanthanh");
                    if (data.trangthai_txt != "danhan")
                    {
                        data.trangthai_txt = "dahoanthanh";
                        if (data.trangthai_txt == "dahoanthanh")
                        {
                            list_sao.save_int_sao += int.Parse(data.thuong_sao_txt);
                            list_sao.save_sao();
                            list_sao.load_sao();
                            data.trangthai_txt = "danhan";
                        }
                    }


                }
                else
                {
                    data.trangthai_txt = "CHUAHOANTHANH";
                   // Debug.Log("CHUA HOAN THANH DAU");
                }
            }
           


        }
       // datalist.save();
       
        //foreach (var data in quest_list.dataquestslist)
        //{
        //    FindObjectOfType<view_quest>().CapNhatGiaoDien(data.id);
        //}
    }


    //RESET
    public void OnRESETClick()
    {
        //int a = int.Parse(idd.text);
        foreach (var data in quest_list.dataquestslist)
        {
            
            if (data.ten_nhienvu_txt == "Long-liver")
            {
              
                    data.tiendo_txt = "0";
                

                if (int.Parse(data.tiendo_txt.ToString()) >= int.Parse(data.tiendo_hoanthanh_txt.ToString()))
                {
                    data.tiendo_txt = data.tiendo_hoanthanh_txt;

                    if (data.trangthai_txt != "danhan")
                    {
                        data.trangthai_txt = "dahoanthanh";
                        if (data.trangthai_txt == "dahoanthanh")
                        {
                            list_sao.save_int_sao += int.Parse(data.thuong_sao_txt);
                            list_sao.save_sao();
                            list_sao.load_sao();
                            data.trangthai_txt = "danhan";
                        }
                    }


                }
                else
                {
                    data.trangthai_txt = "CHUAHOANTHANH";

                }
            }


            if (data.ten_nhienvu_txt == "Fighter")
            {

                data.tiendo_txt = "0";

                if (int.Parse(data.tiendo_txt.ToString()) >= int.Parse(data.tiendo_hoanthanh_txt.ToString()))
                {
                    data.tiendo_txt = data.tiendo_hoanthanh_txt;

                    if (data.trangthai_txt != "danhan")
                    {
                        data.trangthai_txt = "dahoanthanh";
                        if (data.trangthai_txt == "dahoanthanh")
                        {
                            list_sao.save_int_sao += int.Parse(data.thuong_sao_txt);
                            list_sao.save_sao();
                            list_sao.load_sao();
                            data.trangthai_txt = "danhan";
                        }
                    }


                }
                else
                {
                    data.trangthai_txt = "CHUAHOANTHANH";

                }
            }




            if (data.ten_nhienvu_txt == "Treasurer")
            {
                data.tiendo_txt = "0";

                if (int.Parse(data.tiendo_txt.ToString()) >= int.Parse(data.tiendo_hoanthanh_txt.ToString()))
                {
                    data.tiendo_txt = data.tiendo_hoanthanh_txt;

                    if (data.trangthai_txt != "danhan")
                    {
                        data.trangthai_txt = "dahoanthanh";
                        if (data.trangthai_txt == "dahoanthanh")
                        {
                            list_sao.save_int_sao += int.Parse(data.thuong_sao_txt);
                            list_sao.save_sao();
                            list_sao.load_sao();
                            data.trangthai_txt = "danhan";
                        }
                    }


                }
                else
                {
                    data.trangthai_txt = "CHUAHOANTHANH";

                }
            }



            if (data.ten_nhienvu_txt == "Flash")
            {
                data.tiendo_txt = "0";

                if (int.Parse(data.tiendo_txt.ToString()) >= int.Parse(data.tiendo_hoanthanh_txt.ToString()))
                {
                    data.tiendo_txt = data.tiendo_hoanthanh_txt;
                    //Debug.Log("dahoanthanh");
                    if (data.trangthai_txt != "danhan")
                    {
                        data.trangthai_txt = "dahoanthanh";
                        if (data.trangthai_txt == "dahoanthanh")
                        {
                            list_sao.save_int_sao += int.Parse(data.thuong_sao_txt);
                            list_sao.save_sao();
                            list_sao.load_sao();
                            data.trangthai_txt = "danhan";
                        }
                    }


                }
                else
                {
                    data.trangthai_txt = "CHUAHOANTHANH";
                    //Debug.Log("CHUA HOAN THANH DAU");
                }
            }


            if (data.ten_nhienvu_txt == "Toughie")
            {
                data.tiendo_txt = "0";

                if (int.Parse(data.tiendo_txt.ToString()) >= int.Parse(data.tiendo_hoanthanh_txt.ToString()))
                {
                    data.tiendo_txt = data.tiendo_hoanthanh_txt;
                    //  Debug.Log("dahoanthanh");
                    if (data.trangthai_txt != "danhan")
                    {
                        data.trangthai_txt = "dahoanthanh";
                        if (data.trangthai_txt == "dahoanthanh")
                        {
                            list_sao.save_int_sao += int.Parse(data.thuong_sao_txt);
                            list_sao.save_sao();
                            list_sao.load_sao();
                            data.trangthai_txt = "danhan";
                        }
                    }


                }
                else
                {
                    data.trangthai_txt = "CHUAHOANTHANH";
                    //   Debug.Log("CHUA HOAN THANH DAU");
                }
            }
            if (data.ten_nhienvu_txt == "Instant death")
            {
                data.tiendo_txt = "0";

                if (int.Parse(data.tiendo_txt.ToString()) >= int.Parse(data.tiendo_hoanthanh_txt.ToString()))
                {
                    data.tiendo_txt = data.tiendo_hoanthanh_txt;
                    // Debug.Log("dahoanthanh");
                    if (data.trangthai_txt != "danhan")
                    {
                        data.trangthai_txt = "dahoanthanh";
                        if (data.trangthai_txt == "dahoanthanh")
                        {
                            list_sao.save_int_sao += int.Parse(data.thuong_sao_txt);
                            list_sao.save_sao();
                            list_sao.load_sao();
                            data.trangthai_txt = "danhan";
                        }
                    }


                }
                else
                {
                    data.trangthai_txt = "CHUAHOANTHANH";
                    // Debug.Log("CHUA HOAN THANH DAU");
                }
            }



        }
       // datalist.save();

       
    }
}