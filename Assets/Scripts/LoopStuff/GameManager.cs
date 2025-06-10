using System.Collections;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private SpawnAnomaly anomalySpawner;

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
        anomalySpawner = FindFirstObjectByType<SpawnAnomaly>();

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

        if (FindFirstObjectByType<SpawnAnomaly>() != null)
            FindFirstObjectByType<SpawnAnomaly>().ClearAnomalies();

        if (currentFloor == 1)
        {
            SetEndTriggersActive(true);
        }
        else
        {
            SetEndTriggersActive(false);

            FindFirstObjectByType<SpawnAnomaly>()?.TrySpawnAnomalies();
        }
    }



    public void OnForwardTriggerWithAnomaly()
    {
        Debug.Log("Anomaly active and forward trigger hit. Returning to floor 9.");
        currentFloor = 9;
        anomalyActive = false;

        FindFirstObjectByType<FloorDisplay>().UpdateFloorDisplay();
        EvidenceManager.Instance.OnPlayerEnterFloor(currentFloor);

        if (anomalySpawner != null)
            anomalySpawner.ClearAnomalies();

        SetEndTriggersActive(currentFloor == 1);
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
        if (anomalyActive)
        {
            // Anomaly present + backward trigger => go next floor (n-1)
            currentFloor--;
            anomalyActive = false;
            Debug.Log("Anomaly active and backward trigger hit. Going to next floor: " + currentFloor);
        }
        else
        {
            // No anomaly + backward trigger => return to floor 9 (reset)
            Debug.Log("No anomaly but backward trigger hit. Returning to floor 9.");
            currentFloor = 9;
        }

        FindFirstObjectByType<FloorDisplay>().UpdateFloorDisplay();
        EvidenceManager.Instance.OnPlayerEnterFloor(currentFloor);

        SetEndTriggersActive(currentFloor == 1);

        if (anomalySpawner != null)
            anomalySpawner.ClearAnomalies();
    }

}
