using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dk_xephang : MonoBehaviour
{
    public GameObject xephang;
   public void onclickxephang()
    {
        xephang.SetActive(true);
    }

    public void offclickxephang()
    {
        xephang.SetActive(false);
    }
}
