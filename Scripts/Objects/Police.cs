/************************
 * 프로그램명 : Police.cs
 * 작성자 : 정채은, 홍영선 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 21일
 * 프로그램 설명 : 플레이어가 무단횡단을 하면 플레이어를 쫓아감
 ************************/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Police : MonoBehaviour
{
    private NavMeshAgent nav;
    private Player player;
    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").GetComponent<Player>();
        spawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsJaywalking()) Chase();
        else GetBack();
    }

    private void Chase()
    {
        if (nav.destination != player.transform.position)
            nav.SetDestination(player.transform.position);
        else
            nav.SetDestination(transform.position);
    }

    private void GetBack()
    {
        if (nav.destination != spawnPosition)
            nav.SetDestination(spawnPosition);
        else
            nav.SetDestination(transform.position);
    }
}
