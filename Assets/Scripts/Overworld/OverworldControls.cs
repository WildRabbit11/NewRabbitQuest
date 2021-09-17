using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Tilemaps;

public class OverworldControls : MonoBehaviour
{
    //[SerializeField] private Tilemap groundTilemap;
    //[SerializeField] private Tilemap collisionTilemap;

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

    //private void Start()
    //{
    //    //ctx = context
    //    playerCS.Overworld.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
    //}

    //private void Move(Vector2 direction)
    //{
    //    if (CanMove(direction))
    //        transform.position += (Vector3)direction;
    //}

    //private bool CanMove(Vector2 direction)
    //{
    //    Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
    //    if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition))
    //        return false;
    //    return true;
    //}
}
