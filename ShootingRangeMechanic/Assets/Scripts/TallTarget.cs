using UnityEngine;

public class TallTarget : MonoBehaviour
{
    GameObject leftSideSmallTarget;
    GameObject rightSideSmallTarget;

    float targetSpeed;

    bool _targetAtLeftSide;

    void Start()
    {
        leftSideSmallTarget = GameObject.FindGameObjectWithTag("LeftSideTargetMover");
        rightSideSmallTarget = GameObject.FindGameObjectWithTag("RightSideTargetMover");
        targetSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        // MOVE TARGET TO THE LEFT SIDE AND THEN MOVE IT THE RIGHT // MOVE TARGET BACK TO THE LEFT SIDE //
        if (_targetAtLeftSide == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, leftSideSmallTarget.transform.position + new Vector3(0f, 1.5f, 0f), targetSpeed * Time.deltaTime);
        }
        if (transform.position == leftSideSmallTarget.transform.position + new Vector3(0f, 1.5f, 0f))
        {
            _targetAtLeftSide = true;
        }
        if (_targetAtLeftSide == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, rightSideSmallTarget.transform.position + new Vector3(0f, 1.5f, 0f), targetSpeed * Time.deltaTime);
        }
        if (transform.position == rightSideSmallTarget.transform.position + new Vector3(0f, 1.5f, 0f))
        {
            _targetAtLeftSide = false;
        }
    }
}
