using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{
    public MixingController mixingController;
    public Material potionMaterial;
    public int indexInController;
    public bool canPour;

    // Start is called before the first frame update
    void Start()
    {
        mixingController = (MixingController) GameObject.FindObjectOfType(typeof(MixingController));
        potionMaterial = this.GetComponent<Renderer>().material;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnCollisionEnter");
        if(collision.gameObject.tag=="Pot" && canPour){
            indexInController = mixingController.addColorToSources(potionMaterial);
        }
    }
    void OnTriggerStay2D(Collider2D collision){
        Debug.Log("OnCollisionStay");
        if(collision.gameObject.tag=="Pot" && !mixingController.maxCapacityReached && canPour){
            mixingController.ratios[indexInController]+= 1;
        }
    }
}
