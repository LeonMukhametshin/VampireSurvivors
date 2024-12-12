using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObjects/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float cooldownDuration;
    [SerializeField] private int pierce;

    public GameObject Prefab { get { return prefab; } private set { prefab = value; } }
    public float Damage { get { return damage; } private set { damage = value; } }
    public float Speed { get { return speed; } private set { speed = value; } }
    public float CooldownDuration { get { return cooldownDuration; } private set { cooldownDuration = value; } }
    public int Pierce { get { return pierce; } private set { pierce = value; } }
}