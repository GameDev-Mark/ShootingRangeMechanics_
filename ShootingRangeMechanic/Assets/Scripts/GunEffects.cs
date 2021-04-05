using UnityEngine;

public class GunEffects : MonoBehaviour
{
    public ParticleSystem bulletFlashVFX;
    public ParticleSystem bulletBurstVFX;
    public ParticleSystem bulletSmallPS_VFX;

    public AudioSource gunShotSFX;
    public AudioSource gunReloadSFX;

    public void GunShotEffects()
    {
        bulletFlashVFX.Play();
        bulletBurstVFX.Play();
        bulletSmallPS_VFX.Play();
        gunShotSFX.Play();
    }

    public void GunReloadEffect()
    {
        gunReloadSFX.Play();
    }
}
