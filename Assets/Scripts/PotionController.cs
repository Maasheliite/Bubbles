using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{
    public MixingController mixingController;
    public Material potionMaterial;
    public int indexInController;
    // Start is called before the first frame update
    void Start()
    {
        mixingController = (MixingController) GameObject.FindObjectOfType(typeof(MixingController));
        potionMaterial = this.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        if(collision.gameObject.tag=="PouringSpot"){
            indexInController = mixingController.addColorToSources(potionMaterial);
        }
    }
    void OnCollisionStay(Collision collision){
        Debug.Log("OnCollisionStay");
        if(collision.gameObject.tag=="PouringSpot"){
            mixingController.ratios[indexInController]+= 1;
        }
    }
}
