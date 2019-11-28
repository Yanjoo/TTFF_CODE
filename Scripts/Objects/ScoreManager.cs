/************************
 * 프로그램명 : ScoreManger.cs
 * 작성자 : 황승혜 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 22일
 * 프로그램 설명 : Player의 목적지 도착 시간을 저장, 제공
 ************************/

using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float[] scores;
    private int index = 0;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        scores = new float[4];
    }

    public void SetScore(float score)
    {
        scores[index++] = score;
    }

    public float GetScore(int i) { return scores[i]; }
}
