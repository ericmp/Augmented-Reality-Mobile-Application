using UnityEngine;
using System.Collections;

public class lookAtCamera : MonoBehaviour {

    GameObject camera;

	// Use this for initialization
	void Start () {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        //transform.LookAt(camera.transform);
        transform.Translate(new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z));
	}
}
