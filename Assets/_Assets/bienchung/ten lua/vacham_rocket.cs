using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vacham_rocket : MonoBehaviour
{
    public Summary Summary;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tenlua"))
        {
            Summary.point_rockets += 1;
            Debug.Log("Có va chạm giữa hai tên lửa");
        }
    }
}
