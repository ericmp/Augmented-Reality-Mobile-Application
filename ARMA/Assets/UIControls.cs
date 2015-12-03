using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System;
using SimpleJSON;

public class UIControls : MonoBehaviour
{

    public string justNumbers = "0";
    private string getScore = "getScore/";
    private string checkUser = "checkUser/";
    private string checkUsers = "checkUsers";
    public User[] users = new User[5];


    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Check if the user has a score currently in the database
    public IEnumerator requestUser(string name)
    {
        string url = "http://ericruby.cloudapp.net/";
        url += checkUser + name;

        WWW www = new WWW(url);
        yield return www;
        if (www.error != null)
            if (!PlayerPrefs.HasKey("Score"))
                PlayerPrefs.SetInt("Score", 0);
            else
                justNumbers = PlayerPrefs.GetInt("Score").ToString();
        else
        {
            justNumbers = new String(www.text.Where(Char.IsDigit).ToArray());

        }
    }

    //Update the players score in the database
    public IEnumerator updateScore(string name, int points)
    {
        string url = "http://ericruby.cloudapp.net/";
        url += getScore + name + "/" + points;

        print(url);

        WWW www = new WWW(url);
        yield return www;
        if (www.error != null || www.text != name)
            if (!PlayerPrefs.HasKey("Score"))
                PlayerPrefs.SetInt("Score", (int)points);

    }

    //Print out all users
    public IEnumerator getAllUsers()
    {
        string url = "http://ericruby.cloudapp.net/";
        url += checkUsers;

        WWW www = new WWW(url);
        yield return www;
        // if (www.error != null)
        //     yield break;
        var text = JSON.Parse(www.text);
        for (int i = 0; i < text.Count; i++)
        {
            users[i] = new User(text[i]["name"], text[i]["score"]);

        }

    }

    public class User {
        public string name, score;
        public User(string a, string b)
        {
            name = a;
            score = b;
        }
    }


}
