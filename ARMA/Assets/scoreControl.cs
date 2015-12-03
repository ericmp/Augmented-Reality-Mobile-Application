using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreControl : MonoBehaviour {

    public uint score = 0;

    // Use this for initialization
    void Start () {

        if (!uint.TryParse(GameObject.FindGameObjectWithTag("Persist").GetComponent<UIControls>().justNumbers, out score))
            score = (uint)PlayerPrefs.GetInt("Score", 0);
        else
            score = uint.Parse(GameObject.FindGameObjectWithTag("Persist").GetComponent<UIControls>().justNumbers);

        this.GetComponent<Text>().text = "Score: " + score.ToString();


    }
	
	// Update is called once per frame
	void Update () {


    }

    public void updateScore(uint ammount, string op)
    {
        switch (op)
        {
            case "Plus": score += ammount;
                break;
            case "Minus": score -= ammount;
                    break;
            default: break;
        }

        this.GetComponent<Text>().text = "Score: " + score.ToString();

    }
}
