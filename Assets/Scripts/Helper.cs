using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper  {

	public static Quaternion UnitToQuat(Vector3 unit){
		float angle = Mathf.Atan2 (unit.y, unit.x) * Mathf.Rad2Deg;
		return Quaternion.AngleAxis (angle, Vector3.forward);
	}
}
