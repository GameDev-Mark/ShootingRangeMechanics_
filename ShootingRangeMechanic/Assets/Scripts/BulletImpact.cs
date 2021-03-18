using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    public Light targetLightChanger;
    //GameObject targetBackLitght;

    Vector3 targetLightChangerVector = new Vector3(0f, 1.5f, 0.5f);

    void OnCollisionEnter(Collision collision)
    {
        if (collision.GetContact(0).otherCollider) // destroying bullet on impact of anything // 
        {
            // paint effect where the bullet came in contact with //
            Destroy(gameObject);
        }

        if (collision.GetContact(0).otherCollider.gameObject.name == "Middle") // MIDDLE OF TARGET // RED
        {
            //collision.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            //collision.gameObject.GetComponentInParent<Animator>().SetTrigger("fallBack");
            Debug.Log("MIDDLE HIT");
            // 10 points hit middle target //

            Light lightChanger = Instantiate(targetLightChanger, collision.gameObject.transform.position - targetLightChangerVector, Quaternion.Euler(-75f, 0f, 0f));
            lightChanger.transform.parent = collision.gameObject.transform;
            lightChanger.color = new Color32(255, 0, 0, 255);
            Destroy(lightChanger, 1f);
        }

        if (collision.GetContact(0).otherCollider.gameObject.name == "Inner") // Inner layer of target // GREEN
        {
            //collision.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            //collision.gameObject.GetComponentInParent<Animator>().SetTrigger("fallBack");

            Light lightChanger = Instantiate(targetLightChanger, collision.gameObject.transform.position - targetLightChangerVector, Quaternion.Euler(-75f, 0f, 0f));
            lightChanger.transform.parent = collision.gameObject.transform;
            lightChanger.color = new Color32(0, 255, 0, 255);
            Destroy(lightChanger, 1f);
            Debug.Log("GREEN");
        }
        if (collision.GetContact(0).otherCollider.gameObject.name == "Outer01") // first outer layer of target // BLUE
        {
            //collision.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            //collision.gameObject.GetComponentInParent<Animator>().SetTrigger("fallBack");

            Light lightChanger = Instantiate(targetLightChanger, collision.gameObject.transform.position - targetLightChangerVector, Quaternion.Euler(-75f, 0f, 0f));
            lightChanger.transform.parent = collision.gameObject.transform;
            lightChanger.color = new Color32(0, 0, 255, 255);
            Destroy(lightChanger, 1f);
            Debug.Log("BLUE");
        }
        if (collision.GetContact(0).otherCollider.gameObject.name == "TargetWhole") // Whole layer (OUTER) of target // 
        {
            collision.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            //collision.gameObject.GetComponentInParent<Animator>().SetTrigger("fallBack");

            Light lightChanger = Instantiate(targetLightChanger, collision.gameObject.transform.position - targetLightChangerVector, Quaternion.Euler(-75f, 0f, 0f));
            lightChanger.transform.parent = collision.gameObject.transform;
            lightChanger.color = Color.yellow;
            Destroy(lightChanger, 1f);
            Debug.Log("YELLOW");
        }
    }
}

