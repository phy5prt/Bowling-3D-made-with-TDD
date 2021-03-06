using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

	public Text pinDisplayNumber;
	public float settleTime = 3f;

	private GameManager gameManager;
	private bool ballLeftBox = false; 

	private int lastStandingCount = -1;
	private float lastChangeTime;
	private int lastSettledCount = 10;



	void Start () {

		gameManager = GameObject.FindObjectOfType<GameManager>();

	}
	

	void Update () {

		pinDisplayNumber.text = CountStanding().ToString();

	if (ballLeftBox == true){
			pinDisplayNumber.color = Color.red;
			UpdateStandingCountAndSettle();
			}		
	}

	public void Reset(){

		lastSettledCount = 10; //TODO put in the discussion if dont find it is in the code already
	}

	void OnTriggerExit(Collider collider){
		if(collider.gameObject.name == "Ball")             {	ballLeftBox = true;}
		}

	

	void UpdateStandingCountAndSettle(){

		int currentStanding = CountStanding();

		if (currentStanding != lastStandingCount){
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		
		}

	
		if((Time.time - lastChangeTime) > settleTime){
		PinsHaveSettled();}
				
		}


	void PinsHaveSettled(){
		
		int standing = CountStanding();
		int pinFall = lastSettledCount - standing;
		lastSettledCount = standing;
		lastStandingCount = -1; //do we ever measure for -1 yes it stay like this till the ball is returned so dont double count
		ballLeftBox = false;
		pinDisplayNumber.color = Color.green;
		gameManager.Bowl(pinFall);




	}


	int CountStanding(){

	int standing = 0;

		foreach (Pin thisPin in GameObject.FindObjectsOfType<Pin>()){

			if(thisPin.IsStanding()){standing++;}	
																							
		}return standing;
	

	}


	/*
	public ActionMaster.Action CovertStandingCountToPinsKnockedOverAndSendToActionMaster(int currentStanding){
		int totalPinsDown = 10 - currentStanding;
		int pinsKnockedOverThisBowl;


		//i thought it should be bowl -1
		//why would bowl be behind one already

		bool Strike19Bowl20 = (actionMaster.bowl == 20 && actionMaster.bowlPinsDowned[actionMaster.bowl-1] == 10);

			if(actionMaster.bowl % 2 ==0 && !Strike19Bowl20){pinsKnockedOverThisBowl = totalPinsDown - actionMaster.bowlPinsDowned[actionMaster.bowl-1];

			//needs test driven coding for above 19
			//if you strike the first time, you get a second roll at a new set of pins if you strike that and again. this may be caught by just if 20 strike add 10

			Debug.Log("number of bowls = " +  actionMaster.bowl +  " pinsKnockedOverThisBowl 2nd bowl= " + pinsKnockedOverThisBowl + " currentStanding was " + currentStanding);
			return actionMaster.Bowl(pinsKnockedOverThisBowl);
		}else{pinsKnockedOverThisBowl = totalPinsDown;
			Debug.Log("number of bowls = " +  actionMaster.bowl + " pinsKnockedOverThisBowl 1st bowl= " + pinsKnockedOverThisBowl + " currentStanding was " + currentStanding);
		return actionMaster.Bowl(pinsKnockedOverThisBowl);
		}
}*/
}
