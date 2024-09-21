using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class list_sao : MonoBehaviour
{
    private void Start()
    {
        load_sao();
    }

    [SerializeField]
    public int save_int_sao;

    [ContextMenu("save_sao")]
    public void save_sao()
    {
        PlayerPrefs.SetInt(nameof(save_int_sao), save_int_sao);
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        save_sao();
    }

    [ContextMenu("load_sao")]
    public void load_sao()
    {
        save_int_sao = PlayerPrefs.GetInt(nameof(save_int_sao), 0);
       
    }

}
