/************************
 * 프로그램명 : PlayerMove.cs
 * 작성자 : 이한주 (이한주 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 24일 
 * 프로그램 설명 : Player 객체로부터 상태 값을 받아와서 Player를 이동 (움직임, 회전, 멈춤)
 ************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // target Player 객체
    private Player target;

    // target에서 가져오는 상태값
    private int state;
    private float speed;
    private bool move;
    private int rotation;
    private Vector3 rotationAngle;

    private float timer;
    private float delay = 4;

    void Start()
    {
        target = GetComponent<Player>();
        rotationAngle = target.transform.eulerAngles;
    }

    void Update()
    {
        // 플레이어 객체로부터 상태값 갱신
        Initialize();

        // 키보드 이동
        transform.Rotate(0, Input.GetAxisRaw("Horizontal") * Time.deltaTime * 90, 0);
        transform.Translate(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime * speed);

        // 플레이어 상태 값에 따른 행동
        // 1. 플레이어 상태가 RUN
        if (state == PlayerState.RUN)
        {
            // Player의 move가 true일 때
            if (move) target.transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);

            // Player의 상태 값이 LEFT 회전일 때
            if (rotation == PlayerState.Rotation.LEFT)
            {
                rotationAngle += new Vector3(0, -90, 0) * Time.deltaTime;
                target.transform.rotation = Quaternion.Euler(rotationAngle);
            } // Player의 상태 값이 RIGHT 회전일 때
            else if (rotation == PlayerState.Rotation.RIGHT)
            {
                rotationAngle += new Vector3(0, 90, 0) * Time.deltaTime;
                target.transform.rotation = Quaternion.Euler(rotationAngle);
            }
        } // Player가 경찰에게 맞았을 때
        else if (state == PlayerState.HIT)
        {
            timer = 0;
            target.SetState(PlayerState.DIZZY);
        } // Player가 경찰에게 맞은 후
        else if (state == PlayerState.DIZZY)
        {
            if (timer > delay) target.SetState(PlayerState.NORMAL);
        } //Player가 가만히 있을 때 (NORMAL 상태일 때)
        else
        {
            speed = 0;
        }
    }

    private void Initialize()
    {
        state = target.GetState();
        speed = target.Speed;
        move = target.IsMove();
        rotation = target.GetRotation();
        timer += Time.deltaTime;
    }
}
