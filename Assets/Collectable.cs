using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    private float intimationEffect = 10f;

    [SerializeField]
    private float shynessEffect = 0f;

    public UnityEvent playerCollision;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.GetComponent<GhostPlayerController>().AddIntimidation(intimationEffect);
            collider.GetComponent<GhostPlayerController>().AddShyness(shynessEffect);
            playerCollision.Invoke();
            Destroy(gameObject);
        }
    }
}
