using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<FaderTransition>().RevealContentUnderThisSprite();
        GetComponent<SceneLoader>().SceneLoadAfterSeconds(5); // obvious rubbish, just immediately loads next scene
        Invoke("FadeOut", 3);
    }

    void FadeOut()
    {

        GetComponent<FaderTransition>().HideContentUnderThisSprite();
    }
}
