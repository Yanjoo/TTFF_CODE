/*
 * 프로그램명 : Highlight.cs
 * 작성자 : 안한길 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 20일 
 * 기능 : 커서오브젝트가 버튼안으로 이동했을때 강조 이벤트가 발생하는 코드 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    Vector3 scale;
    bool highlight;
    // Start is called before the first frame update 
    void Start()
    {
        scale = Vector3.zero;
        scale.x = 6;
        scale.y = 0;
        scale.z = 0;
        highlight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (highlight == true&&(float)transform.localScale.x<=3.8)
            transform.localScale += scale * Time.deltaTime;
        if (highlight == false && (float)transform.localScale.x >= 3.3)
            transform.localScale -= scale * Time.deltaTime;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            highlight = true;
            
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            highlight = false;

        }
    }
}
