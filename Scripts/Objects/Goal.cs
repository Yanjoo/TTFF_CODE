/************************
 * 프로그램명 : Goal.cs
 * 작성자 : 안한길 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 22일
 * 프로그램 설명 : Player가 목적지에 도착하면 점수를 기록하고, 다음 씬으로 이동한다.
 ************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private Timer timer;
    private ScoreManager scoreManager;

    // Start is called before the first frame update 
    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        LifeManagement.SceneName = SceneManager.GetActiveScene().name;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            NextScene();
            scoreManager.SetScore(timer.GetTime());
        }
    }

    void NextScene()
    {
        string name = SceneManager.GetActiveScene().name;

        if (name == "Tutorial")
            LoadingSceneManager.LoadScene("Round1");
        else if (name == "Round1")
            LoadingSceneManager.LoadScene("Round2");
        else if (name == "Round2")
            LoadingSceneManager.LoadScene("Round3");
        else if (name == "Round3")
            SceneManager.LoadScene("Ending");
    }
}
