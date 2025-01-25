using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    private float tiltDuration = 0.3f;
    private bool drag = false;
    private bool tilting;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        drag = true;
    }

    private void OnMouseUp()
    {
        drag = false;
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