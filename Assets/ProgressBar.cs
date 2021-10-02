using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    private float progress = 50f;
    [SerializeField]
    private float maxProgress = 100f;
    [SerializeField]
    private float minProgress = 0;
    private Transform bar;
    public UnityEvent minReached;
    public UnityEvent maxReached;


    void Start()
    {
        bar = gameObject.transform.Find("Bar");
        SetProgressPercent(progress);
    }

    public void SetProgressPercent(float progress)
    {
        float adjustedProgress = Mathf.Clamp(progress, minProgress, maxProgress);
        bar.localScale = new Vector3(adjustedProgress / 100, 1f, 1f);
        this.progress = adjustedProgress;
        if (adjustedProgress >= maxProgress) maxReached.Invoke();
        else if (adjustedProgress <= minProgress) minReached.Invoke();
    }

    public void AdjustProgressPercent(float progress)
    {
        SetProgressPercent(this.progress + progress);
    }
}
