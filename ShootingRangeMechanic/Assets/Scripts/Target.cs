using UnityEngine;

public class Target : MonoBehaviour
{
    GameObject leftSideSmallTarget;
    GameObject rightSideSmallTarget;

    bool _targetAtLeftSide;

    void Start()
    {
        leftSideSmallTarget = GameObject.FindGameObjectWithTag("LeftSideTargetMover");
        rightSideSmallTarget = GameObject.FindGameObjectWithTag("RightSideTargetMover");
    }


    // Update is called once per frame
    void Update()
    {
        // MOVE TARGET TO THE LEFT SIDE AND THEN MOVE IT THE RIGHT // MOVE TARGET BACK TO THE LEFT SIDE //
        if (_targetAtLeftSide == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, leftSideSmallTarget.transform.position, 2f * Time.deltaTime);
        }
        if (transform.position == leftSideSmallTarget.transform.position)
        {
            _targetAtLeftSide = true;
        }
        if (_targetAtLeftSide == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, rightSideSmallTarget.transform.position, 2f * Time.deltaTime);
        }
        if (transform.position == rightSideSmallTarget.transform.position)
        {
            _targetAtLeftSide = false;
        }
    }
}
