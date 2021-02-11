using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTimeBody : MonoBehaviour
{

    public bool isRewinding = false;

    List<Vector3> positions;
   // List<CPointInTime> position;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector3>();
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
        if(positions.Count > 0)
        {
        transform.position = positions[0];
        positions.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }

    }

    void Record()
    {
        positions.Insert(0, transform.position);
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
