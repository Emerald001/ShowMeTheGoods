using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTabs : MonoBehaviour
{
    public List<GameObject> messages = new List<GameObject>();

    public GameObject lastobject;
    public int number = 1;

    private void Start() {
        NextMessage(number);    
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            if(number < messages.Count) {
                NextMessage(number);
                number++;
            }
            else {
                lastobject.SetActive(false);
            }
        }
    }

    void NextMessage(int number) {
        if(lastobject != null) {
            lastobject.SetActive(false);
        }

        messages[number].SetActive(true);
        lastobject = messages[number];
    }
}
