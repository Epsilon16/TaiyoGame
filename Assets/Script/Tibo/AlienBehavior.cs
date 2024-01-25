using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlienBehavior : MonoBehaviour
{
    public GameObject target;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = target.transform.position;
    }

    void Update()
    {
        if (transform.position == targetPosition)
        {
            //stop idleanimation

            if (target == null)
            {
                //animation confus
                //animation de se casse
            }
            else
            {
                //target nomor collision
                //passe la target en child
                //animation sur la target
                //animation de se casse
            }

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, 5f * Time.deltaTime);
        }
    }

    public void AlienDies()
    {
        Destroy(gameObject);
    }
}
