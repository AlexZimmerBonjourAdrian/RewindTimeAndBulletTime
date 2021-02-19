using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTimeBody : MonoBehaviour
{

     bool isRewinding = false;
    public float recordTime = 5f;

    List<CPointInTime> pointsInTime;


    //List<Vector3> positions;
   // List<CPointInTime> position;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        pointsInTime = new List<CPointInTime>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartRewind();
        }
        if(Input.GetKeyUp(KeyCode.Return))
        {
            StopRewind();
        }
    }

    private void FixedUpdate()
    {
        if (isRewinding)
            Rewind();

        else
            Record();
    }

    void Rewind()
    {
       if(pointsInTime.Count>0)
        {
            CPointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }

    }

    void Record()
    {
       if(pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }
        pointsInTime.Insert(0, new CPointInTime(transform.position, transform.rotation));
    }

    void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }
}
