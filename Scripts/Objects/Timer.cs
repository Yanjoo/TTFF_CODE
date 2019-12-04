/****************************
 * 프로그램명 : Timer.cs
 * 작성자 : 황승혜 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019.11.26
 * 기능 : 시간이 경과하는 것을 UI로 보여준다. 
 ************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timeCnt;
    public Text text_timer;

    // Update is called once per frame
    void Update()
    {
        timeCnt += Time.deltaTime;
        string timeStr = timeCnt.ToString("00.00");
        timeStr = timeStr.Replace(".", ":");
        text_timer.text = "Score : " + timeStr;
    }

    public float GetTime()
    {
        return timeCnt;
    }
}
