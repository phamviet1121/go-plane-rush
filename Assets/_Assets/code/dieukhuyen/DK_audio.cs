using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DK_audio : MonoBehaviour
{

    public AudioSource audioSource;
    public void start_audio()
    {
        audioSource.Play();
        //audioSource.Stop();  // Dừng âm thanh nếu đang phát
        //audioSource.Play();  // Phát lại từ đầu
        //audioSource.loop = true;  // Lặp lại âm thanh liên tục
    }    
}
