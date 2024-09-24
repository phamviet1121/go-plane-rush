
using UnityEngine;


public class ten_lua_run : MonoBehaviour
{
    public GameObject tenlua;
    public float rotationSpeed = 1f;
    private GameObject newtenlua;
    float tenlualnewtime = 5f;
    float m_tenluanewtime;
    public GameObject play;
    private void Start()
    {
        if (newtenlua != null)
        {
            Destroy(newtenlua);
        }


    }
    void Update()
    {
        float a = Random.Range(Random.Range(10, 20), Random.Range(-10, -20));
        float b = Random.Range(Random.Range(15, 20), Random.Range(-15, -20));
        Vector2 vitri = new Vector2(transform.position.x + a, transform.position.y + b);
        if (play.activeSelf == true && newtenlua == null)
        {
            m_tenluanewtime -= Time.deltaTime;



            if (newtenlua == null && m_tenluanewtime <= 0)
            {

                newtenlua = Instantiate(tenlua, vitri, Quaternion.identity);

                m_tenluanewtime = tenlualnewtime;
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
            Destroy(newtenlua);
        }
    }
}
