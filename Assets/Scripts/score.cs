using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
	public Transform camera;
	public Transform cube;
	public Text scoreText;
	public Text levelText;
	public Text levelPointsText;
	public int levelTwoVal, levelThreeVal;

    void Start()
    {
		// Import level point thresholds from paintDroplets script
        levelTwoVal = camera.GetComponent<paintDroplets>().levelTwoVal;
		levelThreeVal = camera.GetComponent<paintDroplets>().levelThreeVal;
    }

    void Update()
    {
		if (cube != null) {
			// Calculate score, level, and points per level
			int score = cube.GetComponent<cubeControl>().totalScore;
			int level = 1;
			if (score >= levelThreeVal) {
				level = 3;
			}
			else if (score >= levelTwoVal) {
				level = 2;
			}
			int levelPoints = 1;
			if (level == 2) {
				levelPoints = 2;
			}
			else if (level == 3) {
				levelPoints = 5;
			}

			// Display score, level, and points per level
			scoreText.text = score.ToString();
			levelText.text = level.ToString();
			levelPointsText.text = levelPoints.ToString();
		}
    }
}
