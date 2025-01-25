using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    private bool drag = false;
    private bool tilting;
    Animator animator;
    private Vector3 startSpot;
    private bool moving;
    private PotionController potionController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        potionController = GetComponent<PotionController>();
        startSpot = gameObject.transform.position;

    }

    private void OnMouseDown()
    {
        drag = true;
    }

    private void OnMouseUp()
    {
        drag = false;
        iTween.MoveTo(gameObject, startSpot, 2f);
        moving = true;
        animator.Play("TiltUp");
        tilting = false;
        potionController.canPour = false;
        Invoke("ResetMove", 2f);

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pot" && !tilting && !moving)
        {
            tilting = true;
            potionController.canPour = true;
            animator.Play("TiltDown");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pot" && tilting && !moving)
        {
            tilting = false;
            potionController.canPour = false;
            animator.Play("TiltUp");
        }

    }

    private void Update()
    {
        if (drag)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }

    }
    private void ResetMove()
    {
        moving = false;
    }
}