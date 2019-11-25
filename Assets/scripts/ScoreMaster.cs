using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public static class ScoreMaster  {






public static List<int> ScoreCumulative (List<int> rolls){
	List<int> cumulativeScores = new List<int>();
	int runningTotal = 0;

	foreach (int frameScore in ScoreFrames (rolls)){
	runningTotal += frameScore;
	cumulativeScores.Add (runningTotal);


	}
	return cumulativeScores;
	}





public static List<int> ScoreFrames (List<int> rolls){


List<int> frames = new List<int> ();


		for (int i = 1; i < rolls.Count; i += 2) {
			if (frames.Count == 10) {break;}				// Prevents 11th frame score

			if (rolls[i-1] + rolls[i] < 10) {				// Normal "open" frame
				frames.Add (rolls [i-1] + rolls [i]);
			}
 			if (rolls.Count - i <= 1) {break;}				// Insufficient look-ahead
 			if (rolls[i-1] == 10) {							// STRIKE
				i--;										// Strike frame has just one bowl
				frames.Add (10 + rolls [i+1] + rolls[i+2]);
			} else if (rolls[i-1] + rolls[i] == 10) {		// Calculate SPARE bonus
				frames.Add (10 + rolls [i+1]);
			}
		}
 		return frames;


}

}

















