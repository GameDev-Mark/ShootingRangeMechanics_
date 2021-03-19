using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_De_Re_Spawner : MonoBehaviour
{
    GameObject target_Small;
    GameObject despawnZoneSmallTarget;
    GameObject respawnZoneSmallTarget;


    // Start is called before the first frame update
    void Start()
    {
        target_Small = GameObject.FindGameObjectWithTag("Target_Small");
        despawnZoneSmallTarget = GameObject.FindGameObjectWithTag("DespawnTargetMover");
        respawnZoneSmallTarget = GameObject.FindGameObjectWithTag("RespawnTargetMover");
    }

    // Update is called once per frame
    void Update()
    {
        if (target_Small.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("TargetFallBack"))
        {
            target_Small.transform.position = Vector3.MoveTowards(target_Small.transform.position, despawnZoneSmallTarget.transform.position, 5f * Time.deltaTime);
        }
        //if (target_Small.transform.position == despawnZoneSmallTarget.transform.position)
        //{
        //    GameObject smallTarget = Instantiate(target_Small, respawnZoneSmallTarget.transform.position, Quaternion.identity);
        //}
     
    }
}
