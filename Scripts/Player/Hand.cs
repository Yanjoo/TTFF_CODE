/************************
 * 프로그램명 : Hand.cs
 * 작성자 : 이한주 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 6일
 * 프로그램 설명 : 키넥트로부터 손의 상태(움켜쥠, 손의 높이)를 입력 받아서 저장
 ************************/

using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hand : MonoBehaviour
{
    public bool high;
    public bool grap;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    { 
        grap = false;
        high = false;
    }

    void Update()
    {
        string name = SceneManager.GetActiveScene().name;
        if (name.Equals("MainMenu") || name.Equals("Ending") || name.Equals("Death"))
        {
            GetComponent<Collider>().enabled = true;
            GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Start"))
        {
            if (grap)
            {
                ChangeFirstScene();
            }
        }
        if (other.gameObject.CompareTag("Quit"))
        {
            if (grap)
            {
                Quit();
            }
        }
        if (other.gameObject.CompareTag("MainMenu"))
        {
            if (grap)
            {
                SceneManager.LoadScene("MainMenu");
                ScoreManager score = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
                for (int i = 0; i < 3; i++)
                    score.SetScore(0);
            }
        }
        if (other.gameObject.CompareTag("Retry"))
        {
            if (grap)
            {
                DeathAnimation playerDeath = GameObject.Find("badending").GetComponent<DeathAnimation>();
                SceneManager.LoadScene(playerDeath.sceneName);
                LifeManagement.Hit = 0;
            }
        }
    }

    private void Quit()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    private void ChangeFirstScene()
    {
        SceneManager.LoadScene("Tutorial");//로드할 신이름 입력후 build setting에서 add open scene 눌러 현재신과 로드할 신 추가
    }
}
