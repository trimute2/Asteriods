using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public ShipEngine engine;
	public BulletManager bulletManager;

	void Update () {
		
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		if (horizontal != 0) {
			engine.Turn (horizontal);
		}
		if (vertical != 0) {
			engine.Thrust (vertical);
		}
		if (Input.GetKey (KeyCode.Space)) {
			bulletManager.AddBullet (engine.Position, engine.Heading);
		}
	}
}
