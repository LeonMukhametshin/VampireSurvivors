using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [HideInInspector] public float currentHealth;
    [HideInInspector] public float currentRecovery;
    [HideInInspector] public float currentMoveSpeed;
    [HideInInspector] public float currentMight;
    [HideInInspector] public float currentProjectileSpeed;
    [HideInInspector] public float currentMagnet;

    private CharacterScriptableObject characterData;

    public List<GameObject> spawnedWeapons;

    [Header("Experiance/Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experianceCapIncrease;
    }

    [Header("I-Frames")]
    public float invincibilityDuretion;
    private float invincibilityTimer;
    private bool isInvincible;

    public List<LevelRange> levelRanges;

    private void Awake()
    {
        Initialize();

        SpawnWeapon(characterData.StartingWeapon);
    }

    private void Start()
    {
        experience = levelRanges[0].experianceCapIncrease;
    }

    private void Update()
    {
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        else if(isInvincible)
        {
            isInvincible = false;
        }

        Recover();
    }

    public void IncreaseExperience(int amount)
    {
        experience += amount;

        LevelUpChecker();
    }

    private void LevelUpChecker()
    {
        if (experience >= experienceCap)
        {
            level++;
            experience -= experienceCap;
            int experienceCapIncrease = 0;
            foreach (LevelRange range in levelRanges)
            {
                if (level >= range.startLevel && level <= range.endLevel)
                {
                    experienceCapIncrease = range.experianceCapIncrease;
                    break;
                }
            }
            experienceCap += experienceCapIncrease;
        }
    }

    private void Initialize()
    {
        characterData = CharacterSelector.GetData();
        CharacterSelector.instance.DestroySingleton();

        currentHealth = characterData.MaxHealth;
        currentMight = characterData.Might;
        currentMoveSpeed = characterData.MoveSpeed;
        currentRecovery = characterData.Recovery;
        currentProjectileSpeed = characterData.ProjectileSpeed;
        currentMagnet = characterData.Magnet;
    }

    public void TakeDamage(float damage)
    {
        if (isInvincible) return;

        currentHealth -= damage;

        invincibilityTimer = invincibilityDuretion;
        isInvincible = true;

        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Debug.Log("PLAYER IS DEAD");
    }

    public void RestoreHealth(int amount)
    {
        if (currentHealth < characterData.MaxHealth)
        {
            currentHealth += amount;

            if (currentHealth > characterData.MaxHealth)
            {
                currentHealth = characterData.MaxHealth;
            }
        }
    }

    private void Recover()
    {
        if(currentHealth < characterData.MaxHealth)
        {
            currentHealth += currentRecovery * Time.deltaTime;
            if(currentHealth > characterData.MaxHealth)
            {
                currentHealth = characterData.MaxHealth;
            }
        }
    }

    public void SpawnWeapon(GameObject weapon)
    {
        GameObject spawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(transform);
        spawnedWeapons.Add(spawnedWeapon);
    }
}