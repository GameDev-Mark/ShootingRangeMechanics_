using UnityEngine;

public class RespawnTargetZone : MonoBehaviour
{
    GameObject[] target_Small;
    public GameObject small_TargetPrefab;

    // Update is called once per frame
    void Update()
    {
        target_Small = GameObject.FindGameObjectsWithTag("Target_Small");
        Debug.Log(target_Small.Length);

        if (target_Small.Length == 0)
        {
            Instantiate(small_TargetPrefab, transform.position, Quaternion.identity);
            Debug.Log("NULL target");
        }
    }
}