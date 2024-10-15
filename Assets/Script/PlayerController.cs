using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;//1
    public Boundary boundary;
    public float tilt = 4.0f;

    public GameObject Bolt;
    public Transform shotSpawn;

    public float fireRate = 0.5f; //一秒发射两次，如果是四次就是0.25f
    private float nextFire = 0.0f; //下次发射时间

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)//下次发射时间是不是比我要的时间大一点
        {
            nextFire = Time.time + fireRate; //下次发射时间为 当前时间加上发射时间间隔
            Instantiate(Bolt, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()//1
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        // GetComponent<Rigidbody>().velocity = movement * speed; //泛型写法
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = movement * speed;
            rb.position = new Vector3
                (
                    Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                    0.0f,
                    Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
                );
            rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
        }

    }
}
