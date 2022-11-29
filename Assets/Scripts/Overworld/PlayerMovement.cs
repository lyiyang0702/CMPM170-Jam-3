using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Script for the player input in the overworld.
//Basic Velocity calculations depending on the input.
public class PlayerMovement : MonoBehaviour {
	
	//Get the value we set for the player speed in the overworld map.
	[SerializeField]
	private float speed;

    //Get the value for the animator. 
    [SerializeField]
    private Animator animator;



    //FixedUpdate gets the 
    void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 currentVelocity = gameObject.GetComponent<Rigidbody2D> ().velocity;
		//newVeloctiyX determines whether the player has an input to the left or right.
		//(More Specifically the speed of the player to see if the player is moving + (right) or - (left)
		float newVelocityX = 0f;
		//If the player is moving left (Example: Key A is Pressed)
		//Set Animation and speed to the left.
		if (moveHorizontal < 0 && currentVelocity.x <= 0) {
			newVelocityX = -speed;
			animator.SetInteger ("DirectionX", -1);
		//If the player is moving right (Example: Key D is Pressed)
		//Set Animation and speed to the right.
		} else if (moveHorizontal > 0 && currentVelocity.x >= 0) {
			newVelocityX = speed;
			animator.SetInteger ("DirectionX", 1);
		//Else the player doesn't move in the X axis.	
		} else {
			animator.SetInteger ("DirectionX", 0);
		}

		//newVeloctiyY determines whether the player has an input to the up or down.
		//(More Specifically the speed of the player to see if the player is moving + (up) or - (down)
		float newVelocityY = 0f;
		//If the player is moving up (Example: Key W is Pressed)
		//Set Animation and speed to up.
		if (moveVertical < 0 && currentVelocity.y <= 0) {
			newVelocityY = -speed;
			animator.SetInteger ("DirectionY", -1);
		//If the player is moving down (Example: Key S is Pressed)
		//Set Animation and speed to down.
		} else if (moveVertical > 0 && currentVelocity.y >= 0) {
			newVelocityY = speed;
			animator.SetInteger ("DirectionY", 1);
		//Else the player doesn't move in the Y axis. 
		} else {
			animator.SetInteger ("DirectionY", 0);
		}

		//Update the velocity of the Player Object in the overworld to navigate 
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (newVelocityX, newVelocityY);


	}

}
