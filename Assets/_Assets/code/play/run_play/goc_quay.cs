using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goc_quay : MonoBehaviour
{
  
    public float rotationSpeed = 1f; // Tốc độ quay
    public float movementSpeed = 5f;

    void Update()
    {

        //Quaternion playerRotation = player.transform.rotation;
        //Vector3 eulerAngles = playerRotation.eulerAngles;

        //// Lấy giá trị từ Input
        //float horizontalInput = Input.GetAxisRaw("Horizontal");

        //// Tính toán góc mới quanh trục Z
        //float newZAngle = eulerAngles.z + horizontalInput * rotationSpeed;

        //// Cập nhật góc quay của đối tượng này
        //transform.rotation = Quaternion.Euler(0f, 180f, newZAngle);
        DiChuyenTheoGocQuay();
    }
    private void DiChuyenTheoGocQuay()
    {
        // Lấy góc quay hiện tại
        float angle = transform.eulerAngles.z;

        // Chuyển đổi góc quay sang vector hướng di chuyển
        Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);

        // Di chuyển nhân vật về phía trước theo hướng của góc quay
        transform.position += direction * movementSpeed * Time.deltaTime;

        Debug.Log($"Di chuyển theo góc quay: {angle}, hướng: {direction}");
    }
}
