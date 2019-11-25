using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

private List<int> rolls = new List<int>();
private PinSetter pinSetter;
private rollBall ball;

	private ScoreDisplay scoreDisplay; 				


	void Start () {

	pinSetter = GameObject.FindObjectOfType<PinSetter>();
	ball = GameObject.FindObjectOfType<rollBall>();

		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();					

		
	}
	

public void Bowl(int pinFall){



		ball.Reset();

		rolls.Add(pinFall);
		pinSetter.PerformAction(ActionMaster.NextAction (rolls));
		//Debug.Log("roll 0 = " + rolls[0] + " roll 1 should exist but = " + rolls[1]);
		//do get strike if move these up but then over written
		//so bowling not knacker score after game finish
		//would prefer endgame to just disable the script but doesnt seem to work maybe because its a static
		//if (ScoreMaster.ScoreFrames(rolls).Count < 11) {}
		scoreDisplay.FillRollCard(rolls);  
		scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));							



		
}
public void GameReset(){
	ball.Reset();
	pinSetter.PerformAction(ActionMaster.Action.Reset);
	scoreDisplay.resetBoard(rolls);



}
}
