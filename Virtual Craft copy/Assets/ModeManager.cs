using UnityEngine;
using System.Collections;

public class ModeManager : MonoBehaviour {
	public int HandMode;
	public int GridMode;
	public Transform HandPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (HandPosition == null) {
			HandPosition = this.transform;
		}
	
	}
}
