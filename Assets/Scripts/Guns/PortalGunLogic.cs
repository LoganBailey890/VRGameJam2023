using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGunLogic : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletSpawn;
    [SerializeField] GameObject portal;
    [SerializeField] AudioSource chargeSound;
    [SerializeField] AudioSource shootSound;
    [SerializeField] AudioSource powerDownSound;
    private float timer = 0;
    private float setTimer = 1.2f;
    private float bulletSpeed = 5;
    private bool isTriggerPressed = false;
    private bool isPortalShot = false;
    private GameObject shotPortal;

    private void Update()
    {
        if (isTriggerPressed)
        {
            timer += Time.deltaTime;
            if(timer > setTimer && !isPortalShot) 
            {
                if(shotPortal != null )
                {
                    DestroyImmediate(shotPortal);
                }
                shootSound.Play();
                GameObject instBullet = Instantiate(bullet,bulletSpawn.transform);
                instBullet.GetComponent<Rigidbody>().velocity = bulletSpawn.transform.forward * bulletSpeed;
                isPortalShot = true;
            }
        }
    }

    public void OnGunTrigger()
    {
        isTriggerPressed = true;
        chargeSound.Play();
        isPortalShot = false;
    }

    public void OffGunTrigger()
    {
        chargeSound.Stop();
        powerDownSound.Play();
        isTriggerPressed = false;
        timer = 0;
    }

    public void SetPortalLocation(ContactPoint contact)
    {
        shotPortal = Instantiate(portal);
        shotPortal.transform.position = contact.point;
        shotPortal.transform.forward = contact.normal;
    }
}
