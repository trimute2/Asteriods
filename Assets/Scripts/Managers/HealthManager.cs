using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour {

	public int lives;

	public float immunityTime;

	public bool immunityOnStart;

	public string restartFrom;

	float immunity;

	bool clear;

	Color opaque;

	Color cClear;

	public bool Immune{
		get{
			return immunity > 0f;
		}
	}

	void Start(){
		if (immunityOnStart) {
			immunity = immunityTime;
		} else {
			immunity = 0f;
		}
		clear = false;
		opaque = this.GetComponent<SpriteRenderer> ().color;
		cClear = opaque;
		cClear.a = 30f / 255f;
	}

	public void Hit(){
		if (!(immunity > 0f)) {
			immunity = immunityTime;
			lives -= 1;
			if (lives == 0) {
				SceneManager.LoadScene (restartFrom);
			}
			this.GetComponent<ShipEngine> ().Reset();
		}
	}

	public void TickImmunityTime(){
		if (immunity > 0f) {
			TickImmunityTime (Time.deltaTime);
		}
	}

	public void TickImmunityTime(float time){
		if (immunity > 0f) {
			immunity -= time;
		}
	}

	void Update(){
		if (immunity > 0) {
			if (clear) {
				this.GetComponent<SpriteRenderer> ().color = opaque;
			} else {
				this.GetComponent<SpriteRenderer> ().color = cClear;
			}
			clear = !clear;
		} else if (clear) {
			this.GetComponent<SpriteRenderer> ().color = opaque;
			clear = false;
		}
	}
}
