/*
 * 작성자 : 안한길 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 기능 : 커서가 가까이 가면 버튼이 커졌다 작아졌다 애니메이션을 반복한다.
 * 
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
