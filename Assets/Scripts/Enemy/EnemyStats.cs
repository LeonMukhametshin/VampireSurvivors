using System;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    private float currentMoveSpeed;
    private float currentHealth;
    private float currentDamage;

    private void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("TakeDamage");
        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        Debug.Log("Kill");
        Destroy(gameObject);
    }
}