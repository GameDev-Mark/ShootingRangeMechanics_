using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shooting : MonoBehaviour
{
    public GameObject bullet; // bullet prefab

    public Transform shootingPos; // shooting position of bullet

    public TMP_Text ammoText; // UI text for ammo

    public Slider reloadSlider; // represent ammo amount on slider

    float shotPower; // power of bullet fired
    float bulletCount, bulletMax, bulletMin; // bullet count, max and min amount
    float ammoReloadTimerMax, ammoReloadTimerMin, ammoReloadtimer; // ammo reload min and max time
    float maxWaitTimeNextShot, minWaitTimeNextShot, waitForNextShot; // wait for x seconds between shots

    bool _canShoot = true; // bool check if you have ammo
    bool _timeBetweenShots = true; // bool check between shots fired

    // unity's start function
    void Start()
    {
        shotPower = 50f;

        bulletMax = 10f;
        bulletMin = 0f;
        bulletCount = bulletMax;

        ammoReloadTimerMax = 2f;
        ammoReloadTimerMin = 0f;
        ammoReloadtimer = ammoReloadTimerMax;

        maxWaitTimeNextShot = 0.5f;
        minWaitTimeNextShot = 0f;
        waitForNextShot = maxWaitTimeNextShot;
    }

    // unitys update function
    void Update()
    {
        ammoText.text = "Ammo - / " + bulletCount;
        TriggeringShot();
        ReloadGun();
        WaitTimeBetweenShots();
    }

    // triggering shot
    void TriggeringShot()
    {
        if (Input.GetMouseButtonDown(0) && _canShoot == true && _timeBetweenShots == true)
        {
            ShootBullet();
            bulletCount--;
            _timeBetweenShots = false;
        }
        else if (bulletCount <= bulletMin)
        { _canShoot = false; }
        else
        {
            GetComponentInChildren<Animator>().SetTrigger("isIdle");
        }
    }

    // waiting to reload weapon
    void ReloadGun()
    {
        if (_canShoot == false)
        {
            ammoReloadtimer -= Time.deltaTime;
            reloadSlider.value = ammoReloadtimer;
            GetComponentInChildren<Animator>().SetTrigger("canReload");
            if (ammoReloadtimer <= ammoReloadTimerMin)
            {
                bulletCount = bulletMax;
                _canShoot = true;
                ammoReloadtimer = ammoReloadTimerMax;
                reloadSlider.value = ammoReloadtimer;
            }
        }
        else
        {
            GetComponentInChildren<Animator>().SetTrigger("isIdle");
        }
    }

    // small wait time between shots fired
    void WaitTimeBetweenShots()
    {
        if (_timeBetweenShots == false)
        {
            waitForNextShot -= Time.deltaTime;
            if (waitForNextShot <= minWaitTimeNextShot)
            {
                waitForNextShot = maxWaitTimeNextShot;
                _timeBetweenShots = true;
            }
        }
    }

    // shooting bullets function // instantiating, multiplying speed, direction, rotation
    void ShootBullet()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        GameObject _bullet = Instantiate(bullet, shootingPos.position, Quaternion.Euler(0f, -90f, 0f));
        _bullet.GetComponent<Rigidbody>().AddForce(ray.direction * shotPower);
        GetComponentInChildren<Animator>().SetTrigger("canShoot");
    }
}
