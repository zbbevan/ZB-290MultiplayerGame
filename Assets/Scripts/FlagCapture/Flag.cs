using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{

    private Collider col;
    public GameObject myHolder;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        col = GetComponent<Collider>();
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            col.enabled = false;
            ChangeHolder(collision.gameObject);
            gameManager.flag = this.gameObject;
            gameManager.StartCoroutine(gameManager.GainPoints());
        }

    }

    public void ChangeHolder(GameObject newParent)
    {
        this.transform.parent = newParent.transform;
        this.transform.position = new Vector3(newParent.transform.position.x, newParent.transform.position.y + 1f, newParent.transform.position.z);
        newParent.GetComponent<FlagHolder>().flagHeld = true;
        myHolder = newParent;

    }

    public void ResetFlag()
    {
        myHolder = null;
        Destroy(this.gameObject);
    }
}
