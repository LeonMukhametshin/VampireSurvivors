using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObjects/Character")]
public class CharacterScriptableObject : ScriptableObject
{
    [SerializeField] private GameObject startingWeapon;
    [SerializeField] private float maxHealth;
    [SerializeField] private float recovery;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float might;
    [SerializeField] private float projectileSpeed;

    public GameObject StartingWeapn { get { return startingWeapon; } private set { startingWeapon = value; } }
    public float MaxHealth { get { return maxHealth; } private set { maxHealth = value; } }
    public float Recovery { get { return recovery; } private set { recovery = value; } }
    public float MoveSpeed { get { return moveSpeed; } private set { moveSpeed = value; } }
    public float Might { get { return might; } private set { might = value; } }
    public float ProjectileSpeed { get { return might; } private set { projectileSpeed = value; } }

}
