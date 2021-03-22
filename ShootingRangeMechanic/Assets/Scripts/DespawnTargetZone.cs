using UnityEngine;

public class DespawnTargetZone : MonoBehaviour
{
    GameObject target_Small;

    void Update()
    {
        target_Small = GameObject.FindGameObjectWithTag("Target_Small");

        if (target_Small != null)
        {
            if (target_Small.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("TargetFallBack"))
            {
                target_Small.transform.position = Vector3.MoveTowards(target_Small.transform.position, transform.position, 7f * Time.deltaTime);
                target_Small.GetComponent<Target>().enabled = enabled;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target_Small"))
        {
            target_Small.GetComponent<Target>().enabled = enabled;
            Destroy(other.gameObject);
        }
    }
}
