using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splatterPaint : MonoBehaviour
{
    public GameObject paintSprite;
    public AudioClip splat;
	AudioSource myAudioSource;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Handle droplet hitting platform
        if (other.gameObject.CompareTag("Droplet"))
        {
            myAudioSource.PlayOneShot(splat);

            // Place splatter paint sprites on platform after droplets hit
            float dropletX = other.gameObject.GetComponent<Transform>().position.x;
            float dropletZ = other.gameObject.GetComponent<Transform>().position.z;
            Quaternion rotation = Quaternion.LookRotation(new Vector3(0,1,0));
            GameObject item = Instantiate(paintSprite, new Vector3(dropletX,0.0001f,dropletZ), rotation);

            // Match splatter colors to droplet colors
            Color dropColor = other.gameObject.GetComponent<Renderer>().material.color;
            item.GetComponent<Renderer>().material.SetColor("_Color", dropColor);

            Destroy(other.gameObject);
        }

    }
}
