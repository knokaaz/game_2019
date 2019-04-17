using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
    ゴール判定スクリプト（簡易）
=============================================*/
public class Goal_Judge : MonoBehaviour
{

    // オブジェクトタグが「　Player　」なら処理続行
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            // デバッグログに表示される
            Debug.Log("Goal !!!!!");
        }
    }
}
