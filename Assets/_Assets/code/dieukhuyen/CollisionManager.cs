using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.Unicode;

public class CollisionManager : MonoBehaviour
{
    public Summary Summary;
    public DATA_CAIDAT datacaidat;
    private bool rung;
    private Collider2D[] allColliders;
    void Start()
    {
        // Lấy tất cả các Collider2D trong Scene một lần ở khởi động
        allColliders = FindObjectsOfType<Collider2D>();
      //  Debug.Log($"Số lượng Collider2D tìm thấy: {allColliders.Length}");

    }

    private void Update()
    {
        //allColliders = FindObjectsOfType<Collider2D>();
        rung = (datacaidat.Data_caidat_play.rung_cd == 0) ? true : false;
        //Debug.Log($"Số lượng Collider2D tìm thấy: {allColliders.Length}");
        //for (int i = 0; i < allColliders.Length; i++)
        //{
        //    for (int j = i + 1; j < allColliders.Length; j++)
        //    {
        //        if (CheckRocketCollision(allColliders[i], allColliders[j]))
        //        {
        //            // Nếu có va chạm giữa hai tên lửa, tăng điểm
        //            Summary.point_rockets += 1;
        //            Debug.Log("Có va chạm giữa hai tên lửa");
        //        }
        //        Debug.Log($"Có va chạm giữa hai tên lửa{CheckRocketCollision(allColliders[i], allColliders[j])}");
        //    }
        //}
    }

    private void FixedUpdate()
    {

        allColliders = FindObjectsOfType<Collider2D>();
       // Debug.Log($"Số lượng Collider2D tìm thấy: {allColliders.Length}");
        for (int i = 0; i < allColliders.Length; i++)
        {
            for (int j = i + 1; j < allColliders.Length; j++)
            {
                if (CheckRocketCollision(allColliders[i], allColliders[j]))
                {
                    // Nếu có va chạm giữa hai tên lửa, tăng điểm
                    Summary.point_rockets += 1;
                   // Debug.Log("Có va chạm giữa hai tên lửa");
                }
               // Debug.Log($"Có va chạm giữa hai tên lửa{CheckRocketCollision(allColliders[i], allColliders[j])}");
            }

        }
    }
    bool CheckRocketCollision(Collider2D colliderA, Collider2D colliderB)
    {
        // Kiểm tra nếu cả hai đối tượng đều có tag "tenlua"
        if (colliderA.CompareTag("tenlua") && colliderB.CompareTag("tenlua"))
        {

            // Kiểm tra xem hai collider này có chạm nhau không
            return colliderA.IsTouching(colliderB);
        }
        return false;
    }
    //    // Duyệt qua tất cả các Collider để kiểm tra va chạm giữa "tenlua" và "tenlua"
    //for (int i = 0; i < allColliders.Length; i++)
    //{
    //    for (int j = i + 1; j < allColliders.Length; j++)
    //    {
    //        // Kiểm tra xem cả hai Collider có tag "tenlua" không
    //        if (allColliders[i].CompareTag("tenlua") && allColliders[j].CompareTag("tenlua"))
    //        {
    //            // Kiểm tra nếu có va chạm giữa hai Collider
    //            if (allColliders[i].IsTouching(allColliders[j]))
    //            {

    //                Summary.point_rockets+=1;
    //                Debug.Log("co va chạm ko  ko");
    //            }

    //        }

    //        if (allColliders[i].CompareTag("Player") && allColliders[j].CompareTag("icon_destruction")
    //            || allColliders[i].CompareTag("Player") && allColliders[j].CompareTag("icon_star")
    //            || allColliders[i].CompareTag("Player") && allColliders[j].CompareTag("Accelerate") 
    //            || allColliders[i].CompareTag("Player") && allColliders[j].CompareTag("icon_Shields")
    //            || allColliders[i].CompareTag("Player") && allColliders[j].CompareTag("tenlua")
    //            || allColliders[i].CompareTag("tenlua") && allColliders[j].CompareTag("tenlua"))
    //        {


    //            // Kiểm tra nếu có va chạm giữa hai Collider
    //            if (allColliders[i].IsTouching(allColliders[j])&& rung)
    //            {
    //                Handheld.Vibrate();
    //                Debug.Log("co rung ko");

    //            }
    //        }
    //    }
    //}


}

