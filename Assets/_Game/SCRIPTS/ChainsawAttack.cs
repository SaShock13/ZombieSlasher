using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsawAttack : MonoBehaviour
{
    [SerializeField] GameObject bloodFXPrefab;
    private GameObject bloodFx;
    private void Start()
    {
        bloodFx = Instantiate<GameObject>(bloodFXPrefab) ;
        bloodFx.SetActive(false) ;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Attack With Saw");
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
        {
            bloodFx.transform.position = collision.GetContact(0).point;
            bloodFx.transform.rotation = Quaternion.Euler(collision.GetContact(0).normal);
            bloodFx.SetActive(true);
            collision.GetContact(0);
            enemyHealth.TakeDamage(40);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        bloodFx.SetActive(false);
    }
}
