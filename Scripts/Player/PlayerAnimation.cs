/************************
 * 프로그램명 : Hand.cs
 * 작성자 : 이한주 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 24일 
 * 프로그램 설명 : 플레이어의 상태 값을 받아 애니메이션 실행
 ************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Player player;
    private Animation anim;

    private int state;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animation>();
        state = PlayerState.NORMAL;
    }

    // Update is called once per frame
    void Update()
    {
        state = player.GetState();

        Debug.Log("Anim " + state);

        if (state == PlayerState.RUN)
        {
            anim.Play("Run");
        }
        else if (state == PlayerState.DIZZY)
        {
            anim.Play("Dizzy");
        }
        else
        {
            anim.Stop();
        }
        anim.wrapMode = WrapMode.Once;
    }
}
