using UnityEngine;
using System.Collections;


public class practiceServer : MonoBehaviour {


    public string url = "http://ericruby.cloudapp.net/checkUser/Tom#";

    // Use this for initialization
    IEnumerator Start()
    {
        WWW www = new WWW(url);
        yield return www;
        print(www.text.ToString());

}
	
	// Update is called once per frame
	void Update () {
	
	}
}
