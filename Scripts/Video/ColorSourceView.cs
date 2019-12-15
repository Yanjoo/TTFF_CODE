/************************
 * 프로그램명 : ColorSourceView.cs
 * 작성자 : 안한길 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 12월 14일
 * 프로그램 설명 : 키넥트 카메라로 인식한 사용자 모습의 Texture를 UI에 설정한다.
 ************************/

using UnityEngine;
using UnityEngine.UI;

public class ColorSourceView : MonoBehaviour
{
    public GameObject ColorSourceManager;
    private ColorSourceManager _ColorManager;
    private RawImage Image;
    void Start ()
    {
        Image = GetComponent<RawImage>();
    }
    
    void Update()
    {
        if (ColorSourceManager == null)
        {
            return;
        }
        
        _ColorManager = ColorSourceManager.GetComponent<ColorSourceManager>();
        if (_ColorManager == null)
        {
            return;
        }
        
        Image.texture = _ColorManager.GetColorTexture();
    }
}
