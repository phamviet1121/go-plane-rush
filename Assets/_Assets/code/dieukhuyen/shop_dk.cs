using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop_dk : MonoBehaviour
{
    public GameObject home; // Canvas home
    public GameObject shop; // Canvas shop
    public float sao; // Điểm sao

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Bật Canvas shop và tắt Canvas home
    public void onclickshop()
    {
        shop.SetActive(true);  // Bật Canvas shop
        home.SetActive(false); // Tắt Canvas home
    }

    // Tắt Canvas shop và bật Canvas home
    public void offclickshop()
    {
        shop.SetActive(false); // Tắt Canvas shop
        home.SetActive(true);  // Bật Canvas home
    }

    // Hàm tăng sao từ quảng cáo
    public void onclick_quangcao()
    {
        // Đường dẫn quảng cáo
        sao += 30;
    }

    // Hàm nạp tiền 13k
    public void onclick_nap13k()
    {
        // Đường dẫn nạp 13k
        sao += 500;
    }

    // Hàm nạp tiền 23k
    public void onclick_nap23k()
    {
        // Đường dẫn nạp 23k
        sao += 1000;
    }

    // Hàm nạp tiền 108k
    public void onclick_nap108k()
    {
        // Đường dẫn nạp 108k
        sao += 5000;
    }
}
