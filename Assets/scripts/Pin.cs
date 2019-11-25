using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold;
	public float disToRaise = 40f;



	void Start () {
			}
	

	void Update () {
		
	}

	public void Raise(){

		if (IsStanding()){
				this.GetComponent<Rigidbody>().useGravity = false;

				//issue is automatically translates relative to local position and as the pins are technically at 90 degrees from when we combined them with their meshes
				//that means a translation in y moves them in x so we specify space world its not defaulting to the wrong coordinate position
				this.transform.Translate(new Vector3( 0f , disToRaise , 0f), Space.World);

				//ive put this in here from the raisepins in pin setter because i think its better here
				this.transform.rotation = Quaternion.Euler(270f,0f,0f);

				//pin.gameObject.transform.position = new Vector3 (pin.gameObject.transform.position.x, pin.gameObject.transform.position.y + distanceToRaise, pin.gameObject.transform.position.z);
	}

	}

	public void Lower(){

	if (IsStanding()){

			//this seems a messy way reconstruction the vector can i just add a unit vector*threshold
				//pin.gameObject.transform.position = new Vector3 (pin.gameObject.transform.position.x, pin.gameObject.transform.position.y + distanceToRaise, pin.gameObject.transform.position.z);

				//adding a fudge incase going through floor ohhh although gravity is off are the getting velocity?
				//ahh issue is this is gameObject transform not world transform and they are in pins so behind the scenes there is a multiplier happening
				//pin.gameObject.transform.Translate(new Vector3( 0f , -distanceToRaise+0.5f , 0f), Space.World );

			//		Debug.Log("pin name = " + pin.transform + "translate from = " + pin.transform.position );
		
				this.transform.Translate(new Vector3( 0f , -disToRaise , 0f), Space.World );
			//		Debug.Log("pin name = " + pin.transform + " add minus distance to raise = " + -distanceToRaise + " translate to = " + pin.transform);
				this.gameObject.GetComponent<Rigidbody>().useGravity = true;
	}

	}

	public bool IsStanding(){

	//altered gravity so only ten times more stops the shake however pins do shake anyway and sometimes little deviation register as a big displacement
	//i believe this is because of the gimlock thing in the quaternium information a remedy using magnitude vectors? wonder how unity intends you to do it
	//as identifying deviation from position must be a nuts and bolts thing.

	//could also make it that they have to be within the lane so dont get random numbers as they fall but later i presume they will be destroyed

	// few solves for this

		//float angle = transform.localEulerAngles.x;
       //angle = (angle > 180) ? angle - 360 : angle;

       //OR
       //delta angle finds the closer angle
		// float tiltInX = Mathf.Abs (Mathf.DeltaAngle (transform.eulerAngles.x, 0)); // Absolute (positive) delta  between transform rotation in degrees and 0.
        // float tiltInZ = Mathf.Abs (Mathf.DeltaAngle (transform.eulerAngles.z, 0));





	//issue as i thought may happen is sometimes it is giving 350 instead of -10

	//float pinAngle;

	//mathf for pos or neg angles however i dont know if 350 will be the same -10 so think will need to use 350 0 threshold>pin angle<threshold
	Vector3 rotationInEuler = this.gameObject.transform.rotation.eulerAngles;

	//course code
	//	float tiltInX =  Mathf.Abs(rotationInEuler.x);
	//float tiltInZ =  Mathf.Abs(rotationInEuler.z);
	//course code is rubbish use this


	//this change of code worked when it was around point zero but i think thats not the issue i think putting the components on the pins has made them shake more,
	//though why you can get elligid over 180 rotations in a delta angle which means a 360 rotation i dont know something isnt right

		float tiltInX = Mathf.Abs( (Mathf.DeltaAngle (270 - transform.eulerAngles.x - 360, 0)));
		//Debug.Log("transform.eulerAngles.x = " + transform.eulerAngles.x + " (Mathf.DeltaAngle (transform.eulerAngles.x, 270 = )" + (Mathf.DeltaAngle (transform.eulerAngles.x, 270)) + " tiltInX = " + tiltInX); // Absolute (positive) delta  between transform rotation in degrees and 0.
         float tiltInZ = Mathf.Abs ((Mathf.DeltaAngle (transform.eulerAngles.z - 360, 0)));
		//	Debug.Log("transform.eulerAngles.Z = " + transform.eulerAngles.z + " (Mathf.DeltaAngle (transform.eulerAngles.Z, 0 = )" + (Mathf.DeltaAngle (transform.eulerAngles.z, 0)) + " tiltInZ =  " + tiltInZ);
	//	Debug.Log((tiltInX) + "tiltInX"  );
	//	Debug.Log((tiltInZ) + "tiltInZ"  );

	//not work because its the x and z threshold could do 4 checks on each dimension but might find if both a small amount out the pin tips
	//multiplying them may work to get a magnitude vector may work hmmmmm

		//if (pinAngle>standingThreshold || pinAngle<(-1*standingThreshold) ){

		//if its minus 10 it will be 10 if it is 350 it will fall over anyway, and my concern of if  its too small angles that will make it small
		//is irrelevant if enough time is given for pins to fall and settle in the horizontal

		//prove the thing with less measurement if finding its true is easier than finiding if false do that

		if(tiltInX < standingThreshold && tiltInZ < standingThreshold){
		return true;}else{return false;}

		}

	}


