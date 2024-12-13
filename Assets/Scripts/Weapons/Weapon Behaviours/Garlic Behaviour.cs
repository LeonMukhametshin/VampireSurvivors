using System.Collections.Generic;
using UnityEngine;

public class GarlicBehaviour : MeleeWeaponBehaviour
{
    private List<GameObject> markedEnemies;

    private void Awake()
    {
        Init();
        markedEnemies = new List<GameObject>();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !markedEnemies.Contains(collision.gameObject))
        {
            EnemyStats enemy = collision.GetComponent<EnemyStats>();    
            enemy.TakeDamage(currentDamage);

            markedEnemies.Add(collision.gameObject);
        }
        else if (collision.CompareTag("Prop"))
        {
            if (collision.gameObject.TryGetComponent(out BreakableProps breakable) && !markedEnemies.Contains(collision.gameObject))
            {
                breakable.TakeDamage(currentDamage);

                markedEnemies.Add(collision.gameObject);
            }
        }
    }
}
