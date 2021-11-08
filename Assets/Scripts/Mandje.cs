using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mandje : MonoBehaviour
{
    public GameObject prefabContainer;
    public GameObject parentCanvas;
    public GameObject priceContainer;
    public Transform StartingPosition;

    private List<GameObject> mandje = new List<GameObject>();
    private List<GameObject> spawnedObjects = new List<GameObject>();
    private int doublesFound = 0;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            ReloadMandje();
        }
    }

    public void AddItem(GameObject Item) {
        mandje.Add(Item);
        ReloadMandje();
    }

    public void RemoveItem(GameObject Item) {
        var tmp = mandje[Item.GetComponent<PrefabContainerInfo>().ID];
        mandje.Remove(tmp);
        ReloadMandje();
    }

    public void ReloadMandje() {
        var tmpPrice = 0f;

        if(spawnedObjects.Count > 0) {
            for (int i = 0; i < spawnedObjects.Count; i++) {
                GameObject.Destroy(spawnedObjects[i]);
            }
        }

        for (int i = 0; i < mandje.Count; i++) {
            //var isdouble = false;
            //for (int k = 0; k < i; k++) {
            //    if (mandje[i] == mandje[k]) {
            //        isdouble = true;
            //    }
            //}

            //if (isdouble) {
            //    continue;
            //}

            //var currentAmount = 0f;
            //for (int j = 0; j < mandje.Count; j++) {
            //    if (mandje[i] == mandje[j]) {
            //        currentAmount += 1;
            //    }
            //}

            var offset = new Vector2(StartingPosition.position.x, StartingPosition.position.y - (i * 200));
            var tmp = Instantiate(prefabContainer, offset, Quaternion.identity);
            tmp.transform.SetParent(parentCanvas.transform);

            var tmpInfo = tmp.GetComponent<PrefabContainerInfo>();
            var mandjeInfo = mandje[i].GetComponent<ContainerInfo>();

            //if(currentAmount > 0)
            //    tmpInfo.amount = currentAmount;
            tmpInfo.ID = i;
            tmpInfo.itemName = mandjeInfo.itemName;
            tmpInfo.price = mandjeInfo.price;
            tmpPrice += mandjeInfo.price;

            spawnedObjects.Add(tmp);
        }

        priceContainer.transform.position = new Vector2(StartingPosition.position.x, StartingPosition.position.y - ((mandje.Count * 200) + 50));
        priceContainer.GetComponent<PrefabContainerInfo>().price = tmpPrice;
    }
}