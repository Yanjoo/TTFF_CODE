/************************
 * 프로그램명 : PlayerState.cs
 * 작성자 : 이한주 (이한주, 안한길, 정채은, 황승혜, 홍영선)
 * 작성일 : 2019년 11월 24일
 * 프로그램 설명 : 플레이어의 상태 값
 ************************/
  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static int NORMAL = -1;
    public static int RUN = 0;
    public static int HIT = 1;
    public static int DEATH = 9;
    public static int DIZZY = 2;

    public static class Rotation
    {
        public static int LEFT = 3;
        public static int RIGHT = 4;
        public static int KEEP = 5;
    }
}
