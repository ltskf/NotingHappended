using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f;

    private Rigidbody2D rdb;

    private void Start()
    {
        rdb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float input_H = Input.GetAxisRaw("Horizontal"); //获取X方向的移动方向，如果输入A，输出-1；如果输入D,输出1。
        
        if (input_H != 0)
        {

            gameObject.transform.localScale = new Vector3((float)(input_H > 0 ? 0.3 : -0.3), (float)0.3, (float)0.3);

            Vector3 v = new Vector3(input_H, 0, 0); //新建移动向量
            v = v.normalized; //如果是斜线方向，需要对其进行标准化，统一长度为1
            v = v * playerMoveSpeed * Time.deltaTime; //乘以速度调整移动速度，乘以deltaTime防止卡顿现象
            transform.Translate(v); //移动
            
            gameObject.GetComponent<PlayerAnimControl>().startRunAnim();
        }
        else
        {
            gameObject.GetComponent<PlayerAnimControl>().stopRunAnim();
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<PlayerAnimControl>().startJumpAnim();
            Vector3 j = new Vector3(0, jumpForce, 0);
            rdb.AddForce(Vector2.up * j, ForceMode2D.Impulse);
        }
    }
}