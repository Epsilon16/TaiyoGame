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
    public Animator animator;

    bool hasArrived = false;

    void Start()
    {
    }

    void Update()
    {
        if (transform.position == targetPosition && !hasArrived)
        {
            hasArrived = true;

            if (target == null)
            {
                animator.SetBool("IsNotHere", true);
                StartCoroutine(AlienDies());
            }
            else
            {
                animator.SetBool("IsHere", true);

                target.GetComponent<Collider2D>().enabled = false;
                target.GetComponent<Rigidbody2D>().simulated = false;
                target.transform.parent = gameObject.transform;
                StartCoroutine(Steal());
            }

        }
        else
        {
            if (target != null)
            {
                targetPosition = target.transform.position;
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 4f * Time.deltaTime);
        }
    }

    IEnumerator Steal()
    {
        float waitTime = 0.01f;
        for (float i = 0; i < 1; i += waitTime)
        {
            if (target.transform.localScale.x > 0)
            {
                target.transform.localScale -= Vector3.one * waitTime;
            }
            else
            {
                target.transform.localScale = Vector3.zero;
            }

            target.transform.position = Vector3.MoveTowards(target.transform.position, transform.GetChild(0).position, 5f * Time.deltaTime);

            yield return new WaitForSeconds(waitTime);
            animator.SetBool("IsNotHere", true);
            StartCoroutine(AlienDies());
        }
    }

    IEnumerator AlienDies()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
