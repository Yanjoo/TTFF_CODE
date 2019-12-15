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
    // 게임 오브젝트의 Navigation 정보를 분석하여 목표물을 추적하게 하는 컴포넌트
    private NavMeshAgent nav; 
    private Player player;
    private Vector3 spawnPosition;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        // 플레이어를 추적함
        player = GameObject.Find("Player").GetComponent<Player>();
        // 경찰이 원래 있던 자리
        spawnPosition = transform.position;
    }

    void Update()
    {
        // 플레이어의 상태가 무단횡단이면 추적함
        if (player.IsJaywalking()) Chase();
        // 아니면 원래 자리로 유지
        else GetBack();
    }

    // 추적하는 함수
    private void Chase()
    {
        // 자신의 위치와 플레이어의 위치가 다르면 플레이어 위치로 네비게이션 설정
        if (nav.destination != player.transform.position)
            nav.SetDestination(player.transform.position);
        else // 네비게이션 위치랑 플레이어 위치랑 똑같을때
            nav.SetDestination(transform.position);
    }

    private void GetBack()
    {
        // 자신의 위치와 원래 위치가 다르면 원래 위치로 네비게이션 설정
        if (nav.destination != spawnPosition)
            nav.SetDestination(spawnPosition);
        else
            nav.SetDestination(transform.position);
    }
}
