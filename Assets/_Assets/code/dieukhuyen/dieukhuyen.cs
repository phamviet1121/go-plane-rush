using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieukhuyen : MonoBehaviour
{
    public GameObject macdinh;
    public GameObject home;
    public GameObject caidat;
    public GameObject thanhtich;
    public GameObject shop;

    // Start is called before the first frame update
    void Start()
    {
        // Bật macdinh và home, tắt các canvas còn lại
        macdinh.SetActive(true);
        home.SetActive(true);
        caidat.SetActive(false);
        thanhtich.SetActive(false);
        shop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Nếu muốn có logic để bật/tắt theo sự kiện khác, bạn có thể thêm vào đây
    }
}
