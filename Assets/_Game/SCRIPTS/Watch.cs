using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Watch : MonoBehaviour
{
    [SerializeField] TMP_Text livesText;


    /// <summary>
    /// Есть сомнения ,что скрипт префаба руки привяжется к событию 
    /// </summary>
    
    public void UpdateLives(float helth)
    {
        livesText.text = ((int)helth).ToString();
    }
}
