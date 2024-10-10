using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PVEController : MonoBehaviour
{
    Animator animator;
    private bool _isHurt;

    public bool IsHurt
    {
        get
        {
            return _isHurt;
        }
        private set
        {
            _isHurt = value;
            animator.SetBool(AnimationStrings.isHurt, value);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponentInParent<EnemyController>())
        {

        }
    }
}
