using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = -1;
    private UI_Manager uI_Manager;
    private int hitPlayerID;
    private void Start()
    {
        uI_Manager = GameObject.Find("UI_Manager").GetComponent<UI_Manager>();
    }
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            Debug.Log("Player hit");
            hitPlayerID = player.gameObject.GetComponent<PlayerController>().playerID;
            uI_Manager.AddPoints(damage, hitPlayerID);
            
        }
        Destroy(this.gameObject);
    }
}
