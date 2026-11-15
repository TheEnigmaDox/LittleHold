using UnityEngine;

public class GridManager : MonoBehaviour
{
    private Grid worldGrid;

    private static GridManager instance;
    public static GridManager Instance => instance;

    private void Awake()
    {
        worldGrid = GetComponent<Grid>();

        instance = this;
    }

    public Vector3 ConvertToGrid(Vector3 position)
    {
        position = worldGrid.WorldToCell(position);

        return position;
    }
}
