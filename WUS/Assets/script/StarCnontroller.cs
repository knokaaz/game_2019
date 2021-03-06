﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCnontroller : MonoBehaviour
{
    Rigidbody rigid;
    Vector3 startPos;
    //  private float speed;

    public Slider shotGauge;
    float speed = 0f;
    float gaugeLength = 0f;
    bool shotGaugeSet = false;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid = GetComponent<Rigidbody>();
        this.rigid.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {

        // マウスを押した地点の座標を記録
        if (Input.GetMouseButtonDown(0))
        {
            this.startPos = Input.mousePosition;
            shotGaugeSet = true;
        }

        // マウスを離した地点の座標から、発射方向を計算
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 endPos = Input.mousePosition;
            Vector3 startDirection = -1 * (endPos - startPos).normalized;
            this.rigid.AddForce(startDirection * speed);
            shotGaugeSet = false;
            Debug.Log(speed);
            this.rigid.useGravity = true;
        }

        // マウスが押されている間 ショットゲージを呼ぶ
        if (shotGaugeSet)
        {
            shotGaugeValue();
        }

        // テスト用：スペースキー押下で停止
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid.velocity *= 0;
        }

    }

    void FixedUpdate()
    {
        this.rigid.velocity *= 0.995f;
    }

    // ショットゲージ関数
    void shotGaugeValue()
    {
        Debug.Log("呼び出し確認");
        
            gaugeLength += 0.025f;
            //ゲージがMaxでゼロに戻る
            if (gaugeLength > 1.025f)
            {
                gaugeLength = 0;
            }

            //ゲージ長さをlengthに代入
            shotGauge.value = gaugeLength;
            // スピードをゲージ値から計算
            speed = gaugeLength * 1000f + 500f;
       
    }

}

