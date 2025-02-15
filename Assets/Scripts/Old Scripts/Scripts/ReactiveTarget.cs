using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{

    [SerializeField] private float deathTimer = 1.5f;
    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            behavior.isAlive = false;
        }
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(deathTimer);

        Destroy(this.gameObject);
    }

}
