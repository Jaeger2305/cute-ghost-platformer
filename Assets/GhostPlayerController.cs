using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostPlayerController : MonoBehaviour
{
    private float intimidation = 1f;
    private float shyness = 1f;
    // called first
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // This is pretty lazy, attaching this handler whenever a scene is loaded...
        // Probably better would be to have a single init script required to reset the scene
        Init();
    }

    private void Start()
    {
        Init();
    }


    private void Init()
    {
        Debug.Log(string.Format("setting shyness to {0} and intimidation to {1}", shyness, intimidation));
        intimidation = 1f;
        shyness = 1f;
        gameObject.transform.Find("ShyProgressBar").GetComponent<ProgressBar>().SetProgressPercent(shyness);
        gameObject.transform.Find("IntimidationProgressBar").GetComponent<ProgressBar>().SetProgressPercent(intimidation);
    }
    public void AddIntimidation(float value)
    {
        gameObject.transform.Find("IntimidationProgressBar").GetComponent<ProgressBar>().AdjustProgressPercent(value);
    }

    public void AddShyness(float value)
    {
        gameObject.transform.Find("ShyProgressBar").GetComponent<ProgressBar>().AdjustProgressPercent(value);
    }

}
