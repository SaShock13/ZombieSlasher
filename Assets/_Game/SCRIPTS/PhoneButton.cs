using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhoneButton : MonoBehaviour
{
    [SerializeField] private UnityEvent onButtonClick;

    private void OnTriggerEnter(Collider other)
    {
        onButtonClick.Invoke();
    }
}
