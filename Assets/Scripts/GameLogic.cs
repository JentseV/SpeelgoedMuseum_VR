using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    [SerializeField] private KeyScript keyScript;
    public float collectedCoins = 0;
    [SerializeField] private Player player;
    [SerializeField] private GameObject keyChest;

    [SerializeField] private GameObject disableBeforeEntry;
    [SerializeField] private GameObject entrance;
    [SerializeField] private GameObject enableAfterEntry;

    [SerializeField] private GameObject blockLight;

    public bool entry = false;


    void Start()
    {
        
    }

    void Update()
    {
        if(!entry){
            disableBeforeEntry.SetActive(false);
        }else{
            disableBeforeEntry.SetActive(true);
            entrance.transform.position = new Vector3(1.47549999f,-21.1299992f,20.1800003f);
            blockLight.SetActive(false);
            enableAfterEntry.SetActive(true);
            RenderSettings.ambientIntensity = 0.68f;
        }

        if(keyScript.keyPickedUp){
            entrance.SetActive(true);
            entrance.GetComponentInChildren<PaintingScript>().enabled= false;
            entrance.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            entrance.transform.position = new Vector3(0.25999999f,-3.69f,42.8800011f);
            GameObject painting = GameObject.FindGameObjectWithTag("Painting");
            Material paintingMaterial = painting.GetComponent<Renderer>().material;
            Color currentColor = paintingMaterial.color;
            currentColor.a = 1.0f;
            paintingMaterial.color = currentColor;
        }
        
    }
}
