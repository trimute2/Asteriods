using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Wraper : MonoBehaviour {

	SpriteRenderer sr;
	Vector3 min;
	Vector3 max;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		min = Camera.main.WorldToScreenPoint (Camera.main.ScreenToWorldPoint (Vector3.zero) - sr.bounds.extents);
		max = Camera.main.WorldToScreenPoint(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, 0))+sr.bounds.extents);
	}

	public Vector3 Wrap(Vector3 position) {
		//Debug.Log (sr.bounds.extents.x);
		Vector3 screenPosition = Camera.main.WorldToScreenPoint(position);
		if (min.x > screenPosition.x) {
			position.x = Camera.main.ScreenToWorldPoint (new Vector3 (max.x, 0, 0)).x;
		} else if (max.x < screenPosition.x) {
			position.x = Camera.main.ScreenToWorldPoint(new Vector3 (min.x,0,0)).x;
		}

		if (min.y > screenPosition.y) {
			position.y = Camera.main.ScreenToWorldPoint (new Vector3 (0, max.y, 0)).y;
		} else if (max.y < screenPosition.y) {
			position.y = Camera.main.ScreenToWorldPoint(new Vector3 (0,min.y,0)).y;
		}
		return position;
	}
}
