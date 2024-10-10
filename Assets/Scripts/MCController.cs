using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
// no MCController can be added to a GameObject unless a Rigidbody already exists
// if there is an MCController then the Rigidbody can't be removed until the
// MCController is removed

public class MCController : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }

    public float moveSpeed
    {
        get
        {
            if (CanMove)
            {
                return 10f;
            }
            else
            {
                return 0;
            }
        }
    }
    Vector2 moveInput;

    public float jumpImpulse = 10f;
    TouchingDirections touchingDirections; 

    [SerializeField] private bool _isMoving = false;


    Rigidbody2D rb;
    Animator animator;

    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);
        }
    }

    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    } 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueUI.IsOpen) return;

        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interactable?.Interact(this);
        }
    }

    private void FixedUpdate()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        if (moveInput.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveInput.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // TODO check if alive as well
        if (context.started && touchingDirections.IsGrounded && CanMove)
        {
            animator.SetTrigger(AnimationStrings.jumpTrigger);
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        animator.SetTrigger(AnimationStrings.attackTrigger);
    }

    public void OnEnter(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.enterTrigger);
        }
    }
}