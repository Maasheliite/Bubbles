using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MixingController : MonoBehaviour
{
    public GameObject resultPotionGameobject;
    public Material resultMaterial;
    public Color resultColour;
    public List<Material> sources;
    public List<Color> sourceColours;
    public List<int> ratios;
    private Renderer tempRenderer;

    public int addColorToSources(Material source){  // this should be called on collision enter
        if(sourceColours.Contains(source.color)){  // don't add the same potion repeatedly, just return it's place in the list
        }
        else{
            sources.Add(source);
            sourceColours.Add(source.color);
            ratios.Add(0);
        }
        return sourceColours.IndexOf(source.color); // either way, you'll need to know the position of it in the list of source colors, to know which ratio to increase.
    }
    public void incrementRatio(int ratioIndex){ // this should be called while it is colliding.
        ratios[ratioIndex]+=1;
    }
    void getPotionGameObject(){
        resultPotionGameobject = GameObject.FindWithTag("ResultingPotion");
        tempRenderer = resultPotionGameobject.GetComponent<Renderer>();
        resultMaterial = tempRenderer.material;
        resultColour = resultMaterial.color;
    }
    // Start is called before the first frame update
    void Start()
    {
        getPotionGameObject();
        //for(int i=0;i<sources.Length;i++){
        //    sourceColours.Add(sources[i].color);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        resultColour.r=0.0f;
        resultColour.g=0.0f;
        resultColour.b=0.0f;
        for(int i=0;i<sourceColours.Count;i++){
            int ratiosum=0;
            for(int j=0;j<ratios.Count;j++){
                ratiosum+=ratios[j];
            }
            resultColour.r += sourceColours[i].r / ratiosum * ratios[i];
            resultColour.g += sourceColours[i].g / ratiosum * ratios[i];
            resultColour.b += sourceColours[i].b / ratiosum * ratios[i];
        }
        resultMaterial.color=resultColour;
    }
}
