using Unity.Mathematics;
using UnityEngine;

public class PinBehaviour : MonoBehaviour
{
    [SerializeField]
    private ScoreSO scoreSO;
    private bool standing = true;

    void Awake()
    {
        standing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(standing)
        {
            //do fall over check
            if((Mathf.Abs(gameObject.transform.rotation.eulerAngles.x) > 55 &&  Mathf.Abs(gameObject.transform.rotation.eulerAngles.x) < 305) || (Mathf.Abs(gameObject.transform.rotation.eulerAngles.z) > 55 &&  Mathf.Abs(gameObject.transform.rotation.eulerAngles.z) < 305) )
            {
                standing = false;
                scoreSO.StandingPins--;
                Debug.Log(scoreSO.StandingPins);
            }
        }
    }
}
