using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AliensRemaining : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private void Start()
    { 
      timeText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        
        timeText.text = "Aliens Remaining: " + TransporterLevelGM.instance.aliens;
    }
}