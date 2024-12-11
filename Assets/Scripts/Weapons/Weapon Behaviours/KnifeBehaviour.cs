using UnityEngine;

public class KnifeBehaviour : ProjectileWeaponBehaviour
{
   KnifeController knifeController;

    protected override void Start()
    {
        base.Start();
        knifeController = FindObjectOfType<KnifeController>();
    }

    private void Update()
    {
        transform.position += direction * knifeController.speed * Time.deltaTime;
    }
} 
