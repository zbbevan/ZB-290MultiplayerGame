using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class FlagHolder : MonoBehaviour
{
    private UI_Manager uI_Manager;
    private int pID;
    private int pointsLost = -2;
    public bool flagHeld;

    private FlagSpawner flagSpawner;

    public GameObject flag;
    void Start()
    {
        pID = GetComponent<PlayerController>().playerID;
        uI_Manager = GameObject.Find("UI_Manager").GetComponent<UI_Manager>();
        flagSpawner = GameObject.Find("GameManager").GetComponent<FlagSpawner>();
        flag = flagSpawner.flag;
    }

    void Update()
    {
        if (flag == null)
        {
            flag = flagSpawner.flag;
        }


    }

    public IEnumerator TradeFlag(GameObject newHolder)
    {
        yield return new WaitForSeconds(0.1f);
        if(flagHeld)
        {
        flag.GetComponent<Flag>().ChangeHolder(newHolder);
        flagHeld = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Flag")
        {
            flagHeld = true;
            flag = collision.gameObject;
            flag.GetComponent<Flag>().ChangeHolder(this.gameObject);
        }
        if (flagHeld)
        {
             if (collision.gameObject.tag == "Player")
            {
                Debug.Log(collision.gameObject.GetComponent<PlayerController>().playerID);
                if (collision.gameObject.GetComponent<FlagHolder>().flagHeld == false)
                {
                    StartCoroutine(TradeFlag(collision.gameObject));
                }
            }
            if (collision.gameObject.tag == "Enemy")
            {
                if (flagHeld)
                {
                    flagHeld = false;
                    uI_Manager.AddPoints(pointsLost, pID);
                    flag.GetComponent<Flag>().ResetFlag();
                }
                if(!flagHeld)
                {
                    uI_Manager.AddPoints(pointsLost, pID);
                }

            }
        }
    }


}
