using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class welcomeScreen : MonoBehaviour
{
	public void start()
	{
		// Jump to main game scene
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void instructions()
	{
		// Jump to instructions scene
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
	}
}
