using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParty : MonoBehaviour
{
    public GameObject[] playerParty;
    [HideInInspector] public GameObject[] playerPartyActive;

    // Start is called before the first frame update
    void Start()
    {
        playerPartyActive = playerParty;
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
