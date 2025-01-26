using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class endLogic : MonoBehaviour
{
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "End Score :   " + staticExample.ScoreAvg.ToString();
    }


    public void resetScore()
    {
        staticExample.ScoreAvg = 0;
    }
}
