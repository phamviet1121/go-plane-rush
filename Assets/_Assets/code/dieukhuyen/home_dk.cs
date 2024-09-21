using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class home_dk : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject player5;
    public GameObject player6;
    public GameObject player7;
    public GameObject player8;
    public GameObject player9;
    public int id = 0;
    public GameObject btn_chonplayer_right;
    public GameObject btn_chonplayer_left;
    public GameObject vitri_player;
    private GameObject currentObject;
    // Start is called before the first frame update
    void Start()
    {
        viewplayer(id);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void onclick_chonplayer_right()
    {
        id++;
        if (id >= 8)
        {
            btn_chonplayer_right.SetActive(false);
            id = 8;

        }
        else
        {
            btn_chonplayer_right.SetActive(true);
           
        }
        if(id >0) 
        {
            btn_chonplayer_left.SetActive(true);
        }
        viewplayer(id);
    }
    public void onclick_chonplayer_left()
    {
        id--;
        if (id <= 0)
        {
            btn_chonplayer_left.SetActive(false);
            id = 0;
        }
        else
        {
            btn_chonplayer_left.SetActive(true);
        }
        if(id < 8)
        {
            btn_chonplayer_right.SetActive(true);
        }
        viewplayer(id);
    }
    public void viewplayer(int id)
    {
        if (currentObject != null)
        {
            Destroy(currentObject);
        }
        if (id == 0)
        {
            if (currentObject != null)
            {
                Destroy(currentObject);
            }
            Vector3 playerPosition = vitri_player.transform.position;
            currentObject = Instantiate(player1, playerPosition, Quaternion.Euler(0, 0, 90));
        }
        else if (id == 1)
        {
            if (currentObject != null)
            {
                Destroy(currentObject);
            }
            Vector3 playerPosition = vitri_player.transform.position;
            currentObject = Instantiate(player2, playerPosition, Quaternion.Euler(0, 0, 90));
        }
        else if (id == 2)
        {
            if (currentObject != null)
            {
                Destroy(currentObject);
            }
            Vector3 playerPosition = vitri_player.transform.position;
            currentObject = Instantiate(player3, playerPosition, Quaternion.Euler(0, 0, 90));
        }
        else if (id == 3)
        {
            if (currentObject != null)
            {
                Destroy(currentObject);
            }
            Vector3 playerPosition = vitri_player.transform.position;
            currentObject = Instantiate(player4, playerPosition, Quaternion.Euler(0, 0, 90));
        }
        else if (id == 4)
        {
            if (currentObject != null)
            {
                Destroy(currentObject);
            }
            Vector3 playerPosition = vitri_player.transform.position;
            currentObject = Instantiate(player5, playerPosition, Quaternion.Euler(0, 0, 90));
        }
        else if (id == 5)
        {
            if (currentObject != null)
            {
                Destroy(currentObject);
            }
            Vector3 playerPosition = vitri_player.transform.position;
            currentObject = Instantiate(player6, playerPosition, Quaternion.Euler(0, 0, 90));
        }

        else if (id == 6)
        {
            if (currentObject != null)
            {
                Destroy(currentObject);
            }
            Vector3 playerPosition = vitri_player.transform.position;
            currentObject = Instantiate(player7, playerPosition, Quaternion.Euler(0, 0, 90));
        }
        else if (id == 7)
        {
            if (currentObject != null)
            {
                Destroy(currentObject);
            }
            Vector3 playerPosition = vitri_player.transform.position;
            currentObject = Instantiate(player8, playerPosition, Quaternion.Euler(0, 0, 90));
        }
        else
        {
            if (currentObject != null)
            {
                Destroy(currentObject);
            }
            Vector3 playerPosition = vitri_player.transform.position;
            currentObject = Instantiate(player9, playerPosition, Quaternion.Euler(0, 0, 90));
        }
       
    }
}
