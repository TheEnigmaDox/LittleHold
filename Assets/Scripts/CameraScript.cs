using UnityEngine;
using UnityEngine.Rendering;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private float cameraSpeed = 0.75f;

    [SerializeField]
    private Vector2 minPos;

    [SerializeField]
    private Vector2 maxPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.Instance.RightMousePressed())
        {
            transform.position -= new Vector3(InputManager.Instance.MouseDelta().x, InputManager.Instance.MouseDelta().y, 0) * cameraSpeed;
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x),
            Mathf.Clamp(transform.position.y, minPos.y, maxPos.y),
            transform.position.z);

        if (InputManager.Instance.LeftMouseClick())
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(InputManager.Instance.MousePosition());

            var resourceNode = Physics2D.OverlapPoint(mousePos);

            if (resourceNode != null)
            {
                resourceNode.GetComponent<ResourceNode>().Harvest(1);
            }
        }
    }
}
