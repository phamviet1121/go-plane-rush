using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public Summary Summary;
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
                      
                    }
                }
            }
        }
    }
}

