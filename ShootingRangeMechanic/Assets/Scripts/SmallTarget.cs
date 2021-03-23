using UnityEngine;

public class SmallTarget : MonoBehaviour
{
    GameObject leftSideSmallTarget;
    GameObject rightSideSmallTarget;

    float targetSpeed;

    bool _targetAtLeftSide;

    void Start()
    {
        leftSideSmallTarget = GameObject.FindGameObjectWithTag("LeftSideTargetMover");
        rightSideSmallTarget = GameObject.FindGameObjectWithTag("RightSideTargetMover");
        targetSpeed = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // MOVE TARGET TO THE LEFT SIDE AND THEN MOVE IT THE RIGHT // MOVE TARGET BACK TO THE LEFT SIDE //
        if (_targetAtLeftSide == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, leftSideSmallTarget.transform.position, targetSpeed * Time.deltaTime);
        }
        if (transform.position == leftSideSmallTarget.transform.position)
        {
            _targetAtLeftSide = true;
        }
        if (_targetAtLeftSide == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, rightSideSmallTarget.transform.position, targetSpeed * Time.deltaTime);
        }
        if (transform.position == rightSideSmallTarget.transform.position)
        {
            _targetAtLeftSide = false;
        }
    }
}
