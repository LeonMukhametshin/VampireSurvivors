using UnityEngine;

public class ExperienceGem : Pickup, ICollectible
{
    public int expritienceGranted;

    public void Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.IncreaseExperience(expritienceGranted);
    }
}
