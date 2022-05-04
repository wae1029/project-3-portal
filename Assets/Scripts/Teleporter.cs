using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    private GameObject Player;
    private Vector3 offset= new Vector3(0,2,0);

    [Header("Feedback")]
    [SerializeField] AudioClip teleportSFX = null;
    [SerializeField] ParticleSystem teleportParticle = null;

    AudioSource audioSource = null;


    private void Awake()
    {
        Player = FindObjectOfType<Player>().gameObject;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Player.transform.position = transform.position + offset;
            PlayFX();
           Destroy(gameObject);
           
        }

        else if ((Input.GetMouseButtonDown(1)))
        {
            Player.transform.position = transform.position + offset;
            PlayFX();
            Destroy(gameObject);
        }



    }

    void PlayFX()
    {
        // play gfx
        if (teleportParticle != null)
        {
            teleportParticle.Play();
        }
        // play sfx
        if (audioSource != null && teleportSFX != null)
        {
            audioSource.PlayOneShot(teleportSFX, audioSource.volume);
        }
    }
    //    private void OnTriggerEnter(Collider other)
    //    {
    //        Destroy(gameObject);
    //   }
}