using UnityEngine;

public class RespawnTargetZone : MonoBehaviour
{
    GameObject[] target_Small; // small target array
    public GameObject small_TargetPrefab; // small target prefab

    GameObject[] target_Tall; // tall target array
    public GameObject Tall_TargetPrefab; // small target prefab

    Vector3 offsetTallTargetPos = new Vector3(0f, 1.5f, 0f); // offset position of tall target

    // unitys update function
    void Update()
    {
        target_Small = GameObject.FindGameObjectsWithTag("Target_Small"); // finding small target in scene
        target_Tall = GameObject.FindGameObjectsWithTag("Target_Tall"); // finding tall target in scene

        if (target_Small.Length == 0) // if the amount of small targets in the scene is none then spawn a small target
        {
            Instantiate(small_TargetPrefab, transform.position, Quaternion.identity);
        }

        if (target_Tall.Length == 0) // if the amount of tall targets in the scene is none then spawn a tall target
        {
            Instantiate(Tall_TargetPrefab, transform.position + offsetTallTargetPos, Quaternion.identity);
        }
    }
}