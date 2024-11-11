using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestriyByContact : MonoBehaviour
{
    public GameObject explosion; //陨石爆炸效果
    public GameObject playerExplosion; //玩家爆炸效果

    public int scoreValue; //初始分值
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindWithTag("GameController");
        if (go!= null)
            gameController = go.GetComponent<GameController>();
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
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver(); //寻获到GameController脚本的GameOver函数
        }
        
        Destroy(other.gameObject);
        Destroy(gameObject);
  
        gameController.AddScore(scoreValue); //寻获到GameController脚本的AddScore函数中的scoreValue值
    }
}
