using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject leftSide;
    public GameObject rightSide;

    bool _targetAtLeftSide;

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.back * 20 * Time.deltaTime);

        // MOVE TARGET TO THE LEFT SIDE AND THEN MOVE IT THE RIGHT // MOVE TARGET BACK TO THE LEFT SIDE //
        if (_targetAtLeftSide == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, leftSide.transform.position, 2f * Time.deltaTime);
        }
        if (transform.position == leftSide.transform.position)
        {
            _targetAtLeftSide = true;
            Debug.Log("Target" + _targetAtLeftSide);
        }
        if (_targetAtLeftSide == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, rightSide.transform.position, 2f * Time.deltaTime);
        }
        if (transform.position == rightSide.transform.position)
        {
            _targetAtLeftSide = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Bullet"))
        {
            transform.Rotate(Vector3.right * 90f * Time.deltaTime);
            Debug.Log("BULLET HIT");
        }
    }
}
