using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    GameObject targetLightChanger; // reference to the light
    Animator _lightChangerAnimator; // ref to the component animator on the light
                                    
    GameObject targetImpactSFX; // bulleyes SFX 
    GameObject targetImpactLightSFX; // SFX for the rest of the target

    // unitys start function
    void Start()
    {
        targetLightChanger = GameObject.FindGameObjectWithTag("RoomLight"); // finding and accessing the light in the scene
        _lightChangerAnimator = targetLightChanger.GetComponent<Animator>(); // accessing the animator on the light

        targetImpactSFX = GameObject.FindGameObjectWithTag("TargetImpactSFX"); // finding bulleyes sfx in scene
        targetImpactLightSFX = GameObject.FindGameObjectWithTag("TargetImpactLight"); // finding rest of target sfx in scene
    }

    // unitys OnCollisionEnter function
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
            targetImpactSFX.GetComponent<AudioSource>().Play();
            _lightChangerAnimator.SetTrigger("_redScore");
        }

        if (collision.GetContact(0).otherCollider.gameObject.name == "Inner") // Inner layer of target // GREEN
        {
            collision.gameObject.GetComponentInParent<Animator>().SetTrigger("fallBack");
            targetImpactLightSFX.GetComponent<AudioSource>().Play();
            _lightChangerAnimator.SetTrigger("_greenScore");
        }

        if (collision.GetContact(0).otherCollider.gameObject.name == "Outer01") // first outer layer of target // BLUE
        {
            collision.gameObject.GetComponentInParent<Animator>().SetTrigger("fallBack");
            targetImpactLightSFX.GetComponent<AudioSource>().Play();
            _lightChangerAnimator.SetTrigger("_blueScore");
        }

        if (collision.GetContact(0).otherCollider.gameObject.name == "TargetWhole") // Whole layer (OUTER) of target // YELLOW
        {
            collision.gameObject.GetComponentInParent<Animator>().SetTrigger("fallBack");
            targetImpactLightSFX.GetComponent<AudioSource>().Play();
            _lightChangerAnimator.SetTrigger("_yellowScore");
        }
    }
}

