/************************
 * 프로그램명 : CarCollider.cs
 * 작성자 : 황승혜 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 25일
 * 프로그램 설명 : 자동차의 충돌 관리 후 상태 값 변경
 ************************/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollider : MonoBehaviour
{
    private Car target;
    private Transform firePos;
    private float SafeDistance;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<Car>();
    }

    // Update is called once per frame
    void Update()
    {
        firePos = target.transform;
        SafeDistance = target.SafeDistance;

        if (target.state == Car.CarState.STAY) target.state = Car.CarState.MOVE;

        Debug.DrawRay(firePos.position, firePos.forward * SafeDistance, Color.green);

        RaycastHit hit;
        if (Physics.Raycast(firePos.position, firePos.forward, out hit, SafeDistance))
        {
            if (hit.collider.tag == "Car")
            {
                target.state = Car.CarState.STAY;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 자동차가 사라짐
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(this.gameObject);
        }
        // 자동차가 멈추고
        if (other.gameObject.CompareTag("Stop"))
        {
            target.state = Car.CarState.STOP;
        }
        // 자동차가 출발
        if (other.gameObject.CompareTag("Go"))
        {
            target.state = Car.CarState.MOVE;
        }
    }

}
