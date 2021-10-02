using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject projectilePrefab;
    private float cooldownBetweenShots = 0.5f;
    private float cooldown = 0f;

    private void Update()
    {
        cooldown = Mathf.Clamp(cooldown - Time.deltaTime, 0f, cooldownBetweenShots);
    }
    public void FireAtPlayer()
    {
        if (cooldown <= 0)
        {
            cooldown += cooldownBetweenShots;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Projectile projectile = Instantiate(projectilePrefab).GetComponent<Projectile>();
            projectile.Init(player.transform, transform, 20, 5f);
        }
    }
}
