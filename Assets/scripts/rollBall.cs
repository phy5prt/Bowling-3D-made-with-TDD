using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollBall : MonoBehaviour {

private Rigidbody myBall;
public AudioSource ballSoundEffect;
public Vector3 launchVelocity; //is this used
public bool inPlay;
public bool ballBeingPositioned;

//may be covered by in play
public bool allowDoubleDrag = true;



private Vector3 startPosition;
private Quaternion startRotation;




	// Use this for initialization
	void Start () {



	myBall = GetComponent<Rigidbody>();
	ballSoundEffect = GetComponent<AudioSource>();
	myBall.useGravity = false;

	startPosition = this.gameObject.transform.position;
	startRotation = this.gameObject.transform.rotation;

	//should deactivate touch screen panel until theyve nudged?




	//Launch(launchVelocity);

	}
	
	// Update is called once per frame
	void Update () {


		
	}
public void Launch(Vector3 velocity){

if (inPlay == false || allowDoubleDrag == true){

	myBall.useGravity = true;
	ballSoundEffect.Play();
	myBall.velocity = velocity;
	inPlay=true;
	}else Debug.Log("ball already in play");
	}


	public void Reset(){


		

		//my code works though seem must be a more encompassing way to catch all these variables

		myBall.velocity = Vector3.zero;
		myBall.angularVelocity = Vector3.zero;
		this.gameObject.transform.position = startPosition;

		//lecture 217 changes this but my code already caught the rotation issue
		//they use transform.rotation = quaternion.identity;
		this.gameObject.transform.rotation = startRotation  ;
		myBall.useGravity = false;

		inPlay=false;
		ballBeingPositioned = true;
	//Debug.Log("reset ball");




	}
}
