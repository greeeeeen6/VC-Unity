using UnityEngine;
using System.Collections;

public class modechange : MonoBehaviour {
	righthand Righthand;

	// Use this for initialization
	void Start () {
	
	}

	void Awake () {
		Righthand = GameObject.Find("Sphere").GetComponent<righthand>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Righthand") {
			Righthand.ModeChange ();
		}
	}
}
