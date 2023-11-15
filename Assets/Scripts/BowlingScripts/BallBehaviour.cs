using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallBehaviour : MonoBehaviour
{
    [SerializeField]
    private ScoreSO scoreSO;
    [SerializeField]
    private float xPosition;
    [SerializeField]
    private float zPosition;
    [SerializeField]
    private float yPosition;

    private float timeInZone = 0f;
    [SerializeField]
    private float resetTime = 3f;

    void Awake()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreSO.Resetting)
        {
            Load();
        }

    }

    private void Load()
    {
        gameObject.transform.localPosition = new Vector3(xPosition, yPosition, zPosition);
        gameObject.transform.rotation = new quaternion(0, 0, 0, 0);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        timeInZone = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Load();
            scoreSO.BallThrows += 1;
            Debug.Log("ball hit wall");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Reset"))
        {
            timeInZone += Time.deltaTime;
            if (timeInZone >= resetTime)
            {
                Load();
                scoreSO.BallThrows += 1;
                Debug.Log("ball was in zone");
            }
        }
    }
}