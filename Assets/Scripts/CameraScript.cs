using UnityEditor.Rendering;
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

    private void Awake()
    {
        Settings.SetFrameRate();
    }

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

            var overlap = Physics2D.OverlapPointAll(mousePos);
            
            if(overlap != null)
            {
                for(int i = 0; i < overlap.Length; i++)
                {
                    if (overlap[i].TryGetComponent<Resource>(out Resource resource))
                    {
                        resource.PickUpMaterial();
                        return;
                    }
                }

                for (int j = 0; j < overlap.Length; j++)
                {
                    if (overlap[j].TryGetComponent<ResourceNode>(out ResourceNode resourceNode))
                    {
                        resourceNode.Harvest(1);
                    }
                }
            }
        }
    }
}
