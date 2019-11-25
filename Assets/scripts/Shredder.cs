using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//just refractered out of pinsetter script for neatness

	void OnTriggerExit(Collider amIPinColl){

		//this is useful gameObject means your reffering from the component you caught to its gameObject 
	//then to that gameObject transform, its transform identifies the parent and you can grab that gameObject

	//my code worked though showed some error that didnt stop it working which was odd
	//but the course just simplified the pins so i will do that

		//GameObject amIPinGObj = amIPinColl.gameObject.transform.parent.gameObject;

		GameObject amIPinGObj = amIPinColl.gameObject;

	if(amIPinGObj.GetComponent<Pin>()){
			Destroy(amIPinGObj);
	}

	}
}
