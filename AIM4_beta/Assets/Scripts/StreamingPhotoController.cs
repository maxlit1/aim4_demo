using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamingPhotoController : MonoBehaviour {

	public string url = "http://10.106.6.58:8080/photo.jpg";

	// Update is called once per frame
	void Start () {
		StartCoroutine (LoadImage ());
	}

	void Update () {
		//StartCoroutine( LoadImage() );
		print ("asd");
	}

	IEnumerator LoadImage () {
		while (true) {
			yield return new WaitForSeconds(1f); // waits 1 second
			Texture2D tex;
			tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
			WWW www = new WWW(url);
			yield return www;
			www.LoadImageIntoTexture(tex);
			GetComponent<Renderer>().material.mainTexture = tex;
		}
	}

}
