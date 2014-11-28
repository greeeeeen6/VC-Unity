using UnityEngine;
using System.Collections;

public class righthand : MonoBehaviour {
	public GameObject pre1;
	public GameObject pre2;
	public bool hold;
	public float timer;
	public float timelimit;
	public int mode;
	public bool timerOn;
	Transform handrotation;
	ModeManager modemanager;
	GameObject clone;
	// Use this for initialization
	void Start () {
		hold = false;
		timer = 0f;
		timerOn = false;
		mode = 1;
	}

	void Awake () {
		handrotation = GameObject.Find ("palm").GetComponent<Transform> ();
		modemanager = GameObject.Find("Mode Manager").GetComponent<ModeManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (timerOn == true) {
			timer = timer + Time.deltaTime;
		}
		HandMode();
		modemanager.HandPosition = this.transform;
	}

	void HandMode () {
		if (handrotation.localRotation.z < -0.55 && handrotation.localRotation.z > -0.75) {
			modemanager.HandMode = 2;
		} else {
			modemanager.HandMode = 0;
		}
	}


	public void ModeChange () {
		if (mode == 1) {
			mode = 2;
		} else {
			mode = 1;
		}
		Debug.Log ("aaeee");
	}

	public void Hold () {
		hold = true;
	}

	public void NotHold () {
		hold = false;
	}

	void Initiate () {
		timer = 0f;
		timerOn = false;
	}

	private void OnTriggerEnter(Collider collision)
	{
		if (hold != true) {
						if (collision.gameObject.tag == "Button1") {
								clone = Instantiate (pre1) as GameObject;
								Hold ();
								//clone.transform.parent = transform; 
								//clone.transform.position = transform.position;
								//Debug.Log ("aaa");
						}
						if (collision.gameObject.tag == "Button2") {
								clone = Instantiate (pre2) as GameObject;
								Hold ();
								//clone.transform.parent = transform; 
								//clone.transform.position = transform.position;
								//Debug.Log ("aaa");
						}


		}
	}

	private void OnTriggerStay(Collider collision)
	{
		bool set;
		if (collision.gameObject.tag == "WorkObject") {
			set = clone.GetComponent<setblock2>().setposition;
			//Hold ();
			//clone.transform.parent = transform; 
			//clone.transform.position = transform.position;
			//Debug.Log("aaa");
		}

	}
}
