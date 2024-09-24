using System;
using UnityEngine;

public class dk_caidat_play : MonoBehaviour
{
    public DATA_CAIDAT datalist_caidat;
    public GameObject home;
   
    private void Start()
    {
        datalist_caidat.Loadcaidat();
    }
    void Update()
    {
        datalist_caidat.Loadcaidat();
        // Bật/tắt tất cả các MyScript khi nhấn phím "T"
        if (datalist_caidat.Data_caidat_play.dk_cd==0 && home.activeSelf==false)
        {
            ToggleAllvo_lang();
        }
        else if (datalist_caidat.Data_caidat_play.dk_cd == 2 && home.activeSelf == false)
        {
            ToggleAllbutton_left_right();
        }
        else if (datalist_caidat.Data_caidat_play.dk_cd == 1 && home.activeSelf == false)
        {
            ToggleAllChamMover();
        }
        else
        {
            ToggleAllOFF();
        }
    }

    void ToggleAllvo_lang()
    {
        // Tìm tất cả các instance của MyScript trong scene
        vo_lang[] allScripts = FindObjectsOfType<vo_lang>();
        button_left_right[] allScriptss = FindObjectsOfType<button_left_right>();

        ChamMover[] allScriptsss= FindObjectsOfType<ChamMover>();
        // Kiểm tra xem script có đang bật hay không, sau đó bật/tắt tất cả
        foreach (vo_lang script in allScripts)
        {
            script.enabled = true;
            Debug.Log(script.enabled ? "Bật MyScript trên " + script.gameObject.name : "Tắt MyScript trên " + script.gameObject.name);
        }

        foreach (button_left_right script in allScriptss)
        {
            script.enabled = false ;
            Debug.Log(script.enabled ? "Bật MyScript trên " + script.gameObject.name : "Tắt MyScript trên " + script.gameObject.name);
        }

        foreach (ChamMover script in allScriptsss)
        {
            script.enabled = false;
            Debug.Log(script.enabled ? "Bật MyScript trên " + script.gameObject.name : "Tắt MyScript trên " + script.gameObject.name);
        }
    }
    void ToggleAllbutton_left_right()
    {
        // Tìm tất cả các instance của MyScript trong scene
        vo_lang[] allScripts = FindObjectsOfType<vo_lang>();
        button_left_right[] allScriptss = FindObjectsOfType<button_left_right>();

        ChamMover[] allScriptsss = FindObjectsOfType<ChamMover>();
        // Kiểm tra xem script có đang bật hay không, sau đó bật/tắt tất cả
        foreach (vo_lang script in allScripts)
        {
            script.enabled = false;
            Debug.Log(script.enabled ? "Bật MyScript trên " + script.gameObject.name : "Tắt MyScript trên " + script.gameObject.name);
        }

        foreach (button_left_right script in allScriptss)
        {
            script.enabled = true;
            Debug.Log(script.enabled ? "Bật MyScript trên " + script.gameObject.name : "Tắt MyScript trên " + script.gameObject.name);
        }

        foreach (ChamMover script in allScriptsss)
        {
            script.enabled = false;
            Debug.Log(script.enabled ? "Bật MyScript trên " + script.gameObject.name : "Tắt MyScript trên " + script.gameObject.name);
        }
    }
    void ToggleAllChamMover()
    {
        // Tìm tất cả các instance của MyScript trong scene
        vo_lang[] allScripts = FindObjectsOfType<vo_lang>();
        button_left_right[] allScriptss = FindObjectsOfType<button_left_right>();

        ChamMover[] allScriptsss = FindObjectsOfType<ChamMover>();
        // Kiểm tra xem script có đang bật hay không, sau đó bật/tắt tất cả
        foreach (vo_lang script in allScripts)
        {
            script.enabled = false;
            Debug.Log(script.enabled ? "Bật MyScript trên " + script.gameObject.name : "Tắt MyScript trên " + script.gameObject.name);
        }

        foreach (button_left_right script in allScriptss)
        {
            script.enabled = false;
            Debug.Log(script.enabled ? "Bật MyScript trên " + script.gameObject.name : "Tắt MyScript trên " + script.gameObject.name);
        }

        foreach (ChamMover script in allScriptsss)
        {
            script.enabled = true;
            Debug.Log(script.enabled ? "Bật MyScript trên " + script.gameObject.name : "Tắt MyScript trên " + script.gameObject.name);
        }
    }
    void ToggleAllOFF()
    {
        // Tìm tất cả các instance của MyScript trong scene
        vo_lang[] allScripts = FindObjectsOfType<vo_lang>();
        button_left_right[] allScriptss = FindObjectsOfType<button_left_right>();

        ChamMover[] allScriptsss = FindObjectsOfType<ChamMover>();
        // Kiểm tra xem script có đang bật hay không, sau đó bật/tắt tất cả
        foreach (vo_lang script in allScripts)
        {
            script.enabled = false;
            Debug.Log(script.enabled ? "Bật MyScript trên " + script.gameObject.name : "Tắt MyScript trên " + script.gameObject.name);
        }

        foreach (button_left_right script in allScriptss)
        {
            script.enabled = false;
            Debug.Log(script.enabled ? "Bật MyScript trên " + script.gameObject.name : "Tắt MyScript trên " + script.gameObject.name);
        }

        foreach (ChamMover script in allScriptsss)
        {
            script.enabled = false;
            Debug.Log(script.enabled ? "Bật MyScript trên " + script.gameObject.name : "Tắt MyScript trên " + script.gameObject.name);
        }
    }
}
