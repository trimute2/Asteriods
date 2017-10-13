using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Wraper))]
public class ShipEngine : MonoBehaviour {

	[Range(0f, 5f)]
	public float rateTurn;

	[Range(0f, 5f)]
	public float maxSpeed;

	[Range(0f, 5f)]
	public float rateAcceleration;

	[Range(0f, 1f)]
	public float rateDeceleration;

	Vector3 heading;
	Vector3 velocity;
	Vector3 acceleration;
	bool decelerate;

	Wraper wraper;

	/// <summary>
	/// Gets the heading.
	/// </summary>
	/// <value>The heading.</value>
	public Quaternion Heading{
		get{
			return Helper.UnitToQuat(heading);
		}
	}

	/// <summary>
	/// Gets the position.
	/// </summary>
	/// <value>The position.</value>
	public Vector3 Position{
		get{
			return this.transform.position;
		}
	}

	void Start () {
		heading = Vector3.right;
		velocity = Vector3.zero;
		acceleration = Vector3.zero;
		wraper = this.GetComponent<Wraper> ();
		decelerate = true;
	}

	/// <summary>
	/// Turn the specified amount.
	/// </summary>
	/// <param name="amount">Amount.</param>
	public void Turn (float amount){
		float rotationAmount = amount * rateTurn;
		Quaternion angle = Quaternion.Euler (0, 0, -rotationAmount);
		heading = angle * heading;
	}

	/// <summary>
	/// Thrust the specified amount.
	/// </summary>
	/// <param name="amount">Amount.</param>
	public void Thrust (float amount){
		acceleration += heading * (amount * rateAcceleration);
		//when accelerating set decelerate to false
		decelerate = false;
	}

	/// <summary>
	/// Move this instance.
	/// </summary>
	void Move() {
		//get the position
		Vector3 position = transform.position;
		//calculate the change in position
		velocity += acceleration;
		velocity = Vector3.ClampMagnitude (velocity, maxSpeed);
		position += velocity;
		//calculate the ships rotation
		Quaternion rotation = Helper.UnitToQuat(heading);
		//wrap the position
		position = wraper.Wrap (position);
		//set the ships position and rotation
		transform.SetPositionAndRotation (position, rotation);

		//check if accelerating before decelerating
		if (decelerate) {
			velocity *= rateDeceleration;
			acceleration *= rateDeceleration;
		} else {
			//if not decelerating, set decelerate to true
			decelerate = true;
		}
	}

	// Update is called once per frame
	void Update () {
		Move ();
	}
}
