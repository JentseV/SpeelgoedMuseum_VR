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
    private float yPosition;
    [SerializeField]
    private float dropSpeed;

    private bool standing = true;
    private bool resetting = false;

    void Awake()
    {
        standing = true;
        Reset(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.localPosition.y >= yPosition + 0.15 && resetting)
        {
            gameObject.transform.rotation = new quaternion(0, 0, 0, 0);
            Reset(gameObject.transform.localPosition.y - dropSpeed);
        }
        else if(resetting){
            standing = true;     
            resetting = false;
        }
        else if(standing)
        {
            //do fall over check
            if(Mathf.Abs(gameObject.transform.rotation.z) > 45 || Mathf.Abs(gameObject.transform.rotation.x) > 45 )
            {
                standing = false;
                scoreSO.BowlingScore++;
            }
        }

        if(scoreSO.BowlingScore % 9 == 0 && scoreSO.BowlingScore > 0)
        {
            Reset(yPosition + 1.5f);
            resetting = true;
        }
    }

    private void Reset(float yPos)
    {
        gameObject.transform.localPosition = new Vector3(xPosition, yPos, zPosition);
        gameObject.transform.rotation = new quaternion(0, 0, 0, 0);
    }
}
