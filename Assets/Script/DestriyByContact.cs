using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestriyByContact : MonoBehaviour
{
    public GameObject explosion; //陨石爆炸效果
    public GameObject playerExplosion; //玩家爆炸效果

    public int scoreValue; //设定初始分值
    private GameController gameController; //GameController变量在gameController中查找
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindWithTag("GameController");
        if (go!= null) //如果GameObject不为空
            gameController = go.GetComponent<GameController>();
        //判断GameObject拿到 GameObject这个范类
        else
            Debug.Log("找不到tag为GameController的对象");
        if (gameController == null)
        {
            Debug.Log("找不到脚本为GameController.cs");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;//如果标签是Borundary就什么都不做
        }

        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
            //寻获到GameController脚本的GameOver函数
        }
        
        Destroy(other.gameObject);
        Destroy(gameObject);
        
        gameController.AddScore(scoreValue);
        //寻获到GameController脚本的AddScore函数中的scoreValue值
    }
}
