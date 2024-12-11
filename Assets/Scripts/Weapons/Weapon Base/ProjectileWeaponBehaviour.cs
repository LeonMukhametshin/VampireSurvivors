using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    protected Vector3 direction;
    public float destroyAfterSeconds;

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
}
