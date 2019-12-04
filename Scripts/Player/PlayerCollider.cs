/************************
 * 프로그램명 : PlayerCollider.cs
 * 작성자 : 이한주 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 24일
 * 프로그램 설명 : Player 객체의 충돌과 트리거를 판별해서 Player의 상태를 바꿈
 ************************/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour
{
    private Player player;
    public Image redScreen;

    Message tutorialMessage;
    int messageIndex;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        tutorialMessage = GameObject.Find("Tutorial Message").GetComponent<Message>();
        messageIndex = 0;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Car")
        {
            StartCoroutine(ShowRedScreen());
            LifeManagement.Hit++;
        }
        if (col.gameObject.tag == "Enemy")
        {
            player.SetState(PlayerState.HIT);
            player.SetJaywalking(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "JayWalking")
        {
            player.SetJaywalking(true);
        }
        if (other.gameObject.tag == "Tutorial")
        {
            tutorialMessage.SetNextMessage(messageIndex++);
        }
    }

    private IEnumerator ShowRedScreen()
    {
        redScreen.color = new Color(1, 0, 0, UnityEngine.Random.Range(0.3f, 0.5f));
        yield return new WaitForSeconds(0.5f);
        redScreen.color = Color.clear;
    }

}
