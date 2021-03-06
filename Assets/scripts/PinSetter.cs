using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PinSetter : MonoBehaviour {

//is this a bit naughty instead of calling it game object and getting its component or instead of finding it and getting compenent im calling it a text and feeding the whole
//gameobject does it just know coz i said text to treat it as a text if directly in code i said a gameobject was text it would say no, but maybe unity does getcomponent
//behind the scenes

//if i put a collider on the camera (view construction lines) could i make it only destroy pins just after they leave field of view and activate that it destroys
//only when the camera stops following the ball?
//wouldnt be better but would be an interesting challenge


//since refactor it lifts pins then they disapear on a pin refresh TODO

public GameObject pinSet;
private PinCounter pinCounter;
private Animator animator;

	void Start () {

pinCounter = GameObject.FindObjectOfType<PinCounter>();
animator = GetComponent<Animator>();

	}
	

	void Update () {}
		
	/*
	//GameObject PinsGObj = GameObject.Find("Pins");
	//not working because renew pins dd not delete properly the old pins

	//this code worked and i think if i could of made instantiate replace the existing group called pins it would of been a neater solution and maybe still is
	//as does not end up leaving lots of empty objects called pins
	//Pin[] pins = GameObject.Find("Pins").GetComponentsInChildren<Pin>(); - if i straight up find the pins not the gameObject called pins that contains them
	//foreach(Pin pin in pins)
	//it wont matter that i end up with empty transforms called pins - however any pins not caught by the sweeper might be counted so maybe need code to catch ones that
	//may escape when i renew




	//following instructions but seems messy to be aligning the pins (so that if lifted when at slight angle they are put back down straight) in the raisePins() rather than in pin.Raise
	//also feel the overarching problem of the 90 degree meshes should be resolved instead of fumbling around it

	//yep because it is in the wrong place it stands up downed pins then they are swept so im commenting it out putting it in pin.raise
	//pin.transform.rotation = Quaternion.Euler(270f,0f,0f);

*/
	public void RaisePins(){

		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>())
		{pin.Raise();}	
//		Debug.Log("Raising Pins");
		}




	public void LowerPins(){

		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>())
		{pin.Lower();}
	//	Debug.Log("Lower Pins");
	}


	/*
	//this works but in course tells you to put vector in
		//Instantiate(pinSet);

		//this works in video it doesnt it just falls through the floor, to do with scale using and unity assuming in meters

		// but as the scale is still mental i am going to compensate with the default material as he does
		//as ive done this maybe should put weights and gravity back to multiples when i finish game maybe should make it all scaled to be reaslistic
		//they come out as clones and are not found by the display

		//not sure destroy works as still get called clone


		//both effects prefab so has no pins
		//Destroy(GameObject.Find("Pins"));
		//GameObject oldPins = GameObject.Find("Pins");

		 -- not sure how to do it
				GameObject[] gameObjectsCalledPins = GameObject.Find("Pins");
		for(gameObjectsCalledPins  AmIEmpty){
			if(AmIempty.gameObject.transform.childCount == 0){
			Destroy(AmIEmpty);}
		}

		//oldPins = Instantiate(pinSet, (new Vector3(0f, 0f,1800f)), Quaternion.identity);

		//below code works as discussed in raise it doesnt leave messy empty transforms called pins or risk
		//leaving behind unswept pins
		//it would be nicer if it straight out replaced the existing pins gameobject
		GameObject thisPin = Instantiate(pinSet, (new Vector3(0f, 0f,1800f)), Quaternion.identity);
		thisPin.name = "Pins2";
		Destroy(GameObject.Find("Pins"));
		thisPin.name = "Pins";

		//CountStanding();
		*/
	public void RenewPins(){ //TODO sort this bit out

		GameObject newPins = Instantiate(pinSet);
		//this was 0,40,0 but with the lower instruction put them in the ground i got rid of lower from animator and instantiate on ground
		//could just instantiate the right height above
		newPins.transform.position += new Vector3(0, 0, 0);
	//	Debug.Log("renew pin");
	}


	public void PerformAction(ActionMaster.Action action){


		if(action == ActionMaster.Action.Tidy){
			animator.SetTrigger("tidyTrigger");	

		}else if(action == ActionMaster.Action.EndTurn){

			
			//I didnt have this in before maybe I had done it elsewhere
			pinCounter.Reset();
			animator.SetTrigger("resetTrigger");	
		}else if(action == ActionMaster.Action.Reset){

			//I didnt have this in before maybe I had done it elsewhere
			pinCounter.Reset();
			animator.SetTrigger("resetTrigger");	

		}else if(action == ActionMaster.Action.EndGame){

		// need to disable scorebored but they are just functions so need to just stop them being called and colour the boards
		//Debug.Log("EndGame");
//		rollBall.Reset();
//need invoked this
			Color newColorPinkBlue = new Vector4 (223f/255f,188f/255f,255f/225f,197f/225f);//DFA9FFB2
			GameObject scores = GameObject.Find("Scores");
			scores.GetComponent<CanvasRenderer>().SetColor(newColorPinkBlue);

			RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();
			RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();
			RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();
			RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();RenewPins();
			



			//pinCounter.Reset();
			//animator.SetTrigger("resetTrigger");

			//turn the array pink or green and disable the ball
			//maybe do something funny like instantiate the pins loads so they explode everywhere and put the ball in the middle and swiper on repeat
			//disable code for keeping score


			}

	}
}