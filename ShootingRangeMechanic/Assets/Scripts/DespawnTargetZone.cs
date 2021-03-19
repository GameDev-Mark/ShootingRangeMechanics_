using UnityEngine;

public class DespawnTargetZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Target_Small")
        {
            Destroy(other);
            Debug.Log("Despawn");
        }
    }
}
