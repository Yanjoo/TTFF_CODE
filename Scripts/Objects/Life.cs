/************************
 * 프로그램명 : Life.cs
 * 작성자 : 이한주 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 12월 4일
 * 프로그램 설명 : Player의 Life를 UI로 보여줌
 ************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public Text life_text;
    private int life;

    // Start is called before the first frame update
    void Start()
    {
        life = 10;
    }

    // Update is called once per frame
    void Update()
    {
        life = LifeManagement.Life;
        life_text.text = "Life : " + life;
    }
}
