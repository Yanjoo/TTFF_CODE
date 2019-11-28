/************************
 * 프로그램명 : Score.cs
 * 작성자 : 황승혜 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 25일
 * 프로그램 설명 : 엔딩화면에서 기록을 설정함 
 ************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private ScoreManager scoreManager;
    private TextMesh text;
    private string name;
    private float timeCnt;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMesh>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        name = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (name == "Score1") timeCnt = scoreManager.GetScore(0);
        else if (name == "Score2") timeCnt = scoreManager.GetScore(1);
        else if (name == "Score3") timeCnt = scoreManager.GetScore(2);

        string timeStr = timeCnt.ToString("00.00");
        timeStr = timeStr.Replace(".", ":");
        text.text = timeStr;
    }
}
