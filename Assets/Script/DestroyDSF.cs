using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDSF : MonoBehaviour
{
    
    void Update()
    {
        StartCoroutine(destroyYourself());
    }

    IEnumerator destroyYourself()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
