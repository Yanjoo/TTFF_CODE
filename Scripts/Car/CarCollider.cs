/************************
 * 프로그램명 : Car.cs
 * 작성자 : 이한주 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 25일
 * 프로그램 설명 : 자동차 객체의 상태 값 관리
 ************************/
  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float MoveSpeed = 1f;
    public float SafeDistance = 5f;

    // 자동차 상태 MOVE STOP STAY
    public enum CarState { MOVE, STOP, STAY };
    public CarState state;

    private Rigidbody rigidbody;

    void Start()
    {
        // 자동차 초기 상태
        state = CarState.MOVE;

        rigidbody = GetComponent<Rigidbody>();
        // 자동차의 회전축 고정, Y 위치 고정
        rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX
            | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        
    }
}

