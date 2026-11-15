using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceNode : MonoBehaviour, IResource
{
    [SerializeField]
    bool harvested = false;

    [SerializeField]
    private int health;

    [SerializeField]
    private ResourceData data;

    [SerializeField]
    private SpriteRenderer unharvestedRend;

    [SerializeField]
    private SpriteRenderer harvestedRend;

    BoxCollider2D myCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        unharvestedRend.enabled = true;
        health = data.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        myCollider.enabled = !harvested;

        if (health < 0)
        {
            harvested = true;

            int drops = Random.Range(1, data.maxDrops);

            for (int i = 0; i < drops; i++)
            {
                Instantiate(data.material, this.transform.position, Quaternion.identity);
            }

            health = 3;
        }

        if (!harvested)
        {
            harvestedRend.enabled = false;
            unharvestedRend.enabled = true;
            data.respawnTime = data.maxSpawnTime;
        }
        else
        {
            unharvestedRend.enabled = false;
            harvestedRend.enabled = true;

            data.respawnTime -= Time.deltaTime;
            if (data.respawnTime < 0)
            {
                harvested = false;
            }
        }
    }

    public void Harvest(int amount)
    {
        health -= amount;
    }
}
