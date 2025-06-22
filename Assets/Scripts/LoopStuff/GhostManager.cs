using UnityEngine;

public class GhostManager : MonoBehaviour
{
    public static GhostManager Instance;

    [Header("Ghost Objects")]
    public GameObject[] ghostObjects;  // Assign both ghost objects (2 hallways) in Inspector

    private int currentFloor = -1;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void OnPlayerEnterFloor(int newFloor)
    {
        if (newFloor == currentFloor)
            return;

        currentFloor = newFloor;

        if (currentFloor == 1)
        {
            SetGhostsActive(true);
            Debug.Log("Ghosts enabled on floor 1.");
        }
        else
        {
            SetGhostsActive(false);
            Debug.Log("Ghosts disabled on floor " + currentFloor);
        }
    }

    private void SetGhostsActive(bool active)
    {
        foreach (var ghost in ghostObjects)
        {
            if (ghost != null)
                ghost.SetActive(active);
        }
    }
}
