/************************
 * 프로그램명 : LoadingSceneManager.cs
 * 작성자 : 안한길 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 22일
 * 프로그램 설명 : P
 ************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public static string nextScene;
    public Slider progressBar;
    public Camera camera;
    public Text text_loading;
    public Text text_tip;
    public Image color_progress;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loading");
    }

    IEnumerator LoadScene()
    {
        if (nextScene == "Round2") SetLoading2();
        if (nextScene == "Round3") SetLoading3();

        yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        while (!op.isDone)
        {
            yield return null;
            if (op.progress < 0.9f)
            {
                progressBar.value = Mathf.MoveTowards(progressBar.value, 0.9f, Time.deltaTime);
            }
            else if (op.progress >= 0.9f)
            {
                progressBar.value = Mathf.MoveTowards(progressBar.value, 1f, Time.deltaTime);
            }

            if (progressBar.value >= 1.0f && op.progress >= 0.9f)
            {
                op.allowSceneActivation = true;
            }
        }
    }

    private void SetLoading2()
    {
        color_progress.color = Color.yellow;
        camera.backgroundColor = Color.black;
        text_loading.color = Color.white;
        text_tip.color = Color.white;
        text_tip.text = "                                        Tip!\n" +
            "바닥에 파란 타일을 따라가면 횡단보도가 나와요!";
    }

    private void SetLoading3()
    {
        color_progress.color = Color.black;
        camera.backgroundColor = Color.gray;
        text_loading.color = Color.black;
        text_tip.color = Color.black;
        text_tip.text = "                                        Tip!\n" +
            "무단횡단을 하면 경찰관이 쫓아옵니다.";
    }
}