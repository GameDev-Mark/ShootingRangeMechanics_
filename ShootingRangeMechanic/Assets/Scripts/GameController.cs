using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject arrow; // bullet prefab

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

        maxWaitTimeNextShot = 0.1f;
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
            ShootArrow();
            bulletCount--;
            _timeBetweenShots = false;
        }
        else if (bulletCount <= bulletMin)
        { _canShoot = false; }
    }

    // waiting to reload weapon
    void ReloadGun()
    {
        if (_canShoot == false)
        {
            ammoReloadtimer -= Time.deltaTime;
            reloadSlider.value = ammoReloadtimer;
            if (ammoReloadtimer <= ammoReloadTimerMin)
            {
                bulletCount = bulletMax;
                _canShoot = true;
                ammoReloadtimer = ammoReloadTimerMax;
                reloadSlider.value = ammoReloadtimer;
            }
        }
    }

    // small wait time between shots fired
    void WaitTimeBetweenShots()
    {
        if(_timeBetweenShots == false)
        {
            waitForNextShot -= Time.deltaTime;
            if(waitForNextShot <= minWaitTimeNextShot)
            {
                waitForNextShot = maxWaitTimeNextShot;
                _timeBetweenShots = true;
            }
        }
    }

    // shooting bullets function // instantiating, multiplying speed, direction, rotation
    void ShootArrow()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        GameObject arrowShot = Instantiate(arrow, shootingPos.position, Quaternion.Euler(90f, 0f, 0f));
        arrowShot.GetComponent<Rigidbody>().AddForce(ray.direction * shotPower);
    }
}