using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    private Transform source;
    private int speedFactor;
    private float damage = 5f;

    private Rigidbody2D projectileBody;
    // Start is called before the first frame update
    void Awake()
    {
        projectileBody = GetComponent<Rigidbody2D>();
    }

    public void Init(Transform target, Transform source, int speedFactor, float damage)
    {
        GetComponentInChildren<SpriteRenderer>().color = new Color(Random.Range(0.2f, 1f), Random.Range(0.2f, 1f), Random.Range(0.2f, 1f));
        this.transform.position = source.position;
        this.damage = damage;
        this.speedFactor = speedFactor;
        Vector2 moveDirection = (target.position - source.position).normalized;
        projectileBody.velocity = moveDirection * speedFactor;
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<GhostPlayerController>().AddShyness(damage);
            Destroy(gameObject);
        }
    }
}
