using UnityEngine;

public class ExperienceGem : MonoBehaviour, ICollectible
{
    public int expritienceGranted;

    public void Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.IncreaseExperience(expritienceGranted);
        Destroy(gameObject);
    }
}
