using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCtrl : MonoBehaviour
{

    [Header("最高速度")] public float MaxSpeed;
    [Header("加速力")] public float AccelPerSecond;
    [Header("旋回力")] public float TurnPerSecond;

    //プライベート変数
    private float Speed;
    private Rigidbody rd;


    void Start()
    {
        Speed = 0;
        rd = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        //車の速度について      2021/08/24矢印キーでやったほうが良い検証する
        //if (Input.GetAxis("Vertical"))
        float Gogo = Input.GetAxis("Vertical");

        //if (Input.GetButton("Jump"))

        if(Gogo > 0)
        {
            Speed += AccelPerSecond * Time.deltaTime / 2;

            //最高速度に達したら
            if (Speed > MaxSpeed) Speed = MaxSpeed;
        }
        else if(Gogo < 0)
        {
            Speed -= AccelPerSecond * Time.deltaTime / 3;
        }
        else
        {
            Speed -= AccelPerSecond * Time.deltaTime / 2;

            //減速し速度が0になるとき
            if (Speed < 0) Speed = 0;
        }

        rd.velocity = transform.forward * Speed;

        //車の旋回
        float Handle = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, TurnPerSecond * Handle * Time.deltaTime);
    }
}
