using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class FlagHolder : MonoBehaviour
{
    private int pointsToAdd = 1;
    private UI_Manager uI_Manager;
    private int pID;
    private float pointInterval = 1f;
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

    public IEnumerator AddPoints()
    {
        if (flagHeld)
        {
            uI_Manager.AddPoints(pointsToAdd, pID);
            yield return new WaitForSeconds(pointInterval);
            StartCoroutine(AddPoints());
        }
        else
        {
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (flagHeld)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (collision.gameObject.GetComponent<FlagHolder>().flagHeld == false)
                {
                    flagHeld = false;
                    StopCoroutine(AddPoints());
                    collision.gameObject.GetComponent<FlagHolder>().flagHeld = true;
                    collision.gameObject.GetComponent<FlagHolder>().StartCoroutine(collision.gameObject.GetComponent<FlagHolder>().AddPoints());
                    flag.GetComponent<Flag>().ChangeHolder(collision.gameObject);
                }
            }
            if (collision.gameObject.tag == "Enemy")
            {
                if (flagHeld)
                {
                    flagHeld = false;
                    StopCoroutine(AddPoints());
                    flag.GetComponent<Flag>().ResetFlag();
                }

            }
        }
    }

}
