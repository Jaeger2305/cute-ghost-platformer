using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SceneLoader>().SceneLoadAfterSeconds(4); // obvious rubbish, just immediately loads next scene
    }
}
