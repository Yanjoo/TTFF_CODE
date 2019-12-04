/************************
 * 프로그램명 : LifeManagement.cs
 * 작성자 : 이한주 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 12월 4일
 * 프로그램 설명 : Player의 Life를 관리
 ************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManagement : MonoBehaviour
{
    public static int Hit;
    public static int Life = 10;
    public static string SceneName;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Hit = 0;
    }

    void Update()
    {
        Life = 10 - Hit;
    }
}
