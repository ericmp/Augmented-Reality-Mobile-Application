using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    Transform body;

	// Use this for initialization
	void Start () {
        body = this.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        body.localPosition = new Vector3(body.localPosition.x+.001f, body.localPosition.y, body.localPosition.z);
	}
}
