using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
	public Text scoreText;

	// public void Start ()
	// {
	// 	scoreText.text = cube.GetComponent<cubeControl>().totalScore.ToString();
	// }

	// Use the PlayerPrefs API to load player score
	void OnEnable()
	{
		scoreText.text = PlayerPrefs.GetInt("score").ToString();
	}

	public void startAgain()
	{
		// Jump to main game scene
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	public void quit()
	{
		Application.Quit();
	}
}
