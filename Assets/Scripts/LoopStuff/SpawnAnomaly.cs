using UnityEngine;
using System.Collections.Generic;

public class SpawnAnomaly : MonoBehaviour
{
    [System.Serializable]
    public class Anomaly
    {
        public GameObject instanceA;
        public GameObject instanceB;
        [HideInInspector] public bool hasSpawned = false;
        [HideInInspector] public bool isActive = false; // tracks if it's currently spawned
    }

    public Anomaly[] anomalies;
    [Range(0f, 1f)] public float spawnChance = 1f;

    private readonly List<Anomaly> activeAnomalies = new();

    public void TrySpawnAnomalies()
    {
        ClearAnomalies(); // Clean up previously active anomalies

        // Do not spawn anomalies on floor 1
        if (GameManager.Instance.currentFloor == 1)
        {
            GameManager.Instance.anomalyActive = false;
            return; // No anomaly on floor 1
        }


        foreach (var anomaly in anomalies)
        {
            if (anomaly.hasSpawned)
                continue;

            bool anySpawned = false;

            if (anomaly.instanceA != null && Random.value < spawnChance)
            {
                anomaly.instanceA.SetActive(true);
                anySpawned = true;
            }

            if (anomaly.instanceB != null && Random.value < spawnChance)
            {
                anomaly.instanceB.SetActive(true);
                anySpawned = true;
            }

            if (anySpawned)
            {
                anomaly.hasSpawned = true;
                anomaly.isActive = true;
                activeAnomalies.Add(anomaly);
                GameManager.Instance.anomalyActive = true;
            }
        }
    }

    public void ClearAnomalies()
    {
        foreach (var anomaly in activeAnomalies)
        {
            if (anomaly.isActive)
            {
                if (anomaly.instanceA != null)
                    Destroy(anomaly.instanceA); // Permanently remove from scene

                if (anomaly.instanceB != null)
                    Destroy(anomaly.instanceB);

                anomaly.isActive = false;
            }
        }

        activeAnomalies.Clear();
        GameManager.Instance.anomalyActive = false;
    }

    // Optional: Call this on new game to allow re-spawning
    public void ResetAnomalies()
    {
        foreach (var anomaly in anomalies)
        {
            anomaly.hasSpawned = false;
            anomaly.isActive = false;
        }

        activeAnomalies.Clear();
        GameManager.Instance.anomalyActive = false;
    }
}
