using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour
{
    Animator animator;
    AudioSource sawSoundSource;

    private void Start()
    {
        sawSoundSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    

    public void OnPickUp()
    {
        animator.SetBool("Working", true);
        sawSoundSource.Play();

    }
    public void OnDetach()
    {
        sawSoundSource.Stop();
        animator.SetBool("Working", false);
    }

}
