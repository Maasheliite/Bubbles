using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    private float tiltDuration = 0.3f;
    private bool drag = false;
    private bool tilting;
    Animator animator;
    private Vector3 startSpot;
    private Transform currentSpot;

    private void Start()
    {
        animator = GetComponent<Animator>();
        startSpot = gameObject.transform.position;

    }

    private void OnMouseDown()
    {
        drag = true;
    }

    private void OnMouseUp()
    {
        drag = false;
        currentSpot = gameObject.transform;
        iTween.MoveTo(gameObject, startSpot, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pot" && !tilting)
        {
            tilting = true;

            animator.Play("TiltDown");
            //Debug.Log("pot");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pot" && tilting)
        {
            tilting = false;
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


    IEnumerator Move()
    {
        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        while (Time.time - startTime <= 1)
        { // until one second passed
            transform.position = Vector3.Lerp(currentSpot.position, startSpot, Time.time - startTime); // lerp from A to B in one second
            yield return 1; // wait for next frame
        }

    }
}

/********
 *     private IEnumerator Tilt(float duration)
    {
        float startRotation = transform.eulerAngles.z;
        float endRotation = startRotation + 90f;

        float t = 0.0f;

        while (t < duration)
        {
            t += Time.deltaTime;

            float zRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 90f;

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotation);

            yield return null;
        }
    }
*/