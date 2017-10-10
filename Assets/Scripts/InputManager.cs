using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public ShipEngine engine;
	
	// Update is called once per frame
	void Update () {
		// Input.GetAxis reports based on WS or AD
		// starts at zero, approaches +/- 1 depending on how long pressed
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		//		Debug.Log (horizontal);
		//		Debug.Log (vertical);

		if (horizontal != 0) {
			engine.Turn (horizontal);
		}
		if (vertical != 0) {
			engine.Thrust (vertical);
		}
	}
}
