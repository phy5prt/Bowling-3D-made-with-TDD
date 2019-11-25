

/* if feel the camera should swoop in closing the gap with the ball as it is about to hit the pins before it gets to its stopping position, i also think maybe if it gets closer
and maybe pans wider as it travels the lane (like hitchock does) but inverse it might feel faster and less on rails - its the feeling i think is missing not the mechanics
as messing around with the ball speeding up, short of angling the floor seems to take agency from player as even if there was a speeding based on your throw entirely
it would feel like a disconnect from the player because there is an expectation of how the ball should go because it is a boring bowling game*/







using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {

public rollBall ball;
private Vector3 offset;

	// Use this for initialization
	void Start () {

/* //	Vector3 ballStartVector = new Vector3(Ball.transform.position.x, Ball.transform.position.y, Ball.transform.position.z );
	//	Vector3 cameraStartVector = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z );
	//offset = ballStartVector - cameraStartVector;

	//GameObject ball = GameObject.Find("Ball");
	//ball = ball.GetComponent<Transform>();


//	ball = GetComponent<Ball>();


*/

		offset =  this.transform.position -ball.transform.position ;

		
	}
	
	// Update is called once per frame
	void Update () {

	//i wanted to base it off ball position

		//if ( 60f > ball.transform.position.x && ball.transform.position.x  < -60f && 50f > ball.transform.position.y && ball.transform.position.y < 10f && 1800f > ball.transform.position.z && ball.transform.position.z < 0f){

		if(ball.transform.position.z <= 1700f && ball.transform.position.z >= -10f && ball.transform.position.y >= 5f && ball.transform.position.y <= 100f && ball.transform.position.x <= 70f && ball.transform.position.x >= -70f){

		//infornt head pin

		this.transform.position =ball.transform.position + offset; 
		}

		
	}
}
//}