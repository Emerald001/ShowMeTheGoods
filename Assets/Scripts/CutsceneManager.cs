using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Texture> scenes;
    public List<string> cutsceneTexts;
    public float timePerText;
    public RawImage image;
    public Text text;
    public int lastTextIndexScene1;

    private Stopwatch timer;
    private int sceneIndex = 0;
    private int textIndex = 0;
    void Start()
    {
        timer = new Stopwatch();
        timer.Start();
        displayScene(sceneIndex);
    }

    private void displayScene(int index)
    {
        image.texture = scenes[index];
    }

    private void updateText()
    {
        text.text = cutsceneTexts[textIndex];
    }

    // Update is called once per frame
    void Update()
    {
        updateText();
        if (timer.ElapsedMilliseconds < 1000 * timePerText)
            return;

        if(textIndex == lastTextIndexScene1)
        {
            sceneIndex++;
            displayScene(sceneIndex);
            timer.Restart();
        }
        if (textIndex < cutsceneTexts.Count - 1)
        {
            textIndex++;
            timer.Restart();
        }
        if (sceneIndex == scenes.Count - 1 && textIndex == cutsceneTexts.Count - 1)
        {
            SceneManager.LoadScene("SampleScene");
            UnityEngine.Debug.LogError("loadingScene");
        }
    }
}
