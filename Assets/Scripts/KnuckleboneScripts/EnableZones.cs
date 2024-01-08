using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableZones : MonoBehaviour
{
    [SerializeField]
    private GameObject handL;
    [SerializeField]
    private GameObject handR;
    [SerializeField]
    private Transform player;

    void Update()
    {
        if(Vector3.Distance(this.transform.position, player.position) < 5)
        {
            handL.SetActive(true);
            handR.SetActive(true);
        }
        else 
        {
            handL.SetActive(false);
            handR.SetActive(false);
        }
    }
}
