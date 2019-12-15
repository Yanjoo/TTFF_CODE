/************************
 * 프로그램명 : CarSpawnMange.cs
 * 작성자 : 이한주 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 20일
 * 프로그램 설명 : 자동차 객체를 지정된 위치와 각도로 일정 시간마다 반복 생성 (클론 생성)
 ************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using System;

public class CarSpawnManage : MonoBehaviour
{
    private GameObject Car1;
    private GameObject Car2;
    private GameObject Car3;

    public float posX, posY, posZ;
    public float angX, angY, angZ;

    public float SpawnStartTime = 1;
    public float SpawnRepeatTime= 2;

    private System.Random r;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RespawnCar", SpawnStartTime, SpawnRepeatTime);
        r = new System.Random();

        Car1 = transform.GetChild(0).gameObject;
        Car2 = transform.GetChild(1).gameObject;
        Car3 = transform.GetChild(2).gameObject;
    }

    void RespawnCar()
    {
        int i = r.Next(1, 4);
        if (i == 1) Instantiate(Car1, new Vector3(posX, posY, posZ), Quaternion.Euler(angX, angY, angZ));
        else if (i == 2) Instantiate(Car2, new Vector3(posX, posY, posZ), Quaternion.Euler(angX, angY, angZ));
        else Instantiate(Car3, new Vector3(posX, posY, posZ), Quaternion.Euler(angX, angY, angZ));
    }

}
