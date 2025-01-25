using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoalPotion : MonoBehaviour
{
    public GameObject shipButton;
    public GameObject trashButton;
    public MixingController mixingController;
    public TextMeshProUGUI goalText;
    public TextMeshProUGUI currentText;
    public TextMeshProUGUI CloseToGoal;
    public TextMeshProUGUI fullness;
    public int[] goalRGB = new int[3];
    public float[] currentRGB = new float[3];
    public float[] closeness = new float[3];
    public float totalCloseness = 0;
    
    public List<float> score;
    void updateGoal(int r, int g, int b){
        goalRGB[0]=r;
        goalRGB[1]=g;
        goalRGB[2]=b;
    }
    void trashIt(){
        mixingController.resetPotion();
        // Debug.Log("trashButtonClicked");
    }
    void shipIt(){
        score.Add(totalCloseness);
        mixingController.resetPotion();
        // Debug.Log("ShipitButtonClicked");
    }

    // Start is called before the first frame update
    void Start()
    {
        mixingController = (MixingController) GameObject.FindObjectOfType(typeof(MixingController));
        goalRGB[0]=100;
        goalRGB[1]=100;
        goalRGB[2]=100;
        trashButton.GetComponent<Button>().onClick.AddListener(() => {trashIt(); });
        shipButton.GetComponent<Button>().onClick.AddListener(() => {shipIt(); });
    }

    void UpdateUIText(){
        currentRGB[0]=mixingController.resultColour.r * 255 - (mixingController.resultColour.r * 255)%1.0f;
        currentRGB[1]=mixingController.resultColour.g * 255 - (mixingController.resultColour.g * 255)%1.0f;
        currentRGB[2]=mixingController.resultColour.b * 255 - (mixingController.resultColour.b * 255)%1.0f;

        goalText.text=goalRGB[0].ToString()+","+goalRGB[1].ToString()+","+goalRGB[2].ToString();
        currentText.text=currentRGB[0].ToString()+","+currentRGB[1].ToString()+","+currentRGB[2].ToString();

        closeness[0]=Mathf.Abs(goalRGB[0]-currentRGB[0]);
        closeness[1]=Mathf.Abs(goalRGB[1]-currentRGB[1]);
        closeness[2]=Mathf.Abs(goalRGB[2]-currentRGB[2]);
        totalCloseness = (closeness[0]+closeness[1]+closeness[2])/255;
        CloseToGoal.text=totalCloseness.ToString();
        fullness.text = mixingController.currentCapacity.ToString()+"/"+mixingController.maxCapacity.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        UpdateUIText();


    }
}
