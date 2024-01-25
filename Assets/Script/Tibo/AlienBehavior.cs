using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AlienBehavior : MonoBehaviour
{
    public GameObject target;
    private Vector3 targetPosition;

    private Animator animator;

    bool hasArrived = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        targetPosition = target.transform.position;
    }

    void Update()
    {
        if (transform.position == targetPosition && !hasArrived)
        {
            hasArrived = true;
            animator.SetBool("Here", true);

            if (target == null)
            {
                animator.SetBool("IsNotHere", true);
            }
            else
            {
                animator.SetBool("IsHere", true);

                target.GetComponent<Collider2D>().enabled = false;
                target.transform.parent = gameObject.transform;
                StartCoroutine(Steal());
            }

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, 5f * Time.deltaTime);
        }
    }

    IEnumerator Steal()
    {
        float waitTime = 0.01f;
        for (float i = 0; i < 1; i += waitTime)
        {
            target.transform.localScale -= Vector3.one * 1;
            target.transform.position = Vector2.MoveTowards(target.transform.position, transform.GetChild(0).position, 1f * Time.deltaTime);

            yield return new WaitForSeconds(waitTime);
            animator.SetBool("IsNotHere", true);
        }
    }

    public void AlienDies()
    {
        Destroy(gameObject);
    }
}
