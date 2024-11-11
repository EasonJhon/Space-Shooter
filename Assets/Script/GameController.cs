using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //使用UnityEngine.UI的库文件
public class GameController : MonoBehaviour
{
    public GameObject[] hazard; //被实例化的陨石物体
    public Vector3 spawnValues; //用于在轴上实例化对象的值
    public int hazardCount; //生成陨石的数量
    public float spawnWait; //每次生成陨石的对象后延迟的时间
    public float startWait = 1.0f; //批次陨石生成等待时间
    public float waveWait = 2.0f; //多批次生成陨石时间间隔
    
    public Text scoreText; //设置变量 scoreText
    private int score; //用整数变量 score保存分值
    
    public Text gameOverText; //设置变量 gameOverText
    private bool gameOver; //用bool类型变量 判断是否游戏结束
    
    public Text restartText; //设置变量 restartText
    private bool restart; //用bool类型变量 判断是否重新开始
    
    private Vector3 spawnPosition = Vector3.zero;
    private Quaternion spawnRotation;

    IEnumerator SpawnWaves()
    { //返回值类型为IEnumerator然后用yield return语句返回spawnWait
        yield return  new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++) //大于零的情况下 生成陨石的数量
            {
                var num = Random.Range(0, 3);
                spawnPosition.x = Random.Range(-spawnValues.x, spawnValues.x);
                //x轴随机生成物体位置
                spawnPosition.z = spawnValues.z; //z轴不需要赋值
                spawnRotation = Quaternion.identity; //随机旋转 无旋转
                Instantiate(hazard[num], spawnPosition, spawnRotation); //实例化陨石物体，位置，旋转
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            
            if (gameOver)//如果判断游戏结束状态
            {
                restartText.text = "按R键开始";
                restart = true;
                break;
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());

        score = 0;
        UpdateScore();//初始化

        gameOverText.text = ""; //游戏一开始为空
        gameOver = false; //游戏结束为假
        
        restartText.text = ""; //游戏一开始为空
        restart = false; //游戏重新开始为假
    }

    // Update is called once per frame
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel); //重新读取关卡
            }
        }
    }

    public void AddScore(int newScoreValue)//需要外部调用 不需要返回值
    {
        score += newScoreValue; //score的值为自身加newScoreValue
        UpdateScore();
    }
    
    void UpdateScore()
    {
        scoreText.text = "得分: " + score;//更新一下显示的分数
    }

    public void GameOver() //申明游戏结束函数
    {
        gameOverText.text = "Game Over!"; //显示Game Over
        gameOver = true; //游戏结束为真
    }
}
