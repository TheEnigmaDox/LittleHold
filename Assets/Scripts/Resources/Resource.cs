using UnityEngine;

public class Resource : MonoBehaviour
{
    Vector2 targetPos;

    public ResourceType resourceType { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resourceType = ResourceType.Wood;

        Vector3 randomDir = new Vector3(Random.value, Random.value, 0);

        Debug.Log($"Random Direction : {randomDir + Vector3.one}");
        targetPos = transform.position += (Vector3)Random.insideUnitCircle.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, targetPos, 0.5f); 
    }
}
