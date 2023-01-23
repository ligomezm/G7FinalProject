using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreenBehavior : MonoBehaviour
{
    public Animator animator;

    public void FadeIn()
    {
        animator.SetTrigger("FadeOut");
    }
    
}
