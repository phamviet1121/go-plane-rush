
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class ten_lua_run : MonoBehaviour
{
    public GameObject tenlua;
    public float rotationSpeed = 2f;
    private GameObject newtenlua;
    public float tenlualnewtime = 5f;
    float m_tenluanewtime;
    public GameObject play;
    public GameObject vuno;
    private GameObject newvuno;
    public float newthoigianbatdau = 2f;

    float thoigianbatdau;
    //thong bao
    public GameObject Notification_icon;
    public Canvas canvas;
    private GameObject NewNotification_Icon;
    public float padding = 10f;

    public GameObject game_over;
    private void Start()
    {
        if (newtenlua != null)
        {
            Destroy(newtenlua);
        }
        thoigianbatdau = newthoigianbatdau;
        if (canvas == null)
        {

            canvas = GetComponentInParent<Canvas>();
        }


        NewNotification_Icon = Instantiate(Notification_icon, canvas.transform);
        NewNotification_Icon.SetActive(false);
        padding = 10f;
    }
    void Update()
    {
       
        float a = (Random.value > 0.5f) ? Random.Range(5f, 10f) : Random.Range(-5f, -10f);
        float b = (Random.value > 0.5f) ? Random.Range(5f,10f) : Random.Range(-5f, -10f);
        Vector2 vitri = new Vector2(transform.position.x + a, transform.position.y + b);
        if (play.activeSelf == true)
        {
            thoigianbatdau -= Time.deltaTime;
        }
        else
        {
            thoigianbatdau = newthoigianbatdau;
        }

        if (play.activeSelf == true && newtenlua == null && thoigianbatdau <= 0)
        {
            m_tenluanewtime -= Time.deltaTime;



            if (newtenlua == null && m_tenluanewtime <= 0)
            {

                newtenlua = Instantiate(tenlua, vitri, Quaternion.identity);

                m_tenluanewtime = tenlualnewtime;
                if (tenlualnewtime >= 1f)
                {
                    tenlualnewtime -= 0.2f;
                }

            }
        }
        if (newtenlua != null)
        {
            runtenlua(newtenlua);
            Notification_rocket();
        }



    }
    public void runtenlua(GameObject newruntenlua)
    {


        Vector3 directionToPlayer = transform.position - newruntenlua.transform.position;


        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;


        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));


        newruntenlua.transform.rotation = Quaternion.Slerp(newruntenlua.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);


    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tenlua"))
        {


            Vector2 vitrino = new Vector2(transform.position.x, transform.position.y);
            newvuno = Instantiate(vuno, vitrino, Quaternion.identity);
            Destroy(newvuno, 1.8f);
            Invoke("ActivateGameOver", 1f);
            Destroy(gameObject, 1.5f);
           
          
          
            gameObject.SetActive(false);

        }
    }
    void ActivateGameOver()
    {
        game_over.SetActive(true);
       
        Time.timeScale = 0f;


    }
    public void Notification_rocket()
    {
        Vector3 direction = newtenlua.transform.position - transform.position;
        Vector3 midPoint = transform.position + direction;

        Vector3 screenPoint = Camera.main.WorldToScreenPoint(midPoint);

        RectTransform canvasRect = canvas.transform as RectTransform;

        float canvasWidth = canvasRect.rect.width;
        float canvasHeight = canvasRect.rect.height;

        bool isWithinCanvas = screenPoint.z > 0 &&
                              screenPoint.x > 0 && screenPoint.x < Screen.width &&
                              screenPoint.y > 0 && screenPoint.y < Screen.height;

        // Nếu 'dich' nằm ngoài canvas, hiện thông báo
        if (!isWithinCanvas)
        {
            NewNotification_Icon.SetActive(true); 
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRect,
                screenPoint,
                canvas.worldCamera,
                out Vector2 localPoint);

            // Tính toán vị trí của thông báo ở biên canvas
            localPoint.x = Mathf.Clamp(localPoint.x, -canvasWidth / 2 + padding, canvasWidth / 2 - padding);
            localPoint.y = Mathf.Clamp(localPoint.y, -canvasHeight / 2 + padding, canvasHeight / 2 - padding);

            // Đặt lại vị trí của thông báo trên biên của canvas
            RectTransform thongbaoRect = NewNotification_Icon.GetComponent<RectTransform>();
            thongbaoRect.anchoredPosition = localPoint;

        }
        else
        {
            NewNotification_Icon.SetActive(false);

        }
    }
    private void OnDestroy()
    {
        if (newtenlua != null)
        {
            Destroy(newtenlua);
        }
        if (NewNotification_Icon != null)
        {
            Destroy(NewNotification_Icon);
        }
    }

}
