using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class PlayerHealth : MonoBehaviour
{
    private float health = 100;
    private bool isAlive = true;
    public UnityEvent<float> onHealthChanged;
    private Volume _volume;
    private Bloom _bloom;
    private void Awake()
    {
        _volume = FindObjectOfType<Volume>();
        _volume.profile.TryGet(out _bloom);
    }

    public void TakeDamage(float damage)
    {
        if (isAlive)
        {
            if (damage > 0)
            {
                health -= damage;
                onHealthChanged.Invoke(health);
                print(health);
                StartCoroutine(Damage());
                if (health <= 0)
                {
                    Death();
                }
            }
        }
    }

    private void Death()
    {
        print("PLayer is dead!!");
        isAlive = false;
    }

    private IEnumerator Damage()
    {
        _bloom.active = true;
        yield return new WaitForSeconds(0.5f);
        _bloom.active = false;

    }
}
