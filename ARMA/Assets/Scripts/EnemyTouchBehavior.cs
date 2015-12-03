using UnityEngine;
using System;

public class EnemyTouchBehavior : MonoBehaviour
{

    private System.Random rdm = new System.Random();
    public int health;


    // Use this for initialization
    void Start()
    {
        //Initialize health
        health = rdm.Next(25, 200);
    }

    // Update is called once per frame
    void Update()
    {
        


       
    }
}
