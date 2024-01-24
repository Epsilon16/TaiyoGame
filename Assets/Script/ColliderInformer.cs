using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderInformer : MonoBehaviour
{
    public bool WasCombinedIn { get; set; }

    private bool _hasCollided;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_hasCollided && !WasCombinedIn)
        {
            _hasCollided = true;
            THrowFruitController.instance.CanThrow = true;
            THrowFruitController.instance.SpawnAFruit(FruitSelector.instance.NextFruit);
            FruitSelector.instance.PickNextFruit();
            Destroy(this);
        }
    }
}
