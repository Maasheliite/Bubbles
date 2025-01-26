using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionUnlock : MonoBehaviour
{
    public GameObject greyPotion;
    public bool greyPotionUnlocked;
    public GameObject whitePotion;
    public bool whitePotionUnlocked;
    public GameObject blackPotion;
    public bool blackPotionUnlocked;
    public GoalPotion GoalPotion;

    void Start()
    {
        greyPotion.SetActive(false);
        whitePotion.SetActive(false);
        blackPotion.SetActive(false);
        GoalPotion = (GoalPotion) GameObject.FindObjectOfType(typeof(GoalPotion));
    }

    // Update is called once per frame
    void Update()
    {
        float lowestPercent=10.0f;
        for(int i=0;i<GoalPotion.score.Count;i++){
            if(GoalPotion.score[i]<lowestPercent){
                lowestPercent=GoalPotion.score[i];
            }
        }
        if(lowestPercent<=0.20f && !greyPotionUnlocked){
            greyPotionUnlocked=true;
            greyPotion.SetActive(true);
        }
        else if(lowestPercent<=0.10f && !whitePotionUnlocked)
        {
            whitePotionUnlocked=true;
            whitePotion.SetActive(true);
        }
        else if(lowestPercent<=0.05f && !blackPotionUnlocked)
        {
            blackPotionUnlocked=true;
            blackPotion.SetActive(true);
        }
    }
}
