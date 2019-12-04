/************************
 * 프로그램명 : Player.cs
 * 작성자 : 이한주 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 24일
 * 프로그램 설명 : Hand 객체로부터 상태 값을 받아와서 Player의 상태값을 변화 시킴
 ************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float Speed = 4;
    public int state;
    private bool move;
    private int rotation;
    private bool jaywalking;

    private Hand LeftHand, RightHand;

    // Start is called before the first frame update
    void Start()
    {
        state = PlayerState.NORMAL;
        move = false;
        jaywalking = false;

        LeftHand = GameObject.Find("LeftHand").GetComponent<Hand>();
        RightHand = GameObject.Find("RightHand").GetComponent<Hand>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LifeManagement.Life <= 0) SceneManager.LoadScene("Death");
        
        if (state == PlayerState.DIZZY || state == PlayerState.HIT) return;

        if (LeftHand.grap || RightHand.grap)
        {
            move = true;
            state = PlayerState.RUN;
        }
        else
        {
            move = false;
            state = PlayerState.NORMAL;
        }

        if (LeftHand.high)
        {
            rotation = PlayerState.Rotation.LEFT;
            state = PlayerState.RUN;
        }
        else if (RightHand.high)
        {
            rotation = PlayerState.Rotation.RIGHT;
            state = PlayerState.RUN;
        }
        else
        {
            rotation = PlayerState.Rotation.KEEP;
        }
    }

    public int GetState() { return state; }
    public bool IsMove() { return move; }
    public bool IsJaywalking() { return jaywalking; }
    public int GetRotation() { return rotation; }

    public void SetState(int state) { this.state = state; }
    public void SetJaywalking(bool state) { jaywalking = state; }
}
