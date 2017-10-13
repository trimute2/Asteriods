using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper  {

	public static Quaternion UnitToQuat(Vector3 unit){
		float angle = Mathf.Atan2 (unit.y, unit.x) * Mathf.Rad2Deg;
		return Quaternion.AngleAxis (angle, Vector3.forward);
	}

	//taken from http://answers.unity3d.com/questions/823090/equivalent-of-degree-to-vector2-in-unity.html
	public static Vector3 RadianToVector3(float radian)
	{
		return new Vector3(Mathf.Cos(radian), Mathf.Sin(radian));
	}

	//taken from http://answers.unity3d.com/questions/823090/equivalent-of-degree-to-vector2-in-unity.html
	public static Vector3 DegreeToVector3(float degree)
	{
		return RadianToVector3(degree * Mathf.Deg2Rad);
	}
}
