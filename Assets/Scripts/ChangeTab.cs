using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTab : MonoBehaviour
{
    public List<GameObject> tabs;
    public List<GameObject> webPages;
    public List<string> URLs;

    public Text URL;

    public Color activeColor;
    public Color inActiveColor;

    protected Dictionary<GameObject, GameObject> Containers = new Dictionary<GameObject, GameObject>();
    protected Stack<GameObject> BackCommands = new Stack<GameObject>();
    protected Stack<GameObject> ForwardsCommands = new Stack<GameObject>();
    protected GameObject lastTab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < tabs.Count; i++) {
            Containers.Add(tabs[i], webPages[i]);
        }

        lastTab = tabs[0];
    }
    
    public void ChangeTabs(GameObject tab) {
        if (tab == lastTab) return;

        for (int i = 0; i < webPages.Count; i++) {
            webPages[i].SetActive(false);
            tabs[i].GetComponent<Image>().color = inActiveColor;
        }

        if (Containers.ContainsKey(tab)) {
            for (int i = 0; i < tabs.Count; i++) {
                if(tabs[i] == tab) {
                    URL.text = URLs[i];
                }
            }
            tab.GetComponent<Image>().color = activeColor;
            Containers[tab].SetActive(true);

            BackCommands.Push(lastTab);

            lastTab = tab;
        }
    }

    public void FuckGoBack() {
        if(BackCommands.Count != 0) {
            var temp = BackCommands.Pop();
            ForwardsCommands.Push(lastTab);
            ChangeTabs(temp);
            BackCommands.Pop();
        }
    }

    public void ForwardsAgain() {
        if(ForwardsCommands.Count != 0)
            ChangeTabs(ForwardsCommands.Pop());
    }

    public void ClearForwards() {
        ForwardsCommands.Clear();
    }

    public void Quit() {
        Debug.LogError("Quit");
        Application.Quit();
    }
}