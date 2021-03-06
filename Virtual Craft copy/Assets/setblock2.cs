﻿using UnityEngine;
using System.Collections;

public class setblock2 : MonoBehaviour {
	public GameObject pre;
	GameObject clone;
	Transform hand;
	righthand Righthand; 
	ModeManager modemanager;
	public Transform workarea;
	public Color original;
	public Color touching = new Color(0.8f,0.7f,0.5f);
	public float timer;
	public float timelimit = 1.3f;
	private float gridwidth = 0.549f;
	public float a, x, y, z;
	public bool setposition = true;
	public bool timerOn;
	public bool onBoard = false;
	public bool touchIndex = false;
	public bool touchThumb = false;
	public int mode;  //choose mode selecting grid or normal

	// Use this for initialization
	void Start () {
		setposition = true;
		mode = Righthand.mode;
	}
	
	void Awake () {
		hand = GameObject.Find("Sphere").GetComponent<Transform>();
		Righthand = GameObject.Find("Sphere").GetComponent<righthand>();
		workarea = GameObject.Find("Work Area").GetComponent<Transform>();
		modemanager = GameObject.Find("Mode Manager").GetComponent<ModeManager>();
		original = this.renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
		SetPosition (setposition, mode); //If setposition is true, the block moves (hopefully this has mode)
		if (timerOn) {                //If timerOn is true, add seconds to timer
			timer += Time.deltaTime;
		}
		//if (timer > timelimit && !Righthand.hold) {  //If timer is over timelimit, the block moves to adjust
		//	setposition = true;
		//	Initiate();
		//}

		if (touchIndex == true && touchThumb == true && Righthand.hold == false) {
			setposition = true;
		}
		
	}
	
	public void ChangeColor () {  //With touching a block, change the color
		renderer.material.color = touching;
	}
	
	public void OriginalColor () {
		renderer.material.color = original;
	}
	
	/*
    public void SetPosition (bool set) {
        if (set) {
            transform.position = hand.transform.position;
            Righthand.Hold();
        }
    }
    */
	
	
	
	public void SetPosition (bool set, int mode) {
		if (GameObject.Find ("RigidHand1(Clone)") == null && set && !onBoard) {
			setposition =false;
			DestroyItself();
		}
		/*
                        if (!setposition && GameObject.Find("RigidHand1(Clone)") != null) {
                        }else{
                            set = false;
                            DestroyItself ();
                        }
*/
		if (set && mode == 1) {
			//transform.position = hand.transform.position;
			transform.position = modemanager.HandPosition.position;
			Righthand.Hold ();
		}
		if (set && mode == 2) {
			x = hand.transform.position.x - hand.transform.position.x % gridwidth;
			y = hand.transform.position.y - hand.transform.position.y % gridwidth;
			z = hand.transform.position.z - hand.transform.position.z % gridwidth;
			Vector3 trans = new Vector3 (x, y, z);
			transform.position = trans;
			Righthand.Hold ();
		}
	}
	
	
	
	public void Instantiate () {
		clone = Instantiate(pre) as GameObject;
		clone.transform.position = hand.transform.position;
	}
	
	public void Initiate () {
		OriginalColor();
		timer = 0f;
		timerOn = false;
	}
	
	void Release () {
		audio.Play ();
		onBoard = true;
		transform.parent = workarea; 
		Righthand.NotHold ();
		
		
	}
	
	void DestroyItself () {
		Destroy (gameObject);
	}
	
	private void OnTriggerExit(Collider collision)
	{
		
		if (collision.gameObject.tag == "Righthand") {
			touchIndex = false;
			Initiate ();
		}

		if (collision.gameObject.tag == "Thumb") {
			touchThumb = false;
		}

		if (collision.gameObject.tag == "AvailableArea") {  //  If out of the area, it gets destroyed
			//DestroyItself();
		}
	}
	
	private void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "WorkObject" || collision.gameObject.tag == "WorkBoard") {
			setposition = false;
			Release ();
			//Debug.Log("aaa");
		}
		if (collision.gameObject.tag == "Righthand") {
			if(!Righthand.hold){
				ChangeColor();
				timerOn = true;
			}
			
		}
		if (collision.gameObject.tag == "Wholehand" && modemanager.HandMode == 2 ) {
			//this.rigidbody.
			rigidbody.constraints = RigidbodyConstraints.None;
			this.collider.isTrigger = false;
		}

	}

	private void OnTriggerStay(Collider collision)
	{
		if (collision.gameObject.tag == "Righthand") {
			touchIndex = true;
		}
		if (collision.gameObject.tag == "Thumb") {
			touchThumb = true;
		}

	}


}