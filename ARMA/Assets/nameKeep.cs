using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class nameKeep : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("Name"))
        gameObject.GetComponent<InputField>().text = PlayerPrefs.GetString("Name");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
