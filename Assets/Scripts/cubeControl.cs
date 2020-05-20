using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cubeControl : MonoBehaviour
{
	public AudioClip ding;
	AudioSource myAudioSource;
	public Material[] materials;
	public int totalScore = 0;
	public int points = 1;
	public GameObject plane;

    void Awake()
    {
		myAudioSource = GetComponent<AudioSource>();
		Renderer rend = GetComponent<Renderer>();
		rend.enabled = true;
		rend.sharedMaterial = materials[Random.Range(0,(materials.Length))];
	}

    void Update()
    {
		// Check if cube has fallen off the platform
		float yMax = plane.GetComponent<Renderer>().bounds.max.y;
		float yPos = Mathf.Abs(gameObject.GetComponent<Transform>().position.y);
		if (Mathf.Abs(yPos - yMax) > 100) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}

		// Manage arrow key input
		if (Input.GetKey("right")) {
			transform.Translate(0.1f,0,0);
		}
		if (Input.GetKey("left")) {
			transform.Translate(-0.1f,0,0);
		}
		if (Input.GetKey("up")) {
			transform.Translate(0,0,0.1f);
		}
		if (Input.GetKey("down")) {
			transform.Translate(0,0,-0.1f);
		}

    }

	void OnTriggerEnter(Collider other)
	{
		Renderer rend = other.gameObject.GetComponent<Renderer>();
		if (other.gameObject.CompareTag("Droplet"))
		{
			// Increment score and destroy droplet if same color
			if (rend.sharedMaterial.name == GetComponent<Renderer>().sharedMaterial.name) {
				totalScore += points;
				Destroy(other.gameObject);
				myAudioSource.PlayOneShot(ding);
			// Destroy cube and go to Game Over screen if different color
			} else {
				Destroy(gameObject);
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

			}
		}
	}

	// Use PlayerPrefs API to save player score for later display
	void OnDisable()
	{
		PlayerPrefs.SetInt("score", totalScore);
	}
}
