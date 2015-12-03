using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {


    private System.Random rdm = new System.Random();
    public Text scoreText;


    // Use this for initialization
    void Start () {


    }

    // Update is called once per frame
    void Update () {


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Enemy")
            {
                transform.GetComponent<Animator>().Play(string.Format("Attack {0}", rdm.Next((int)1, (int)4)), 0);


                if (hit.transform.gameObject.GetComponent<EnemyTouchBehavior>().health > 10)
                {
                    scoreText.GetComponent<scoreControl>().updateScore(10, "Plus");
                    hit.transform.gameObject.GetComponent<EnemyTouchBehavior>().health -= 10;
                }
                else
                {
                    scoreText.GetComponent<scoreControl>().updateScore((uint)hit.transform.gameObject.GetComponent<EnemyTouchBehavior>().health, "Plus");
                    hit.transform.gameObject.GetComponent<EnemyTouchBehavior>().health = 0;
                    hit.transform.GetComponent<Animator>().SetBool("Die", true);
                }
            }
        }


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Enemy")
            {
                transform.GetComponent<Animator>().Play(string.Format("Attack {0}", rdm.Next((int)1, (int)4)), 0);


                if (hit.transform.gameObject.GetComponent<EnemyTouchBehavior>().health > 10)
                {
                    scoreText.GetComponent<scoreControl>().updateScore(10, "Plus");
                    hit.transform.gameObject.GetComponent<EnemyTouchBehavior>().health -= 10;
                }
                else
                {
                    scoreText.GetComponent<scoreControl>().updateScore((uint)hit.transform.gameObject.GetComponent<EnemyTouchBehavior>().health, "Plus");
                    hit.transform.gameObject.GetComponent<EnemyTouchBehavior>().health = 0;
                    hit.transform.GetComponent<Animator>().SetBool("Die", true);
                }
            }

        }

    }
}
