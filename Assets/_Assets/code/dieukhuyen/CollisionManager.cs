using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.Unicode;

public class CollisionManager : MonoBehaviour
{
    public Summary Summary;
    public DATA_CAIDAT datacaidat;
    bool rung;
    private void Update()
    {
        rung = (datacaidat.Data_caidat_play.rung_cd == 0) ? true : false;
        Debug.Log($"{rung}");
    }
    private void FixedUpdate()
    {
        // Lấy danh sách tất cả các Collider 2D hiện có trong Scene
        Collider2D[] allColliders = FindObjectsOfType<Collider2D>();

        // Duyệt qua tất cả các Collider để kiểm tra va chạm giữa "tenlua" và "tenlua"
        for (int i = 0; i < allColliders.Length; i++)
        {
            for (int j = i + 1; j < allColliders.Length; j++)
            {
                // Kiểm tra xem cả hai Collider có tag "tenlua" không
                if (allColliders[i].CompareTag("tenlua") && allColliders[j].CompareTag("tenlua"))
                {
                    // Kiểm tra nếu có va chạm giữa hai Collider
                    if (allColliders[i].IsTouching(allColliders[j]))
                    {
                      
                        Summary.point_rockets+=1;
                        Debug.Log("co va chạm ko  ko");
                    }
                  
                }
                
                if (allColliders[i].CompareTag("Player") && allColliders[j].CompareTag("icon_destruction")
                    || allColliders[i].CompareTag("Player") && allColliders[j].CompareTag("icon_star")
                    || allColliders[i].CompareTag("Player") && allColliders[j].CompareTag("Accelerate") 
                    || allColliders[i].CompareTag("Player") && allColliders[j].CompareTag("icon_Shields")
                    || allColliders[i].CompareTag("Player") && allColliders[j].CompareTag("tenlua")
                    || allColliders[i].CompareTag("tenlua") && allColliders[j].CompareTag("tenlua"))
                {
                   

                    // Kiểm tra nếu có va chạm giữa hai Collider
                    if (allColliders[i].IsTouching(allColliders[j])&& rung)
                    {
                        Handheld.Vibrate();
                        Debug.Log("co rung ko");

                    }
                }
            }
        }
    }
}

