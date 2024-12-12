using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxHealth;
    [SerializeField] private float damage;

    public float MoveSpeed { get { return moveSpeed; } private set { moveSpeed = value; } }
    public float MaxHealth { get { return maxHealth; } private set { maxHealth = value; } }
    public float Damage { get { return damage; } private set { damage = value; } }
}
