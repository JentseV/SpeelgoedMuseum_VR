using Unity.Mathematics;
using UnityEngine;

public class PinBehaviour : MonoBehaviour
{
    [SerializeField]
    private ScoreSO scoreSO;
    [SerializeField]
    private float xPosition;
    [SerializeField]
    private float zPosition;
    [SerializeField]
    private float resetHeight;
    private bool standing = true;
    private bool startReset = false;

    void Awake()
    {
        standing = true;
        startReset = false;
        Load();
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
            }
        }
    }

    private void Load()
    {
        if(!startReset)
        {
            gameObject.transform.localPosition = new Vector3(xPosition, resetHeight, zPosition);
            gameObject.transform.rotation = new quaternion(0, 0, 0, 0);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            startReset = true;
        }

        if(!(gameObject.transform.localPosition.y >= 0.01))
        {
            standing = true;     
            scoreSO.StandingPins++;
            startReset = false;
        }
    }
}
