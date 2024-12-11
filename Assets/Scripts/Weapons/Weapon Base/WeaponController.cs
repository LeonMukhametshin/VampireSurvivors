using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    public float dabage;
    public float speed;
    public float cooldonwDuration;

    private float currentCooldown;
    public int pierce;

    protected PlayerMovement playerMovement;

    protected virtual void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();    
        currentCooldown = cooldonwDuration;
    }

    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)
        {
            Attack();

        }
    }

    protected virtual void Attack()
    {
        currentCooldown = cooldonwDuration;
    }
}
