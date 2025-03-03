using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{

    private Collider col;
  
    void Start()
    {
        col = GetComponent<Collider>();
    }


        void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ChangeHolder(collision.gameObject);
        }

    }

    public void ChangeHolder(GameObject newParent)
    {
        this.transform.parent = newParent.transform;
        this.transform.position = new Vector3(newParent.transform.position.x, newParent.transform.position.y + 1f, newParent.transform.position.z);
        newParent.GetComponent<FlagHolder>().StartCoroutine(newParent.GetComponent<FlagHolder>().AddPoints());
        col.enabled = false;
        newParent.GetComponent<FlagHolder>().flagHeld = true;
    }

    public void ResetFlag()
    {
        Destroy(this.gameObject);
    }
}
