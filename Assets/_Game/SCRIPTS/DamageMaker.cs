using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ������ �������������, ��� ������ ��������, ���������� ������� ���� ������. ��������� ��������� ����������, 
/// � ��������������� ���� ����������� ���� � �����!
/// </summary>
public class DamageMaker : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float damageMuliplyer = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
        {
            
            float damage = rb.velocity.magnitude * damageMuliplyer;
            print($"��������� RB ��������� : {rb.velocity.magnitude}");
            print($"���� ����� �������� : {damage}");
            enemyHealth.TakeDamage((int)damage);
        }
    }
}
