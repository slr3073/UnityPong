using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public Animator animator;

    public void shake() {
        animator.SetTrigger("shake");
    }
}
