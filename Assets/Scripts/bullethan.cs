using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullethan : MonoBehaviour
{
    public float launchSpeed = 75.0f;
    public GameObject objectPrefab;
    private float lastFireTime;
    public float fireCooldown = 1.0f; 

    public AudioClip idleAudioClip;
    private AudioSource fireSource;

    public float fireVolume = 0.5f; 

    // Update is called once per frame
    void Start()
    {
       
        fireSource = gameObject.AddComponent<AudioSource>();

        // Set audio clips for each AudioSource
        fireSource.clip = idleAudioClip;

        // Configure AudioSource parameters

        // Set the volume
        fireSource.volume = fireVolume;

        // Start playing the idle audio clip
    }



    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time - lastFireTime > fireCooldown)
        {
            fireSource.Play();
            Spawnobject();
        }
    }
    void  Spawnobject(){
            Vector3 spawnPosition = transform.position;
            Quaternion spawnRotation = Quaternion.identity;

            Vector3 localXDirection = transform.TransformDirection(Vector3.forward);
            Vector3 velocity = localXDirection * launchSpeed;

            GameObject newObject = Instantiate(objectPrefab,spawnPosition,spawnRotation);

            Rigidbody rb = newObject.GetComponent<Rigidbody>();
            rb.velocity = velocity;
    }
}
