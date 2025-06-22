using System.Collections.Generic;
using UnityEngine;

public class SpawnAnomaly : MonoBehaviour
{
    [System.Serializable]
    public class AnomalyGroup
    {
        public string name; // For Inspector clarity
        public GameObject instanceA; // Hallway 1
        public GameObject instanceB; // Hallway 2
        [HideInInspector] public bool hasSpawned = false;
    }

    public List<AnomalyGroup> anomalyGroups = new List<AnomalyGroup>();
    [Range(0f, 1f)] public float spawnChancePerFloor = 0.3f;

    private AnomalyGroup currentActiveAnomaly = null;


    private void Start()
    {
        foreach (var group in anomalyGroups)
        {
            if (group.instanceA != null) group.instanceA.SetActive(false);
            if (group.instanceB != null) group.instanceB.SetActive(false);
        }
    }


    public void TrySpawnAnomalies()
    {
        Debug.Log("Trying to spawn anomaly...");

        if (GameManager.Instance.anomalyActive)
            return;

        if (Random.value > spawnChancePerFloor)
            return;

        List<AnomalyGroup> available = anomalyGroups.FindAll(a => !a.hasSpawned);
        if (available.Count == 0)
            return;

        int index = Random.Range(0, available.Count);
        AnomalyGroup chosen = available[index];

        if (chosen.instanceA != null) chosen.instanceA.SetActive(true);
        if (chosen.instanceB != null) chosen.instanceB.SetActive(true);

        chosen.hasSpawned = true;
        currentActiveAnomaly = chosen;
        GameManager.Instance.anomalyActive = true;

        Debug.Log("Spawned Anomaly: " + chosen.name);
    }


    public void ClearAnomalies()
    {
        Debug.Log("Cleared anomaly.");

        if (currentActiveAnomaly != null)
        {
            if (currentActiveAnomaly.instanceA != null)
                currentActiveAnomaly.instanceA.SetActive(false);

            if (currentActiveAnomaly.instanceB != null)
                currentActiveAnomaly.instanceB.SetActive(false);

            currentActiveAnomaly = null;
        }

        GameManager.Instance.anomalyActive = false;
    }

}
