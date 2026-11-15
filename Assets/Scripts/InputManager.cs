using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;

    private Inputs inputs;

    private void Awake()
    {
        instance = this;

        inputs = new Inputs();

        Random.InitState(System.Environment.TickCount);
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void Update()
    {
        //Debug.Log($"Left Mouse : {LeftMouseClick()}");
        //Debug.Log($"Right Mouse : {RightMouseClick()}");
        //Debug.Log($"Mouse Delta : {MouseDelta()}");
    }

    public bool LeftMouseClick()
    {
        return inputs.Input.LeftMouse.WasPressedThisFrame();
    }

    public bool RightMouseClick()
    {
        return inputs.Input.RightClick.WasPressedThisFrame();
    }

    public bool RightMousePressed()
    {
        return inputs.Input.RightClick.IsPressed();
    }

    public Vector2 MouseDelta()
    {
        return inputs.Input.MouseDelta.ReadValue<Vector2>();
    }

    public Vector2 MousePosition()
    {
        return inputs.Input.MousePos.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }
}
