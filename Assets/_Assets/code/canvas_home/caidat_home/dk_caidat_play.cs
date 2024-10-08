using System;
using UnityEngine;

public class dk_caidat_play : MonoBehaviour
{
    public DATA_CAIDAT datalist_caidat;
    public GameObject home;
    public GameObject dk_play;
    public GameObject play;
   

    private void Start()
    {
        datalist_caidat.Loadcaidat();
    }
    void Update()
    {
        datalist_caidat.Loadcaidat();
      
        if (datalist_caidat.Data_caidat_play.dk_cd==0 && dk_play.activeSelf==true&& home.activeSelf == false && play.activeSelf == true)
        {
            ToggleAllvo_lang();
        }
        else if (datalist_caidat.Data_caidat_play.dk_cd == 2 && dk_play.activeSelf == true && home.activeSelf == false&& play.activeSelf == true)
        {
            ToggleAllbutton_left_right();
        }
        else if (datalist_caidat.Data_caidat_play.dk_cd == 1 && dk_play.activeSelf == true && home.activeSelf == false && play.activeSelf == true)
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
        }

        foreach (button_left_right script in allScriptss)
        {
            script.enabled = false ;
        }

        foreach (ChamMover script in allScriptsss)
        {
            script.enabled = false;
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
        }

        foreach (button_left_right script in allScriptss)
        {
            script.enabled = true;
        }

        foreach (ChamMover script in allScriptsss)
        {
            script.enabled = false;
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
        }

        foreach (button_left_right script in allScriptss)
        {
            script.enabled = false;
        }

        foreach (ChamMover script in allScriptsss)
        {
            script.enabled = true;
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
        }

        foreach (button_left_right script in allScriptss)
        {
            script.enabled = false;
        }

        foreach (ChamMover script in allScriptsss)
        {
            script.enabled = false;
        }
    }
}
