/************************
 * 프로그램명 : CarMove.cs
 * 작성자 : 정채은, 홍영선 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 25일
 * 프로그램 설명 : 자동차의 상태 값에 따라서 자동차 이동 구현
 ************************/
  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    private Car.CarState state;
    private Car target;
    private float targetSpeed;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<Car>();
    }

    // Update is called once per frame
    void Update()
    {
        state = target.state;
        targetSpeed = target.MoveSpeed;

        if (state == Car.CarState.MOVE)
            transform.Translate(0f, 0f, targetSpeed * Time.deltaTime); // 차 이동
    }
}
