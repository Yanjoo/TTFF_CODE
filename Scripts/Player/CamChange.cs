/************************
 * 프로그램명 : CamChange.cs
 * 작성자 : 안한길 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 24일
 * 프로그램 설명 : 키넥트로부터 손의 상태(움켜쥠, 손의 높이)를 입력 받아서 저장
 ************************/   

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChange : MonoBehaviour
{
    public GameObject ThirdCam;
    public GameObject FirstCam;
    public int CamMode;
    // Start is called before the first frame update
    private void Start()
    {
        CamMode = 1;
    }
    private void Update()
    {
        if (CamMode == 1)
        {
            // 3인칭 카메라 활성화
            ThirdCam.SetActive(true);
            FirstCam.SetActive(false);
        }
        if (CamMode == 2)
        {
            // 1인칭 카메라 활성화
            ThirdCam.SetActive(false);
            FirstCam.SetActive(true);
        }
    }
    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FirstCam"))
        {
            CamMode = 2;
        }
        if (other.gameObject.CompareTag("ThirdCam"))
        {
            CamMode = 1;
        }

    }
    
}
