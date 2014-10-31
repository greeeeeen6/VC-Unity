using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]

public class Video : MonoBehaviour {

	public MovieTexture movie;

	// Use this for initialization
	void Start () {
		renderer.material.mainTexture = movie as MovieTexture;
		movie.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
