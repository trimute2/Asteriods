using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipEngine))]
public class BossScript : MonoBehaviour {

	public GameObject target;
	public BulletManager bulletManager;

	public float avoidRadius;
	public float edgeRadius;

	public int shotsPerVolley;
	public float volleyRate;

	Vector3 min;
	Vector3 max;

	ShipEngine engine;

	int shotVolley;
	float volleyTime;

	// Use this for initialization
	void Start () {
		min = Camera.main.ScreenToWorldPoint (Vector3.zero);
		max = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, 0));
		engine = this.GetComponent<ShipEngine> ();
	}

	/// <summary>
	/// Turn to face either toward or away from the point.
	/// </summary>
	/// <param name="point">the point to face.</param>
	/// <param name="direction">face either toward (-1) or away from (1).</param>
	void FacePoint(Vector3 point, int direction=-1){
		float dp = Vector3.Dot (this.transform.up, point - this.transform.position);
		dp = Mathf.Clamp (dp, -1, 1) * direction;
		engine.Turn (dp);
	}

	/// <summary>
	/// Moves the point.
	/// </summary>
	/// <param name="point">Point.</param>
	/// <param name="direction">move either toward (1) or away from (-1).</param>
	void MovePoint(Vector3 point, int direction=1){
		float dp = Vector3.Dot (this.transform.right, point - this.transform.position);
		dp = Mathf.Clamp (dp, -1, 1) * direction;
		if (volleyTime != 0) {
			dp *= 0.5f;
		}
		engine.Thrust (dp);
	}


	/// <summary>
	/// check if the boss is in the edge and move him out
	/// </summary>
	/// <returns><c>true</c>, moveing out of edge, <c>false</c> otherwise.</returns>
	bool EdgeMove(){
		bool edge = false;
		Vector3 pos = this.transform.position;
		if (pos.x - min.x < edgeRadius) {
			edge = true;
			pos.x = min.x;
		} else if (max.x - pos.x < edgeRadius) {
			edge = true;
			pos.x = max.x;
		}
		if (pos.y - min.y < edgeRadius) {
			edge = true;
			pos.y = min.y;
		} else if (max.y - pos.y < edgeRadius) {
			edge = true;
			pos.y = max.y;
		}
		if (edge) {
			FacePoint (pos, 1);
			MovePoint (pos, -1);
		}
		return edge;
	}

	public void Move(){
		//dont move if recharging
		if (volleyTime == 0) {
			//determine if bullets are in avoid distance
			List<GameObject> bullets = bulletManager.BulletsList;
			float distance = float.MaxValue;
			GameObject closest = null;
			//get closest bullet
			for (int i = bullets.Count - 1; i >= 0; i--) {
				float dist = (this.transform.position - bullets [i].transform.position).sqrMagnitude;
				if (dist < distance) {
					distance = dist;
					closest = bullets [i];
				}
			}
			float disti = (this.transform.position - target.transform.position).sqrMagnitude;
			if (disti < distance) {
				distance = disti;
				closest = target;
			}
			if (distance < avoidRadius * avoidRadius) {
				FacePoint (closest.transform.position, -1);
				MovePoint (closest.transform.position, -1);
				shotVolley = shotsPerVolley;
			} else {
				if (!EdgeMove ()) {
					FacePoint (target.transform.position);
					if (volleyTime == 0 && bulletManager.AddBossBullet (engine.Position, engine.Heading)) {
						shotVolley--;
						if (shotVolley <= 0) {
							volleyTime = volleyRate + Time.deltaTime;
						}
					}
				}
			}
		}
		TickVolleyTime ();
		engine.Move ();
	}

	void TickVolleyTime(){
		if (volleyTime > 0) {
			volleyTime -= Time.deltaTime;
			if (volleyTime < 0) {
				volleyTime = 0;
				shotVolley = shotsPerVolley;
			}
		}
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (this.transform.position, avoidRadius);
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (this.transform.position, edgeRadius);
	}
}
