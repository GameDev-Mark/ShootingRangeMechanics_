using UnityEngine;

public class DespawnTargetZone : MonoBehaviour
{
    GameObject target_Small; // small target ref
    GameObject target_Tall; // tall target ref

    // unitys update function
    void Update()
    {
        target_Small = GameObject.FindGameObjectWithTag("Target_Small"); // accessing small target in scene
        target_Tall = GameObject.FindGameObjectWithTag("Target_Tall"); // accessing tall target in scene

        if (target_Small != null) // if the small target is in the scene (not null) then check if the animator has been played on it and move the target to the despawn zone
        {
            if (target_Small.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("TargetFallBack_Small"))
            {
                target_Small.transform.position = Vector3.MoveTowards(target_Small.transform.position, transform.position, 7f * Time.deltaTime);
                target_Small.GetComponent<SmallTarget>().enabled = enabled;
                Debug.Log("move small");
            }
        }

        if (target_Tall != null) // if the tall target is in the scene (not null) then check if the animator has been played on it and move the target to the despawn zone
        {
            if (target_Tall.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("TargetFallBack_Tall"))
            {
                target_Tall.transform.position = Vector3.MoveTowards(target_Tall.transform.position, transform.position, 7f * Time.deltaTime);
                target_Tall.GetComponent<TallTarget>().enabled = enabled;
            }
        }
    }

    // unitys ontriggerenter function
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target_Small")) // check if the small target has entered the trigger , then destroy if so
        {
            target_Small.GetComponent<SmallTarget>().enabled = enabled;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Target_Tall")) // check if the tall target has entered the trigger , then destroy if so
        {
            target_Tall.GetComponent<TallTarget>().enabled = enabled;
            Destroy(other.gameObject);
        }
    }
}
