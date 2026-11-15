using UnityEngine;

public class Resource : MonoBehaviour
{
    private float fastSpeed = 3f;
    private float slowSpeed = 1f;

    public Vector2 targetPos;

    public ResourceType resourceType { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resourceType = ResourceType.Wood;

        Debug.Log($"Target pos : {targetPos}");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Vector2.Distance(transform.position, targetPos) > 0.25f)
            transform.position = Vector2.MoveTowards(transform.position, targetPos, fastSpeed * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, targetPos, slowSpeed * Time.deltaTime);
    }
}
