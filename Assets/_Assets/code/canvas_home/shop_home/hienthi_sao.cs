using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class hienthi_sao : MonoBehaviour
{
    public list_sao listsaoo;
    public TextMeshProUGUI sao;
    private void Update()
    {
        sao.text= listsaoo.save_int_sao.ToString();
    }

}
