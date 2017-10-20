using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
		
	}

	void Move(){
		float dp = Vector3.Dot (this.transform.up, target.transform.position - this.transform.position);
		dp = Mathf.Clamp (dp, -1, 1) *-1;
		//Debug.Log (dp);
		this.GetComponent<ShipEngine> ().Turn (dp);
	}

	// Update is called once per frame
	void Update () {
		Move ();
		this.GetComponent<ShipEngine> ().Move ();
	}
}
