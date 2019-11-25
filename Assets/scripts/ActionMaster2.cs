using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ActionMaster {
	public enum Action {Tidy, Reset, EndTurn, EndGame, Undefined};
	
	public static Action NextAction (List<int> rolls) {
		Action nextAction = Action.Undefined;

		int j = 0;
		for (int k = 0; k < rolls.Count; k++) { // Step through rolls

		//this fix was messier than i thought next time note down that rolls[k]means this rolls value i means this 
		//adjust roll value rolls{int-j] means adjusting down to find the right point in array
		//introduced number of strikes as j.
		int i = k +j;



			if (i == 20) {
				nextAction = Action.EndGame;
			} else if ( i >= 18 && rolls[k] == 10 ){ // Handle last-frame special cases
				nextAction = Action.Reset;
			} else if ( i == 19 ) {
				//if (rolls[18-j]==10 && rolls[19-j]==0) {
				if (rolls[18-j]==10 && rolls[19-j]==0) {
					nextAction = Action.Tidy;
				} else if (rolls[18-j] + rolls[19-j] == 10) {
					nextAction = Action.Reset;
				} else if (rolls [18-j] + rolls[19-j] >= 10) {  // Roll 21 awarded
					nextAction = Action.Tidy;
				} else {
					nextAction = Action.EndGame;
				}
			} else if (i % 2 == 0) { // First bowl of frame
				if (rolls[k] == 10) {
					//rolls.Insert (i, 0); 
					j++;

					nextAction = Action.EndTurn;
				} else {
					nextAction = Action.Tidy;
				}
			} else { // Second bowl of frame
				nextAction = Action.EndTurn;
			}
		}
		
		return nextAction;
	}
}