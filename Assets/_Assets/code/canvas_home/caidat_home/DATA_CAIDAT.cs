using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DATA_CAIDAT : MonoBehaviour
{

    public data_caidat_play Data_caidat_play = new data_caidat_play();

    // Start is called before the first frame update
    void Start()
    {
        // Tải dữ liệu khi bắt đầu game (nếu có)
        Loadcaidat();
    }

    // Update is called once per frame
    void Update()
    {
        // Bạn có thể thêm logic lưu hoặc tải dữ liệu khi cần
    }

    [ContextMenu("Savecaidat")]
    public void Savecaidat()
    {
        // Chuyển đổi đối tượng playerData thành JSON
        string jsonData = JsonUtility.ToJson(Data_caidat_play);

        // Lưu chuỗi JSON vào PlayerPrefs
        PlayerPrefs.SetString(nameof(data_caidat_play), jsonData);

        // Lưu thay đổi vào PlayerPrefs
        PlayerPrefs.Save();


    }
    private void OnApplicationQuit()
    {
        Savecaidat();
    }
    [ContextMenu("Loadcaidat")]
    public void Loadcaidat()
    {
        // Lấy chuỗi JSON từ PlayerPrefs, nếu không có thì trả về chuỗi rỗng "{}"
        string loadedJson = PlayerPrefs.GetString(nameof(data_caidat_play), "{}");

        // Chuyển đổi chuỗi JSON thành đối tượng playerData
        Data_caidat_play = JsonUtility.FromJson<data_caidat_play>(loadedJson);


    }
}
[Serializable]
public class data_caidat_play
{
    public int amthanh_cd;
    public int dk_cd;
    public int rung_cd;



}
