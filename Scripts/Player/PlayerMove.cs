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
    private Player player;
    private int state;
    private float speed;
    private bool move;
    private int rotation;
    private Vector3 rotationAngle;

    private float timer;
    private float delay = 4;

    private Police police;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        rotationAngle = player.transform.eulerAngles;
        police = GameObject.Find("Police").GetComponent<Police>();
    }

    // Update is called once per frame
    void Update()
    {
        Initialize();

        transform.Rotate(0, Input.GetAxisRaw("Horizontal") * Time.deltaTime * 90, 0);
        transform.Translate(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime * speed);

        if (state == PlayerState.RUN)
        {
            if (move) player.transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);

            if (rotation == PlayerState.Rotation.LEFT)
            {
                rotationAngle += new Vector3(0, -90, 0) * Time.deltaTime;
                player.transform.rotation = Quaternion.Euler(rotationAngle);
            }
            else if (rotation == PlayerState.Rotation.RIGHT)
            {
                rotationAngle += new Vector3(0, 90, 0) * Time.deltaTime;
                player.transform.rotation = Quaternion.Euler(rotationAngle);
            }
        }
        else if (state == PlayerState.HIT)
        {
            timer = 0;
            player.SetState(PlayerState.DIZZY);
        }
        else if (state == PlayerState.DIZZY)
        {
            if (timer > delay) player.SetState(PlayerState.NORMAL);
        }
        else
        {
            speed = 0;
        }
    }

    private void Initialize()
    {
        state = player.GetState();
        speed = player.Speed;
        move = player.IsMove();
        rotation = player.GetRotation();
        timer += Time.deltaTime;
    }
}
