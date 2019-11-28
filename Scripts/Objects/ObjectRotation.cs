/************************
 * 프로그램명 : ObjectRotation
 * 작성자 : 홍영선 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 26일
 * 프로그램 설명 : 오브젝트를 Y축 기준으로 지정된 속도로 회전
 ************************/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    Vector3 Rotation;
    public float speed = 180;

    // Start is called before the first frame update
    void Start()
    {
        Rotation = transform.eulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
        Rotation += new Vector3(0, speed, 0) * Time.deltaTime;
        transform.rotation = Quaternion.Euler(Rotation);

    }
}
