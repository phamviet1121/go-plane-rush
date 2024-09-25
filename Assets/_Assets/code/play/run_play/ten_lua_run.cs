
using UnityEngine;


public class ten_lua_run : MonoBehaviour
{
    public GameObject tenlua;
    public float rotationSpeed = 1f;
    private GameObject newtenlua;
    public float tenlualnewtime = 5f;
    float m_tenluanewtime;
    public GameObject play;
    public GameObject vuno;
    private GameObject newvuno;
    public float newthoigianbatdau = 2f;

    float thoigianbatdau;
    private void Start()
    {
        if (newtenlua != null)
        {
            Destroy(newtenlua);
        }
        thoigianbatdau = newthoigianbatdau;


    }
    void Update()
    {
        float a = Random.Range(Random.Range(10, 20), Random.Range(-10, -20));
        float b = Random.Range(Random.Range(15, 20), Random.Range(-15, -20));
        Vector2 vitri = new Vector2(transform.position.x + a, transform.position.y + b);
        if (play.activeSelf == true)
        {
            thoigianbatdau -= Time.deltaTime;
        }
        else 
        { 
            thoigianbatdau = newthoigianbatdau;
        }

        if (play.activeSelf == true && newtenlua == null&& thoigianbatdau<=0)
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
        }



    }
    public void runtenlua(GameObject newruntenlua)
    {


        Vector3 directionToPlayer = transform.position - newruntenlua.transform.position;


        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;


        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));


        newruntenlua.transform.rotation = Quaternion.Slerp(newruntenlua.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        Debug.Log($"toa do ten lua{tenlua.transform.rotation}");

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("tenlua"))
        {
           

            Vector2 vitrino = new Vector2(transform.position.x, transform.position.y);
            //Destroy(gameObject);
            newvuno = Instantiate(vuno, vitrino, Quaternion.identity);
            Destroy(newvuno, 1.8f);
        }
    }

}
