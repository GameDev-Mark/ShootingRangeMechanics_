using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    GameObject targetLightChanger;

    void Start()
    {
        targetLightChanger = GameObject.FindGameObjectWithTag("RoomLight");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.GetContact(0).otherCollider) // destroying bullet on impact of anything // 
        {
            // paint effect where the bullet came in contact with //
            Destroy(gameObject);
        }

        if (collision.GetContact(0).otherCollider.gameObject.name == "Middle") // MIDDLE OF TARGET // RED
        {
            collision.gameObject.GetComponentInParent<Animator>().SetTrigger("fallBack");
            targetLightChanger.GetComponent<Animator>().SetTrigger("_redScore");
            // 10 points hit middle target //
        }
        if (collision.GetContact(0).otherCollider.gameObject.name == "Inner") // Inner layer of target // GREEN
        {
            //collision.gameObject.GetComponentInParent<Animator>().SetTrigger("fallBack");
            targetLightChanger.GetComponent<Animator>().SetTrigger("_greenScore");
        }
        if (collision.GetContact(0).otherCollider.gameObject.name == "Outer01") // first outer layer of target // BLUE
        {
            //collision.gameObject.GetComponentInParent<Animator>().SetTrigger("fallBack");
            targetLightChanger.GetComponent<Animator>().SetTrigger("_blueScore");
        }
        if (collision.GetContact(0).otherCollider.gameObject.name == "TargetWhole") // Whole layer (OUTER) of target // YELLOW
        {
            //collision.gameObject.GetComponentInParent<Animator>().SetTrigger("fallBack");
            targetLightChanger.GetComponent<Animator>().SetTrigger("_yellowScore");
        }
    }
}

