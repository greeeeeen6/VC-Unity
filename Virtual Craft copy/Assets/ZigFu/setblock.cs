using UnityEngine;
using System.Collections;

public class setblock : MonoBehaviour {
	public GameObject pre;
	GameObject clone;
	Transform hand;
	bool setposition = true;
	public GameObject workarea;
	// Use this for initialization
	void Start () {
		Instantiate ();
	}

	void Awake () {
		hand = GameObject.Find("RightHandMiddle1").GetComponent<Transform>();
		//workarea = GameObject.Find("workarea").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		//clone.transform.parent = transform; 
		SetPosition (setposition);

	}

	public void SetPosition (bool set) {
		if (set) {
			clone.transform.position = hand.transform.position; 
		}
	}

	public void Instantiate () {
		//private GameObject clone;　　
		
		clone = Instantiate(pre) as GameObject;
		clone.transform.position = hand.transform.position;
	}

	void Release () {
		clone.transform.parent = workarea.transform; 
		clone.transform.rigidbody.isKinematic = true;
	}

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "Button1") {
			setposition = false;
			Release ();
			Debug.Log("aaa");
		}
	}
}
