using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ButtonBehavior : MonoBehaviour
{

    private GameObject input;
    private GameObject warning;
    private InputField name;
    private static string nameString;


    // Use this for initialization
    void Start()
    {
        warning = GameObject.FindGameObjectWithTag("Warning");

        if (gameObject.tag != "Exit" && gameObject.tag != "ExitScores")
        {
            name = GameObject.FindGameObjectWithTag("Name").GetComponent<InputField>();

            if (PlayerPrefs.HasKey("Name"))
                nameString = PlayerPrefs.GetString("Name");

            if (string.IsNullOrEmpty(name.text) && !string.IsNullOrEmpty(nameString))
                name.text = nameString;
        }


    }

    // Update is called once per frame
    void Update()
    {
    }

    public void onClick()
    {

        switch (gameObject.tag)
        {
            case "Play":
                foreach (char letter in name.text)
                {
                    if (!char.IsLetter(letter) && letter != ' ')
                    {
                        warning.GetComponent<Text>().text = "Please Enter Your Name";
                        return;
                    }
                }
                if (!PlayerPrefs.HasKey("Name"))
                    PlayerPrefs.SetString("Name", name.text);

                if (name.text == "" && nameString != "")
                    name.text = nameString;

                nameString = name.text;


                warning.GetComponent<Text>().text = "";
                StartCoroutine(GameObject.FindGameObjectWithTag("Persist").gameObject.GetComponent<UIControls>().requestUser(name.text));
                StartCoroutine(Timer("Play"));
                break;
            case "High Scores":
                StartCoroutine(GameObject.FindGameObjectWithTag("Persist").gameObject.GetComponent<UIControls>().getAllUsers());
                StartCoroutine(Timer("HighScores"));
                break;
            case "Exit":
                StartCoroutine(GameObject.FindGameObjectWithTag("Persist").gameObject.GetComponent<UIControls>().updateScore(nameString, (int)GameObject.FindGameObjectWithTag("Score").gameObject.GetComponent<scoreControl>().score));
                StartCoroutine(Timer("MainMenu"));
                break;
            case "ExitScores":
                StartCoroutine(Timer("MainMenu"));
                break;
            default: break;

        }
    }
    
    void OnApplicationFocus(bool pauseStatus)
    {
        if (!pauseStatus)
        {
            StartCoroutine(GameObject.FindGameObjectWithTag("Persist").gameObject.GetComponent<UIControls>().updateScore(nameString, (int)GameObject.FindGameObjectWithTag("Score").gameObject.GetComponent<scoreControl>().score));
        }
    }
    


    IEnumerator Timer(string level)
    {
        yield return new WaitForSeconds(2);
        Application.LoadLevel(level);

    }

}
