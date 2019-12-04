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
