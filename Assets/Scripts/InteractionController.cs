using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public bool interactionAllowed;
    [SerializeField] private Sprite newSprite;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        interactionAllowed = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        interactionAllowed = false;
    }

    private void Update()
    {
        if (interactionAllowed && Input.GetKey(KeyCode.E)) {
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
    }
}
