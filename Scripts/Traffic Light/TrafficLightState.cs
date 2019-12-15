/************************
 * 프로그램명 : TrafficLightState.cs
 * 작성자 : 정채은, 홍영선 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 17일
 * 프로그램 설명 : 신호등의 지속시간이 지정한 시간(빨간불, 초록불)을 넘으면 신호등의 불을 바꾼다.
 ************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrafficLightState : MonoBehaviour
{
    private TrafficLight target;
    private GameObject redCircle;
    private GameObject redLight;
    private GameObject greenCircle;
    private GameObject greenLight;

    [SerializeField]
    private GameObject stopTrigger;

    [SerializeField]
    private GameObject goTrigger;

    enum TrafficFunctions { RED, GREEN, NUM_STATES };

    private TrafficFunctions Point = TrafficFunctions.RED;

    private TrafficFunctions StopPoint
    {
        get { return Point; }
        set { Point = value; }
    }

    private Dictionary<TrafficFunctions, Action> fsm = new Dictionary<TrafficFunctions, Action>();

    void Start()
    {
        target = transform.GetComponent<TrafficLight>();

        greenCircle = transform.GetChild(0).gameObject;
        greenLight = greenCircle.transform.GetChild(0).gameObject;
        greenLight.SetActive(false);

        redCircle = transform.GetChild(1).gameObject;
        redLight = redCircle.transform.GetChild(0).gameObject;

        redCircle.GetComponent<Renderer>().material.color = Color.red;
        greenCircle.GetComponent<Renderer>().material.color = Color.gray;
        fsm.Add(TrafficFunctions.RED, new Action(RedLight));
        fsm.Add(TrafficFunctions.GREEN, new Action(GreenLight));
        StopPoint = TrafficFunctions.RED;
        stopTrigger.SetActive(false);
    }

    void Update()
    {
        fsm[StopPoint].Invoke();

        if (StopPoint == TrafficFunctions.RED)
        {
            RedLight();
        }
        else if (StopPoint == TrafficFunctions.GREEN)
        {
            GreenLight();
        }

    }

    void RedLight()
    {
        // 현재 신호(빨간불)이 지정된 신호(빨간불) 시간을 넘으면
        if (target.GetTrafficLight() > target.GetRedLight())
        {   
            // 초록불을 활성화 한다.
            greenCircle.GetComponent<Renderer>().material.color = Color.green;
            redCircle.GetComponent<Renderer>().material.color = Color.gray;
            greenLight.SetActive(true);
            redLight.SetActive(false);
            LastTransition(TrafficFunctions.GREEN);

            // 신호등 시간 초기화
            target.SetTrafficLight(0.0f);
            // 자동차를 멈추게 한다
            stopTrigger.SetActive(true);
            goTrigger.SetActive(false);
        }
    }

    void GreenLight()
    {
        // 현재 신호(초록불)이 지정된 신호(초록불) 시간을 넘으면
        if (target.GetTrafficLight() > target.GetGreenLight())
        {
            // 빨간불을 활성화한다.
            greenCircle.GetComponent<Renderer>().material.color = Color.gray;
            redCircle.GetComponent<Renderer>().material.color = Color.red;
            greenLight.SetActive(false);
            redLight.SetActive(true);
            LastTransition(TrafficFunctions.RED);

            // 신호등 시간 초기화
            target.SetTrafficLight(0.0f);
            // 자동차를 움직이게 한다.
            stopTrigger.SetActive(false);
            goTrigger.SetActive(true);
        }
    }

    void LastTransition(TrafficFunctions newState)
    {
        Point = newState;
    }
}
