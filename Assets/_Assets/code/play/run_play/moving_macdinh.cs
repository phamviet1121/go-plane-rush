using System.Collections;
using UnityEngine;

public class moving_macdinh : MonoBehaviour
{
    public float speed = 5f;
    //public GameObject dich; 

    private Coroutine moveCoroutine;


    // Hàm Start được gọi khi bắt đầu chương trình
    //void Start()
    //{
    //    // Bắt đầu di chuyển theo đích liên tục
    //    if (dich != null)
    //    {
    //        moveCoroutine = StartCoroutine(FollowTarget());
    //    }
    //}

    private void Update()
    {
        DiChuyenTheoGocQuay();
    }
    private void DiChuyenTheoGocQuay()
    {
        float angle = transform.eulerAngles.z;


        Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);

        
        
            transform.position += direction * speed * Time.deltaTime;
        




    }


    //// Coroutine để theo dõi đích liên tục
    //IEnumerator FollowTarget()
    //{
    //    while (true) // Vòng lặp vô hạn
    //    {
    //        if (dich != null)
    //        {
    //            Vector2 targetPosition = dich.transform.position;

    //            // Di chuyển đến vị trí đích
    //            while (Vector2.Distance(transform.position, targetPosition) > 0.01f)
    //            {
    //                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    //                yield return null; // Đợi đến khung hình tiếp theo
    //            }
    //        }
    //        yield return null; // Đợi đến khung hình tiếp theo
    //    }
    //}

    // Tùy chọn: Nếu bạn muốn dừng di chuyển theo đích, bạn có thể dừng coroutine
    //public void StopFollowing()
    //{
    //    if (moveCoroutine != null)
    //    {
    //        StopCoroutine(moveCoroutine);
    //        moveCoroutine = null;
    //    }
    //}
}
