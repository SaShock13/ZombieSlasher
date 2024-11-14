using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsawAttack : MonoBehaviour
{
    [SerializeField] GameObject bloodFXPrefab;
    private GameObject bloodFx;
    private EnemyHealth enemyHealth;

    private void Start()
    {
        bloodFx = Instantiate<GameObject>(bloodFXPrefab) ;
        bloodFx.SetActive(false) ;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Attack With Saw");
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out enemyHealth))
        {
            bloodFx.transform.position = collision.GetContact(1).point;
            bloodFx.transform.rotation = Quaternion.Euler(collision.GetContact(1).normal);
            bloodFx.SetActive(true);
            StartCoroutine(SawCutting());
        }
    }



    private void OnCollisionExit(Collision collision)
    {
        bloodFx.SetActive(false);
        StopAllCoroutines();
    }


    IEnumerator SawCutting()
    {
        while (true)
        {
            enemyHealth.TakeDamage(50); 
            yield return new WaitForSeconds(1);
        }
    }


}
