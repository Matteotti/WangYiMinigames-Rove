using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDir : MonoBehaviour
{
    public GameObject a,b;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(a.transform.position - b.transform.position);

    }
}
