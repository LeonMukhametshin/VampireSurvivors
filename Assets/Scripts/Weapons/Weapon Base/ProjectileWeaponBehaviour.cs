using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;

    protected Vector3 direction;
    public float destroyAfterSeconds;

    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldonwDuration;
    protected float currentPierce;

    private void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldonwDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;  
    }

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionChecker(Vector3 direction)
    {
        this.direction = direction;
        float directionX = this.direction.x;
        float directionY = this.direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if (directionX < 0 && directionY == 0) // left
        {
            scale.x *= -1;
            scale.y *= -1;
        }
        else if(directionX == 0 && directionY > 0) // up
        {
            scale.x *= -1;
        }
        else if (directionX == 0 && directionY < 0) // down
        {
            scale.y *= -1;
        }
        else if(directionX > 0 && directionY > 0) // right up
        {
            rotation.z = 0;
        }
        else if (directionX > 0 && directionY < 0) // right down
        {
            rotation.z = -90;
        }
        else if (directionX < 0 && directionY > 0) // left up
        {
            rotation.z = 90;
        }
        else if (directionX < 0 && directionY < 0) // left down
        {
            rotation.z = 180;
        }
        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyStats enemy = other.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);
            ReducePierce();
        }
    }

    private void ReducePierce()
    {
        currentPierce--;
        if (currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }
}
