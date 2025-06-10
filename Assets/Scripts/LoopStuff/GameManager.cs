using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int currentFloor = 9;
    public bool anomalyActive = false;

    [Header("Special Object for Level 1")]
    public GameObject[] endTriggerObjects;
    public GameObject forwardTriggerZone; // assign this in inspector

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        // Ensure end triggers are disabled by default
        SetEndTriggersActive(false);
    }

    public void OnForwardTrigger()
    {
        if (anomalyActive)
        {
            Debug.Log("Have anomaly.");
            currentFloor = 9;
        }
        else
        {
            currentFloor--;
        }

        Debug.Log("Now on floor: " + currentFloor);
        anomalyActive = false;

        FindFirstObjectByType<FloorDisplay>().UpdateFloorDisplay();
        EvidenceManager.Instance.OnPlayerEnterFloor(currentFloor);

        // Ensure anomalies are cleared on transition
        FindFirstObjectByType<SpawnAnomaly>().ClearAnomalies();

        if (currentFloor == 1)
        {
            SetEndTriggersActive(true);
        }
        else
        {
            SetEndTriggersActive(false);
        }
    }


    private void SetEndTriggersActive(bool active)
    {
        if (endTriggerObjects != null)
        {
            foreach (GameObject obj in endTriggerObjects)
            {
                if (obj != null)
                    obj.SetActive(active);
            }
        }
    }

    public void OnBackwardTrigger()
    {
        currentFloor--;
        Debug.Log("Player walked back. Now on floor: " + currentFloor);

        FindFirstObjectByType<FloorDisplay>().UpdateFloorDisplay();
        EvidenceManager.Instance.OnPlayerEnterFloor(currentFloor);

        SetEndTriggersActive(currentFloor == 1);
    }
}
