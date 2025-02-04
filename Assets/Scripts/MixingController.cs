using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;

public class MixingController : MonoBehaviour
{
    public Transform maskTransform;
    public float maskTransformMinPos;
    public float maskTransformMaxPos;
    public int maxCapacity = 100;
    public int currentCapacity = 0;
    public bool maxCapacityReached = false;
    public GameObject resultPotionGameobject;
    public Material resultMaterial;
    public SpriteRenderer resultSprite;
    public Color resultColour;
    public List<Material> sources;
    public List<Color> sourceColours;
    public List<int> ratios;
    private Renderer tempRenderer;
    public ParticleSystem particleSystemThing;
    public ParticleSystem.MainModule bubbleParticleSystem;
    public ParticleSystem.EmissionModule bubbleParticleSystemEmission;
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
        if(currentCapacity < maxCapacity)
            ratios[ratioIndex]+=1;
    }
    public void resetPotion(){
        ratios.Clear();
        sourceColours.Clear();
        resultColour.r=0.0f;
        resultColour.g=0.0f;
        resultColour.b=0.0f;
        currentCapacity=0;
        maxCapacityReached=false;
    }
    void getPotionGameObject(){
        resultPotionGameobject = GameObject.FindWithTag("Pot");
        tempRenderer = resultPotionGameobject.GetComponent<Renderer>();
        //resultMaterial = tempRenderer.material;
        resultColour = resultPotionGameobject.GetComponent<SpriteRenderer>().color;
        //resultColour = resultMaterial.color;
    }
    void updateParticles(){
        bubbleParticleSystem.startColor = resultColour;
        bubbleParticleSystemEmission.rateOverTime = currentCapacity/10;
    }
    // Start is called before the first frame update
    void Start()
    {
        getPotionGameObject();
        bubbleParticleSystem = particleSystemThing.main;
        bubbleParticleSystemEmission = particleSystemThing.emission;
        //for(int i=0;i<sources.Length;i++){
        //    sourceColours.Add(sources[i].color);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCapacity==maxCapacity)maxCapacityReached=true;
        resultColour.r=0.0f;
        resultColour.g=0.0f;
        resultColour.b=0.0f;
        maskTransform.position = new Vector3(maskTransform.position.x, maskTransformMinPos + (((maskTransformMaxPos-maskTransformMinPos)/maxCapacity)*currentCapacity),maskTransform.position.z);

        for(int i=0;i<sourceColours.Count;i++){
            int ratiosum=0;
            for(int j=0;j<ratios.Count;j++){
                ratiosum+=ratios[j];
            }
            resultColour.r += sourceColours[i].r / ratiosum * ratios[i];
            resultColour.g += sourceColours[i].g / ratiosum * ratios[i];
            resultColour.b += sourceColours[i].b / ratiosum * ratios[i];
            currentCapacity = ratiosum;
        }
        resultPotionGameobject.GetComponent<SpriteRenderer>().color = resultColour;
        updateParticles();
        //resultMaterial.color=resultColour;
    }
}
