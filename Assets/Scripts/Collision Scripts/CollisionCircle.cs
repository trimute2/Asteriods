using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCircle : MonoBehaviour {

	public float radius;

	public float Raduis{
		get{
			return radius;
		}
	}

	public Vector3 Position{
		get{
			return this.transform.position;
		}
	}

	/*void Start(){
		radius *= transform.localScale.
	}*/

	/// <summary>
	/// Test if this collides with another collision circle.
	/// </summary>
	/// <returns><c>true</c>, the two circles collide, <c>false</c> the two circles dont collide.</returns>
	/// <param name="c">the circle to test against.</param>
	public bool TestCollisionCircle(CollisionCircle c){
		Vector3 position = this.transform.position;
		float distance = c.Raduis + radius;
		distance *= distance;
		Vector3 offset = position - c.Position;
		return (offset.sqrMagnitude < distance);
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (this.transform.position, radius);
	}
}
