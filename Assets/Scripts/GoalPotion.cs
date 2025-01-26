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

    private SceneLoader sceneLoader;
    public GameObject goals;

    public int[] goalRGB = new int[3] { 100,100,100};
    public float[] currentRGB = new float[3];
    public float[] closeness = new float[3];
    public float totalCloseness = 0;

    public GameObject clientObject;
    private GameObject clientInstance;
    public int clientsToday = 10;
    private bool activeClient;
    int tempNr;


    public List<float> score;
    public void updateGoal(int r, int g, int b){
        goalRGB[0]=r;
        goalRGB[1]=g;
        goalRGB[2]=b;
    }
    void trashIt(){
        if (mixingController.currentCapacity > 0)
        {
            mixingController.resetPotion();
        }
        // Debug.Log("trashButtonClicked");
    }
    void shipIt(){
        if(mixingController.currentCapacity > 0)
        {
            score.Add(totalCloseness);
            mixingController.resetPotion();
            MakeClientLeave();
        }
        
        // Debug.Log("ShipitButtonClicked");
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
        mixingController = (MixingController) GameObject.FindObjectOfType(typeof(MixingController));
        trashButton.GetComponent<Button>().onClick.AddListener(() => {trashIt(); });
        shipButton.GetComponent<Button>().onClick.AddListener(() => {shipIt(); });
        TurnOffGoals();
    }

    private void CreateClient()
    {
        clientsToday--;
        clientInstance = Instantiate(clientObject);
    }

    private void MakeClientLeave()
    {
        
        Client client = clientInstance.GetComponent<Client>();
        client.LeaveScene();
        
        Invoke("ResetClientStatus", 3f);
    }
    private void ResetClientStatus()
    {
        if (clientsToday <= 0)
        {
            sceneLoader.LoadEnd();
        }
        else
        {
            activeClient = false;
        }
    }

    public void TurnOnGoals()
    {
        goals.SetActive(true);
    }

    public void TurnOffGoals()
    {
        goals.SetActive(false);
    }

    void UpdateUIText(){
        currentRGB[0]=mixingController.resultColour.r * 255 - (mixingController.resultColour.r * 255)%1.0f;
        currentRGB[1]=mixingController.resultColour.g * 255 - (mixingController.resultColour.g * 255)%1.0f;
        currentRGB[2]=mixingController.resultColour.b * 255 - (mixingController.resultColour.b * 255)%1.0f;

        goalText.text=goalRGB[0].ToString()+ "     " + goalRGB[1].ToString()+"     "+goalRGB[2].ToString();
        currentText.text=currentRGB[0].ToString()+ "     " + currentRGB[1].ToString()+ "     " + currentRGB[2].ToString();

        closeness[0]=Mathf.Abs(goalRGB[0]-currentRGB[0]);
        closeness[1]=Mathf.Abs(goalRGB[1]-currentRGB[1]);
        closeness[2]=Mathf.Abs(goalRGB[2]-currentRGB[2]);
        totalCloseness = (closeness[0]+closeness[1]+closeness[2])/255;

        tempNr = (int)(totalCloseness * 100);

        CloseToGoal.text = (Mathf.Clamp(100 - tempNr, 0, 100)).ToString() + "  %";            //(100 - (totalCloseness*100)).ToString();
        fullness.text = mixingController.currentCapacity.ToString()+"/"+mixingController.maxCapacity.ToString();
    }
    // Update is called once per frame
    void Update()
    {

        UpdateUIText();

        
        if (!activeClient)
        {
            activeClient = true;
            CreateClient();
        }
    }
}
