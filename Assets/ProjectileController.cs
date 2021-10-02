using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject projectilePrefab;
    private int shotsPerMinute = 30;

    private void Start()
    {
        InvokeRepeating("FireAtPlayer", 1f, 60 / shotsPerMinute);
    }
    public void FireAtPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Projectile projectile = GameObject.Instantiate(projectilePrefab).GetComponent<Projectile>();
        projectile.Init(player.transform, transform, 20, 5f);
    }
}
