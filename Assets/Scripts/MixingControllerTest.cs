using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MixingControllerTest : MonoBehaviour
{
    public Material resultMaterial;
    public Color resultColour;
    public Material[] sources;
    public List<Color> sourceColours;
    public int[] ratios;
    // Start is called before the first frame update
    void Start()
    {
         for(int i=0;i<sources.Length;i++){
            sourceColours.Add(sources[i].color);
         }
    }

    // Update is called once per frame
    void Update()
    {
        resultColour.r=0.0f;
        resultColour.g=0.0f;
        resultColour.b=0.0f;
        for(int i=0;i<sources.Length;i++){
            int ratiosum=0;
            for(int j=0;j<ratios.Length;j++){
                ratiosum+=ratios[j];
            }
            resultColour.r += sourceColours[i].r / ratiosum * ratios[i];
            resultColour.g += sourceColours[i].g / ratiosum * ratios[i];
            resultColour.b += sourceColours[i].b / ratiosum * ratios[i];
        }
        resultMaterial.color=resultColour;
    }
}
