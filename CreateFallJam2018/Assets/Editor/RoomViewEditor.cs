using UnityEngine;
using System.Collections;
using UnityEditor;

public class RoomViewEditor : Editor {

	void OnSceneGUI() {
		RoomView roomView = (RoomView)target;
		
		Handles.color = Color.white;
		Handles.DrawWireArc (roomView.transform.position, Vector3.up, Vector3.forward, 360, roomView.viewRadius);
		
		Vector3 viewAngleA = roomView.DirFromAngle (-roomView.viewAngle / 2, false);
		Vector3 viewAngleB = roomView.DirFromAngle (roomView.viewAngle / 2, false);

		Handles.DrawLine (roomView.transform.position, roomView.transform.position + viewAngleA * roomView.viewRadius);
		Handles.DrawLine (roomView.transform.position, roomView.transform.position + viewAngleB * roomView.viewRadius);
	}
}
