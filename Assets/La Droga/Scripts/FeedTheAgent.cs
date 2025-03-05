using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedTheAgent : MonoBehaviour
{
    CompañiaAgent companionAgent;

    void Start()
    {
        companionAgent = GameObject.Find("Sand Spider").GetComponent<CompañiaAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            companionAgent.feed(gameObject.transform);
        }
    }
}
