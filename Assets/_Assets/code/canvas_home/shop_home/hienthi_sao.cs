using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hienthi_sao : MonoBehaviour
{
    public list_sao listsaoo;
    public Text sao;
    private void Update()
    {
        sao.text= listsaoo.save_int_sao.ToString();
    }

}
