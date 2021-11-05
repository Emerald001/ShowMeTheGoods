using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mandje : MonoBehaviour
{
    public GameObject prefabContainer;

    private List<GameObject> mandje = new List<GameObject>();
    private float totalPrice;
    private GameObject priceContainer;

    public void AddItem(GameObject Item) {
        mandje.Add(Item);
    }

    public void RemoveItem(GameObject Item) {
        mandje.Remove(Item);
    }

    public void SpawnMandje() {
        for (int i = 0; i < mandje.Count; i++) {
            var tmp = Instantiate(prefabContainer, new Vector2(), Quaternion.identity);
        }
    }
}