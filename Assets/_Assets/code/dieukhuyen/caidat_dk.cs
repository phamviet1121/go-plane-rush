using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caidat_dk : MonoBehaviour
{
    public GameObject caidat; // Bật tắt Canvas
    public GameObject home;   // Bật tắt Canvas
    public GameObject play;
    public GameObject tamdung;

    public bool amthanh = true;
    public GameObject ing_amthanh_true; // Bật tắt ảnh
    public GameObject ing_amthanh_false; // Bật tắt ảnh
    public GameObject nutdk; // Bật tắt GameObject
    public GameObject volangdk; // Bật tắt GameObject
    public GameObject chamtaydk; // Bật tắt GameObject
    public GameObject img_nut; // Bật tắt ảnh
    public GameObject img_volang; // Bật tắt ảnh
    public GameObject img_cham; // Bật tắt ảnh
    int dk = 0;

    public GameObject reset; // Bật tắt Canvas

    public bool rung = true;
    public GameObject ing_rung_true; // Bật tắt ảnh
    public GameObject ing_rung_false; // Bật tắt ảnh

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Hàm bật canvas "caidat" và tắt "home"
    public void onclickcaidat()
    {
        home.SetActive(false); // Tắt canvas home
        caidat.SetActive(true); // Bật canvas caidat
    }

    // Hàm tắt canvas "caidat" và bật "home"
    public void offclickcaidat()
    {
        if (play.activeSelf == false)
        {
            home.SetActive(true);  
            caidat.SetActive(false);
        }
        else
        {
            caidat.SetActive(false);
            tamdung.SetActive(true);
        }
      
    }

    // Hàm bật tắt âm thanh
    public void onclickamthanhh()
    {
        if (amthanh)
        {
            amthanh = false;
            ing_amthanh_false.SetActive(true); // Bật ảnh ing_amthanh_false
            ing_amthanh_true.SetActive(false); // Tắt ảnh ing_amthanh_true
        }
        else
        {
            amthanh = true;
            ing_amthanh_false.SetActive(false); // Tắt ảnh ing_amthanh_false
            ing_amthanh_true.SetActive(true); // Bật ảnh ing_amthanh_true
        }
    }

    // Hàm điều khiển player
    public void onclickdkPlayer()
    {
        dk++;
        Debug.Log($"dk: {dk}");
        Debug.Log($"dk % 3: {dk % 3}");

        if (dk % 3 == 0)
        {
            Debug.Log("Condition 1 met");
            img_nut.SetActive(true);
            img_volang.SetActive(false);
            img_cham.SetActive(false);

            nutdk.SetActive(true);
            volangdk.SetActive(false);
            chamtaydk.SetActive(false);

        }
        else if (dk % 3 == 1)
        {
            Debug.Log("Condition 2 met");
            img_nut.SetActive(false);
            img_volang.SetActive(true);
            img_cham.SetActive(false);

            nutdk.SetActive(false);
            volangdk.SetActive(true);
            chamtaydk.SetActive(false);
        }
        else
        {
            Debug.Log("Condition 3 met");
            img_nut.SetActive(false);
            img_volang.SetActive(false);
            img_cham.SetActive(true);

            nutdk.SetActive(false);
            volangdk.SetActive(false);
            chamtaydk.SetActive(true);
        }
    }


    // Hàm reset 
    public void onclickReset()
    {
        reset.SetActive(true); // Bật canvas reset
    }

    // Hàm bật tắt rung
    public void onclickrung()
    {
        if (rung)
        {
            rung = false;
            ing_rung_false.SetActive(true); // Bật ảnh ing_rung_false
            ing_rung_true.SetActive(false); // Tắt ảnh ing_rung_true
        }
        else
        {
            rung = true;
            ing_rung_false.SetActive(false); // Tắt ảnh ing_rung_false
            ing_rung_true.SetActive(true); // Bật ảnh ing_rung_true
        }
    }

    public void dieukhoan()
    {
        // Đường dẫn gì đó
    }
}
