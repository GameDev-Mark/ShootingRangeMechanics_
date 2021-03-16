using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    public ParticleSystem afterEffectBullet;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.GetContact(0).otherCollider)
        {
            // paint effect where the bullet came in contact with //
            //Instantiate(afterEffectBullet, collision.GetContact(0).otherCollider.transform);
            Destroy(gameObject, 0.1f);
        }
        if(collision.GetContact(0).otherCollider.gameObject.name == "Middle")
        {
            collision.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            collision.gameObject.GetComponentInParent<Animator>().SetTrigger("fallBack");
            // 10 points hit middle target //
        }
    }
}

