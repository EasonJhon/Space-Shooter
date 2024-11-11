using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryTime : MonoBehaviour
{
    public float lifetime = 2.0f;//游戏对象（粒子）生命周期
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
