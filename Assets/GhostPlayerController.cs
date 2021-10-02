using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlayerController : MonoBehaviour
{
    private float intimidation = 1f;
    private float shyness = 1f;
    void Start()
    {
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
