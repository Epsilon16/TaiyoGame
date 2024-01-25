using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class AlienManager : MonoBehaviour
{
    public GameObject alienPrefab;
    private GameObject currentAlien;

    private bool bigenough = false;
    private int timeSet = 0;
    private int timepassed;
    private bool isSunHere = false;
    private bool alienUsed = false;

    void Update()
    {

        if (currentAlien == null)
        {
            alienUsed = false;
        }

        if (UserInput.isThrowPressed && THrowFruitController.instance.CanThrow && !isSunHere && !alienUsed)
        {
            GameObject[] allPlanetes = GameObject.FindGameObjectsWithTag("Planete");

            bigenough = false;
            for (int i = 0; i < allPlanetes.Length; i++)
            {
                if (allPlanetes[i].GetComponent<SpriteIndex>().Index >= 5)
                {
                    bigenough = true;
                }

                if (allPlanetes[i].GetComponent<SpriteIndex>().Index == 8)
                {
                    isSunHere = true;
                }
            }

            if (timeSet != 0)
            {
                timeSet = Random.Range(1, 6);
            }
            timepassed++;

            if (timepassed >= timeSet && bigenough && !isSunHere)
            {
                timeSet = 0;
                alienUsed = true;

                int randomPlanete = Random.Range(0, allPlanetes.Length);
                currentAlien = Instantiate(alienPrefab, transform.position, transform.rotation);
                //SpawnCible
                currentAlien.GetComponent<AlienBehavior>().target = allPlanetes[randomPlanete];
            }
        }
    }
}
