using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EvidenceManager : MonoBehaviour
{
    [System.Serializable]
    public class EvidenceInfo
    {
        public int floorNumber;
        public GameObject slotA; // Placed manually in the scene, disabled by default
        public GameObject slotB; // Placed manually in the scene, disabled by default
    }

    public static EvidenceManager Instance;

    public EvidenceInfo[] evidences;
    public CanvasGroup evidencePopupUI;
    public Text popupText;

    private HashSet<int> spawnedFloors = new();
    private HashSet<int> collectedFloors = new();
    private List<GameObject> spawnedEvidenceObjects = new();

    private int currentFloor = -1;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void CollectEvidence(GameObject evidenceObject)
    {
        EvidenceInfo matchedEvidence = null;

        // Match clicked object to evidence slot
        foreach (var evidence in evidences)
        {
            if (evidence.slotA == evidenceObject || evidence.slotB == evidenceObject)
            {
                matchedEvidence = evidence;
                break;
            }
        }

        if (matchedEvidence == null)
        {
            Debug.LogWarning("Collected evidence doesn't match any floor.");
            return;
        }

        int floor = matchedEvidence.floorNumber;

        if (!collectedFloors.Contains(floor))
        {
            collectedFloors.Add(floor);
            Debug.Log("Collected Floors: " + string.Join(", ", collectedFloors));

            // Check if this is the special floor 8 cutscene (element 0)
            if (evidences.Length > 0 && evidences[0] == matchedEvidence)
            {

                return; // Skip rest of the method during cutscene
            }
        }

        // Disable both slots
        if (matchedEvidence.slotA != null)
        {
            matchedEvidence.slotA.SetActive(false);
            spawnedEvidenceObjects.Remove(matchedEvidence.slotA);
        }

        if (matchedEvidence.slotB != null)
        {
            matchedEvidence.slotB.SetActive(false);
            spawnedEvidenceObjects.Remove(matchedEvidence.slotB);
        }

        ShowPopup($"{collectedFloors.Count} / {evidences.Length}");
        Debug.Log($"Collected evidence: {collectedFloors.Count} / {evidences.Length}");
    }

    public void TrySpawnEvidenceForFloor(int floor)
    {
        if (spawnedFloors.Contains(floor) || collectedFloors.Contains(floor))
            return;

        foreach (var evidence in evidences)
        {
            if (evidence.floorNumber == floor)
            {
                if (evidence.slotA != null)
                {
                    evidence.slotA.SetActive(true);
                    spawnedEvidenceObjects.Add(evidence.slotA);
                    Debug.Log($"Evidence slot A enabled on floor {floor}");
                }

                if (evidence.slotB != null)
                {
                    evidence.slotB.SetActive(true);
                    spawnedEvidenceObjects.Add(evidence.slotB);
                    Debug.Log($"Evidence slot B enabled on floor {floor}");
                }

                spawnedFloors.Add(floor);
                break;
            }
        }
    }

    public void OnPlayerEnterFloor(int newFloor)
    {
        if (newFloor == currentFloor)
            return;

        currentFloor = newFloor;

        // Disable currently spawned evidence
        for (int i = spawnedEvidenceObjects.Count - 1; i >= 0; i--)
        {
            if (spawnedEvidenceObjects[i] != null)
                spawnedEvidenceObjects[i].SetActive(false);
        }

        spawnedEvidenceObjects.Clear();
        spawnedFloors.Remove(newFloor);

        TrySpawnEvidenceForFloor(newFloor);
    }

    private void ShowPopup(string message)
    {
        if (popupText != null)
        {
            popupText.text = message;
            StopAllCoroutines();
            StartCoroutine(FadePopup());
        }
    }

    private IEnumerator FadePopup()
    {
        evidencePopupUI.alpha = 1;
        yield return new WaitForSeconds(2f);
        while (evidencePopupUI.alpha > 0)
        {
            evidencePopupUI.alpha -= Time.deltaTime;
            yield return null;
        }
    }

}
