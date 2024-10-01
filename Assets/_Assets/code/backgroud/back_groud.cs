using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back_groud : MonoBehaviour
{
 
    Transform cam;
    Vector3 camStart;

   
    float distance;
    float distance_y;

    Material[] mat;

  
    float[] backspeed;

   
    GameObject[] backgroud;

 
    float farthestBack;

   
    [Range(0.01f, 0.05f)] 
    public float parallaxspeed;

    void Start()
    {
       
        cam = Camera.main.transform;

   
        camStart = cam.position;

      
        int backcount = transform.childCount;

       
        mat = new Material[backcount];
        backspeed = new float[backcount];

      
        backgroud = new GameObject[backcount];

       
        for (int i = 0; i < backcount; i++)
        {
            backgroud[i] = transform.GetChild(i).gameObject;
            mat[i] = backgroud[i].GetComponent<Renderer>().material;
        }
        CalculateBackgroundSpeed(backcount);
    }

   
    void CalculateBackgroundSpeed(int backcount)
    {
        
        for (int i = 0; i < backcount; i++)
        {
            if ((backgroud[i].transform.position.z - cam.position.z) > farthestBack)
            {
                farthestBack = backgroud[i].transform.position.z - cam.position.z;
            }
        }

       
        for (int i = 0; i < backcount; i++)
        {
            backspeed[i] = 1 - (backgroud[i].transform.position.z - cam.position.z) / farthestBack;
        }
    }

    private void LateUpdate()
    {
     
        distance = cam.position.x - camStart.x;
        distance_y = cam.position.y - camStart.y;
       
        transform.position = new Vector3(cam.position.x, cam.position.y, 95);
       
        for (int i = 0; i < backgroud.Length; i++)
        {
          
            float speed = backspeed[i] * parallaxspeed;

         
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance, distance_y) * speed);
            
        }
    }
}
