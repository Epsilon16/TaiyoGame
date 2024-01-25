using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class AlienManager : MonoBehaviour
{
    public GameObject alienPrefab;
    private GameObject currentAlien;
    public GameObject targetPrefab;

    [SerializeField] private bool bigenough = false;
    [SerializeField] private int timeSet = 0;
    [SerializeField] private int timepassed;
    [SerializeField] private bool isSunHere = false;
    [SerializeField] private bool alienUsed = false;

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
                if (allPlanetes[i].GetComponent<FruitInfo>().FruitIndex >= 5)
                {
                    bigenough = true;
                }

                if (allPlanetes[i].GetComponent<FruitInfo>().FruitIndex == 8)
                {
                    isSunHere = true;
                }
            }

            if (timeSet == 0)
            {
                timeSet = Random.Range(5, 9);
            }
            timepassed++;

            if (timepassed >= timeSet && bigenough && !isSunHere)
            {
                timeSet = 0;
                timepassed = 0;
                alienUsed = true;

                int randomPlanete = Random.Range(0, allPlanetes.Length);
                currentAlien = Instantiate(alienPrefab, transform.position, transform.rotation);
                currentAlien.GetComponent<AlienBehavior>().target = allPlanetes[randomPlanete];

                GameObject targetClone = Instantiate(targetPrefab, allPlanetes[randomPlanete].transform.position, transform.rotation);
                targetClone.transform.parent = allPlanetes[randomPlanete].transform;
            }
        }
    }
}
