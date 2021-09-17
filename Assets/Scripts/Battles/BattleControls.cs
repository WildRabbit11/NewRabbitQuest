using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleControls : MonoBehaviour
{
    [HideInInspector] public PlayerControlSystem playerCS;

    void Awake()
    {
        playerCS = new PlayerControlSystem();
    }

    private void OnEnable()
    {
        playerCS.Enable();
    }

    private void OnDisable()
    {
        playerCS.Disable();
    }
}
