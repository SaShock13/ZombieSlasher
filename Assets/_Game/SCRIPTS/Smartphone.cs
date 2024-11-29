using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Smartphone : MonoBehaviour
{
    public bool call = false;
    private bool isCalling = false;
    private bool isTalking = false;
    private AudioSource callSound;
    [SerializeField] private AudioClip ringSound;
    [SerializeField] private AudioClip talkSound;
    [SerializeField] private GameObject inCallPanel;
    [SerializeField] private GameObject callPanel;
    /// <summary>
    /// все прописать Все состояния.
    /// </summary>
    private void Start()
    {
        callSound = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (call)
        {            
            Call();
            if(isTalking) AnswerCall();
        }
        else
        {
            inCallPanel.SetActive(false);
            callPanel.SetActive(false);
            if (callSound.isPlaying)
            {
                callSound.Stop();
            }            
        }
    }

    private void Call()
    {
        inCallPanel.SetActive(true);
        if (!callSound.isPlaying)
        {
            callSound.Play();
        }
    }

    public void StartCalling()
    {
        call = true;        
    }

    public void StoptCalling()
    {
        call = false;        
    }

    public void AnswerCall()
    {
        StoptCalling();
        Debug.Log("Answer Call");
        inCallPanel.SetActive(false);
        callPanel.SetActive(true);
        callSound.clip = talkSound;
        //callSound.Play();
    }
}
