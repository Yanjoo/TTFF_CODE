/************************
 * 프로그램명 : Message.cs
 * 작성자 : 정채은 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 29일
 * 프로그램 설명 : 튜토리얼에서 튜토리얼 메시지를 UI로 보여줌
 ************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Message : MonoBehaviour
{
    public Text textMessage;
    private string[] messages;

    // Start is called before the first frame update
    void Start()
    {
        messages = new string[3];
        messages[0] = "왼팔을 들면 왼쪽으로 회전합니다.\n오른팔을 들면 오른쪽으로 회전합니다.";
        messages[1] = "차와 충돌하면 화면이 붉게 변합니다.";
        messages[2] = "경찰과 충돌하면 4초간 움직일 수 없습니다.";
    }

    public void SetNextMessage(int next)
    {
        textMessage.text = messages[next];
    }
}
