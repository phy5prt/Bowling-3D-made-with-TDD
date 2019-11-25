using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//its a monobehaviour but does it need to be
public class ScoreDisplay : MonoBehaviour {

public Text[] rollTexts;
public Text[] frameTexts;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FillRollCard(List<int>rolls){

	string scoresString = FormatRolls(rolls); // is this just for testing so ignore the list we rceive?

	//for(int i = 0; i<rolls.Count;){
	for(int i = 0; i<scoresString.Length;i++){       //like this because testing?

			rollTexts[i].text = scoresString[i].ToString();

	//rollTexts[i].text = rolls[i].ToString();
	 } 

	} 

	public void FillFrames (List<int> frames){

	//if(frames.Count>frameTexts.Length){return;}

		for(int i = 0;i<frames.Count;i++){

				frameTexts[i].text = frames[i].ToString();
	}
	}

	//using to test code in before putting above
	public static string FormatRolls (List<int> rolls){


			
			string output = "";

		for(int i=0; i < rolls.Count; i++){

			//rolls after end game dont upgate board and excede the text[] length 



			
			string strike, rollText;
			bool oddRoll = output.Length%2 == 0;                                                             

																																																		
			if(output.Length >17){strike = "X";}else{strike = " X";}									 				 //10th frame
			if(output.Length == 19 && rolls[i-1] == 10){oddRoll = true;}                                  				 //2nd strike 10th frame
		
				if(oddRoll && rolls[i] == 10){rollText = strike;}                                          				 //normal strike
					else if((!oddRoll || output.Length == 20)  && (rolls[i] + rolls[i-1])==10){rollText = "/";}          //spare & spare last frame
						else if(rolls[i] == 0){rollText = "-";}else{ rollText = rolls[i].ToString();}	   				 //pure roll

		

			 output += rollText;
			if(output.Length == 20 && (     ( rolls[i] + rolls[i-1] ) < 10)   ){Debug.Log("breaking because filled 20 boxes");break;}
			if(output.Length == 21){Debug.Log("breaking because filled 21 boxes"); break;} 

			 }

	return output;}



	public void resetBoard(List<int>rolls){
		
		if(rolls.Count>0){for(int i = 0; i <rolls.Count; i++){rollTexts[i].text = ""; }}
		rolls.Clear();
		if(frameTexts.Length>0){for (int i=0;i <frameTexts.Length; i++){frameTexts[i].text = "";}}
		Color whiteish = new Vector4 (255f/225f,255f/225f,255f/225f,178f/225f);
		GameObject.Find("Scores").GetComponent<CanvasRenderer>().SetColor(whiteish);

		//after calling reset need to 

	}
}
