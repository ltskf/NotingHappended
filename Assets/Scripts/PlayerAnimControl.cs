using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimControl : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void startRunAnim()
    {
        anim.SetBool("IsRun", true);
    }
    
    public  void stopRunAnim()
    {
        anim.SetBool("IsRun", false);
    }

    public void startJumpAnim()
    {
        anim.SetTrigger("Jump");
    }
}
