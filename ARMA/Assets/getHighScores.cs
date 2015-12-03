using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class getHighScores : MonoBehaviour {

	// Use this for initialization
	void Start () {

        var persist = GameObject.FindGameObjectWithTag("Persist").gameObject.GetComponent<UIControls>().users;

        for (int i = 0; i < persist.Length; i++)
        {
            gameObject.GetComponent<Text>().text += persist[i].name + ": " + persist[i].score + "\n";
        }


    }

    // Update is called once per frame
    void Update () {
	
	}
}
