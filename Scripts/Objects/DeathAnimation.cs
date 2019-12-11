/************************
 * 프로그램명 : DeathAnimation.cs
 * 작성자 : 안한길 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 12월 3일
 * 프로그램 설명 : badending scene 에서 UI애니메이션을 활성화 한다
 ************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    public GameObject policeImage;
    private Animation police; //경찰이미지 애니메이션
    public GameObject UI;
    private Animation uiAnimation;
    public string sceneName;

    void Start()
    {
        police = policeImage.GetComponent<Animation>();
        uiAnimation = UI.GetComponent<Animation>();
        sceneName = LifeManagement.SceneName;
        UI.SetActive(true);
        uiAnimation.Play("Uianimation");
        police.Play("badEnding");
    }
}
