/************************
 * 프로그램명 : TrafficLight.cs
 * 작성자 : 정채은, 홍영선 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 17일
 * 프로그램 설명 : 빨간불과 초록불의 점등 시간을 설정한다. 
 ************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TrafficLight : MonoBehaviour
{
    [SerializeField] private float RedLight = 0.7f;
    [SerializeField] private float GreenLight = 0.7f;

    private float TrafficLightTimer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        ResetTimeSinceLastTransition();

        gameObject.GetComponent<Renderer>().material.color = Color.gray;
    }

    // Update is called once per frame
    void Update()
    {
        TrafficLightTimer += Time.deltaTime;
    }

    public float GetRedLight() { return RedLight; }

    public float GetGreenLight() { return GreenLight; }

    public float GetTrafficLight() { return TrafficLightTimer; }

    public void SetTrafficLight(float inputLight) { TrafficLightTimer = inputLight;}

    void ResetTimeSinceLastTransition()
    {
        TrafficLightTimer = 0.0f;
    }
}
