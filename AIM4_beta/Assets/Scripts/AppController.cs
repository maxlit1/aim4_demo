using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour {

	public string url;
	public GameObject lastScoreObject;
	public GameObject totalScoreObject;

	private double lastShotScore;
	private double totalScore;
	private int numberOfShots;
	private bool shotDetected;

	// Update is called once per frame
	void Start () {

		// initialize scores
		lastShotScore = 0.0;
		totalScore = 0.0;
		numberOfShots = 0;
		UpdateScore ();

		shotDetected = false;

		// Start coroutine for continuolsy loading images
		StartCoroutine (LoadImage ());
	}

	void Update () {

		if (shotDetected) {
			AddScore ();
			shotDetected = false;
		}
	}

	IEnumerator LoadImage () {
		while (true) {
			yield return new WaitForSeconds(1f); // waits 1 second
			Texture2D tex;
			tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
			WWW www = new WWW(url);
			yield return www; // wait for image to load
			www.LoadImageIntoTexture(tex);
			//GetComponent<Renderer>().material.mainTexture = tex;
		}
	}

	void AddScore () {
		totalScore += lastShotScore;
		numberOfShots++;
		UpdateScore (); 
	}

	void UpdateScore () {
		double averageScore = (numberOfShots == 0) ? 0.0 : totalScore / numberOfShots;
		lastScoreObject.GetComponent<GUIText> ().text = "Last shot: " + lastShotScore;
		totalScoreObject.GetComponent<GUIText> ().text = 
			"Total score: " + totalScore +
			"\nNumber of shots: " + numberOfShots + 
			"\nAverage score: " + averageScore;
	}
}
