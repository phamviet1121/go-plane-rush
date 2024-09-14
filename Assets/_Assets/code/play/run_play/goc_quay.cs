using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goc_quay : MonoBehaviour
{
    public GameObject player;
    public float rotationSpeed = 1f; // Tốc độ quay

    void Update()
    {
        
        Quaternion playerRotation = player.transform.rotation;
        Vector3 eulerAngles = playerRotation.eulerAngles;

        // Lấy giá trị từ Input
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Tính toán góc mới quanh trục Z
        float newZAngle = eulerAngles.z + horizontalInput * rotationSpeed;

        // Cập nhật góc quay của đối tượng này
        transform.rotation = Quaternion.Euler(0f, 180f, newZAngle);
    }
}
