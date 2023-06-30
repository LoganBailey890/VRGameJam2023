using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportPortal : MonoBehaviour
{
    [SerializeField] AudioSource PortalSound;
    [SerializeField] string scene;
    private float timer;
    private float timerLength;
    private bool startTimer = false;

    private void Awake()
    {
        timerLength = PortalSound.time;
    }

    private void Update()
    {
        if (startTimer)
        {
            timer = Time.deltaTime;
            if(timer > timerLength)
            {
                SceneManager.LoadScene(scene);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        startTimer = true;
        PortalSound.Play();

    }
    private void OnTriggerExit(Collider other)
    {
        startTimer = false;
        timer = 0;
    }
}
