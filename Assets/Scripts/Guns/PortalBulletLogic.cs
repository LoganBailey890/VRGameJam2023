using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBulletLogic : MonoBehaviour
{
    [SerializeField] float bulletLifeTime = 3f;
    private float timer = 0;
    private PortalGunLogic gunLogic;

    private void Awake()
    {
        gunLogic = FindFirstObjectByType<PortalGunLogic>().GetComponent<PortalGunLogic>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if( timer > bulletLifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);
        gunLogic.SetPortalLocation(contact);
        Destroy(gameObject);
    }
}