/*

// i tried altering the indicies and then the names so it read better forinstance so it read for rolls after the rolls in previous frames but it was so through out i couldnt
//get it to work when i tried it, just removing some negatives was very difficult so it is important to name well and early on.
//hmm actionmaster bowl[] may do same job as my rolledInFrameList maybe should of used it in some way may have been neater
//base class so remove monobehaviour we wont be inheriting from it - maybe look up what this means at some point

//find out if when i create list if i say its length i can just give it values per index as i please as at moment i cant

// would be nice if code doesnt recalculate scores constantly but only frame needing update when triggered


//when coding this i had really thought about how to do it and minimum things that needed track so it would work neatly and felt using every dimension
//e.g. list lengths and choosing what to record like position in the list of list rolls is its frame would help
//i solve the problem in a few hours rather than the 40 the course said it might take and the guy took 2 days
//but because had in my head a good idea where wanted solution to go maybe was too far from pure tdd 
//maybe should have went further ahead with simplistic answers only resorting to more complex more general when absolutely had to
// this way may of found didnt need a system relying on number of rolls per frame
//in future i should have a comment space to keep ideas there for later, though it did work well for me just no way knowing it would of been longer but would i have found 
//as neat a solutions as the teacher
//i should definately when multiple tests break and i want to keep code comment out all but the earliest breaking test and start building protections up
//then red green refactor repeat my way back up to where i was one test at a time as though i did it i did feel i could of missed things if i didnt concider something
//while trying to be methodoological


//my code checks that the frame is finished and has to keep it open until it is
		//I think his goes to the second bowl so inheritantly knows its closed because must be a bowl before and then calculates it by looking forward
		//and back so many spaces from its point
		//if strike or spare instead of changing a variable for the look forward look back point he just feed it the interget
		//mine finds it place in the frame, his doesnt need to know it is just going to add to a list unlike an array he doesnt have to say where to add it so it just
		//need to calculate the score and add on the end
		//the strike and spare conditions simply catch before the normal

//two tricks i missed
//decrementing i for strike to get the right sweep - also by decrementing the loops i he can adjust for less rolls -- everysweep it makes a frame 
//or breaks out of loop efficient!, where as mine looks through the code doesnt do anything then moves on to the next -- 

//he used no extra variables
//but does jump through the list 2 at time not one this is a crux too

//maybe i was coding what the code needed to know understand to do its task but it is mindless it doesnt need to know its place in the list if just adding to it
//it doesnt need to know how many frames or that there are frame as long as it gets stopped before adds too many times so if there is enough information in rolls
//why give it more understanding than it needs, it just needs mindless instructions, i need to understand the problem at its simplest but then i need to instruct
//not explain not put the code as a abstraction of the real it only needs to produce the outcome and be readable to a human so they can alter it and understand what it does
//easily

//teacher code
/*
for (int i = 1; i < rolls.Count; i += 2) {
			if (frames.Count == 10) {break;}				// Prevents 11th frame score

			if (rolls[i-1] + rolls[i] < 10) {				// Normal "open" frame
				frames.Add (rolls [i-1] + rolls [i]);
			}
 			if (rolls.Count - i <= 1) {break;}				// Insufficient look-ahead
 			if (rolls[i-1] == 10) {							// STRIKE
				i--;										// Strike frame has just one bowl
				frames.Add (10 + rolls [i+1] + rolls[i+2]);
			} else if (rolls[i-1] + rolls[i] == 10) {		// Calculate SPARE bonus
				frames.Add (10 + rolls [i+1]);
			}
		}
 		return frames;

*/
/*
public static class ScoreMaster  {


//need some code that says if run out of information in list then return rather than erroring
// the cumulative score frames which will become the display




public static List<int> ScoreCumulative (List<int> rolls){
	List<int> cumulativeScores = new List<int>();
	int runningTotal = 0;

	foreach (int frameScore in ScoreFrames (rolls)){
	runningTotal += frameScore;
	cumulativeScores.Add (runningTotal);


	}
	return cumulativeScores;
	}




//I believe this is individual scoreframes
public static List<int> ScoreFrames (List<int> rolls){


List<int> frameList = new List<int> ();

//will we need number rolls in there in end i dont know - may not need list
//may be better as an int array as know there will be 10 frames

List<int> rolledInFrameList = new List<int>();


//maybe if i added one to frame number and then started changing all the < > it would read better as seems in place some variables should read ==s


//its also the index of rolledInFrameList
// if(strike or spare){ incValueExtraRollForSpareOrStrike = 1};
//probably better as different for loops
//need to put in max i as length of the list
// need to check length of the list of rolls is not less thant rollsAfterNotContributingToThisFrameScore
// if it is then it needs to return the frame list at this point as it is built
//it runs once frame starts not when it ends maybe thats fine with a return if get to point no more rolls left

		//frame number and number of rolls in a frame
		bool lastBowlOfGame = false;
		int numberOfStrikes = 0;
		int frameNumber = 0;



		for (int i = 0; i< rolls.Count; i++){                                                                //count one more than index because index starts 0

		int incExtraRollForSpareOrStrike = 0;
		bool moreRollsLeftInFrame;

		moreRollsLeftInFrame =  ((i + numberOfStrikes) % 2 == 0);
		//have we just started a new frame
	
		if(frameNumber<9){frameNumber = (i + numberOfStrikes)/2;}

			//have we just ended the frame on a spare
			if(!moreRollsLeftInFrame && ((rolls[i] + rolls[i-1]) == 10)){incExtraRollForSpareOrStrike = 1;}

			//Strike
			if(moreRollsLeftInFrame){
					

				if(rolls[i] == 10)                
						 	{rolledInFrameList.Add(1);

							incExtraRollForSpareOrStrike = 1;
							numberOfStrikes ++;		
							moreRollsLeftInFrame = false;
						 } else {rolledInFrameList.Add(2);}}


			int rollsBeforeFrame = 0;

			for (int r = 0; r < frameNumber; r++){rollsBeforeFrame += rolledInFrameList[r];} 																					



																																			//frame10 exceptions

		//Strike overide moving to next frame
			if(frameNumber == 9 && (i == rollsBeforeFrame) && (rolls[i] ==10)){moreRollsLeftInFrame = true;}

		//if strike or spare overide closing the frame
			if(frameNumber == 9 && (i == rollsBeforeFrame + 1)){if((rolls[i] + rolls[i-1])>=10){moreRollsLeftInFrame = true;}else{moreRollsLeftInFrame = false;}}

		//if last roll calc this frame dont wait for next
			if(frameNumber == 9 && (i == rollsBeforeFrame + 2)){moreRollsLeftInFrame = false; incExtraRollForSpareOrStrike=1; lastBowlOfGame = true;  } //TODO make this sensible


			int lastScoreContributingRoll = rollsBeforeFrame + 1 + incExtraRollForSpareOrStrike; 
			int thisFrameScore = 0;


			if((!moreRollsLeftInFrame && ( rolls.Count > lastScoreContributingRoll ))|| lastBowlOfGame){	

						//calculate index's of rolls for frame calculating
						for (int j = rollsBeforeFrame;  j<= lastScoreContributingRoll; j++){thisFrameScore += rolls[j];} 
						frameList.Add(thisFrameScore);
			}
}
	return frameList;


}

}
*/
