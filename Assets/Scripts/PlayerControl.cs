using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed = 5.0f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float input_H = Input.GetAxisRaw("Horizontal"); //获取X方向的移动方向，如果输入A，输出-1；如果输入D,输出1。

        Vector3 v = new Vector3(input_H, 0, 0); //新建移动向量
        v = v.normalized; //如果是斜线方向，需要对其进行标准化，统一长度为1
        v = v * playerMoveSpeed * Time.deltaTime; //乘以速度调整移动速度，乘以deltaTime防止卡顿现象
        transform.Translate(v); //移动
    }
}