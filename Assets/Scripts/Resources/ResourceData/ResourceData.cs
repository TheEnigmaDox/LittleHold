using UnityEngine;

[CreateAssetMenu(menuName = "Resource Data", fileName = "ResourceData")]
public class ResourceData : ScriptableObject
{
    public string resourceID;
    public string resourceName;
    public ResourceType resourceType;
    public Sprite unharvested;
    public Sprite harvested;
    public float respawnTime;
    public float maxSpawnTime;
    public int maxHealth = 3;
    public GameObject material;
    public int maxDrops;
}
