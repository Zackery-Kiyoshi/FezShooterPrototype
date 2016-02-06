using UnityEngine;
using System.Collections;

public class FezCameraScript : MonoBehaviour {

	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Front(){
		gameObject.transform.position = new Vector3 (0, 1, -10);
		gameObject.transform.rotation = Quaternion.Euler (0, 0, 0);
	}

	public void Left(){
		gameObject.transform.position = new Vector3 (-10, 1, 0);
		gameObject.transform.rotation = Quaternion.Euler (0, 90, 0);
	}

	public void Right(){
		gameObject.transform.position = new Vector3 (10, 1, 0);
		gameObject.transform.rotation = Quaternion.Euler (0, -90, 0);
	}

	public void Back(){
		gameObject.transform.position = new Vector3 (0, 1, 10);
		gameObject.transform.rotation = Quaternion.Euler (0, 180, 0);
	}
}
