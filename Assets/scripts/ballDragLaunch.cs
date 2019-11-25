using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(rollBall))]
public class ballDragLaunch : MonoBehaviour {

private float tDragStart, tDragEnd;

private float speedDrag;




private Vector3 placeDragStart, placeDragEnd;
private Vector3 dragVector;

//private Vector3 velocityVector;

private rollBall ball;

	
	// Use this for initialization
	void Start () {
		ball = GetComponent<rollBall>();
		ball.ballBeingPositioned = true;


	}
	
	// Update is called once per frame
	public void DragStart(){

	//course uses (!ball.inplay{} I put it in launch there way i imagine is better as although does it twice stops it calling another script first so reads less code


	//this is to stop the nudge buttons working during ball travel
		ball.ballBeingPositioned = false;
	
	//capture time and position of drag start
	placeDragStart = Input.mousePosition;

	//tDragStart = Time.timeSinceLevelLoad;
		tDragStart = Time.time;

	//distance of drag/time took = speed of drag
	//vector of two position x speed of drag = velocity vector
	//return velocity into 







	}
	public void DragEnd(){

		//course uses (!ball.inplay{} I put it in launch there way i imagine is better as although does it twice stops it calling another script first so reads less code

	//tDragEnd = Time.timeSinceLevelLoad;

	placeDragEnd = Input.mousePosition;
	tDragEnd = Time.time;

	float tDragTook = tDragEnd - tDragStart;

	float launchSpeedX = (placeDragEnd.x - placeDragStart.x)/tDragTook;
	float launchSpeedZ = (placeDragEnd.y - placeDragStart.y)/tDragTook;  

	Vector3 velocityVector = new Vector3(launchSpeedX,0f,launchSpeedZ);



	ball.Launch(velocityVector);
	//doesnt work because obviously longer you wait the bigger the vector also ...
	//dragVector = placeDragEnd - placeDragStart;
	//velocityVector = new Vector3(dragVector.x, dragVector.y,tDragTook);
	//dividing or multiply by same thing important so things in ratio also didnt specify wanted only to throw forward and left or right not up.
		//launth the ball
	}





	public void MoveStart(float xNudge){


	//could be more fancy set it to check the width of lane but its not gonna change


		if(      (40f>=(ball.transform.position.x + xNudge)  ) && ((ball.transform.position.x + xNudge) >= -40f) && (ball.ballBeingPositioned == true)   ){


		/*
		lecture solve was 
		ball.transform.Translate(new Vector3(xNudge,0,0));
		maybe unity changed so can more directly alter vectors as their explination was this enabled you not to construct a new vector
		they had an error with this later in thr course and changed it to

		float xPos = Mathf.Clamp(ball.transform.position.x + amount, -50f, 50f);
		float yPos = ball.transform.position.y;
		float zPos = ball.transform.position.z;
		ball.transform.position = new Vector3 (xPos,yPos,zPos);
		*/


		ball.transform.position += xNudge*Vector3.right;
		Debug.Log("nudged");
		}else{Debug.Log("not nudged and ballBeingPositioned equals " + ball.ballBeingPositioned);

			

		}

	}
}
