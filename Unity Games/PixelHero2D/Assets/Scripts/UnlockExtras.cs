using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockExtras : MonoBehaviour
{//27. Necesitamos 2 GO, el player, y el componente playerextrastracker. Además los bool del playerextrastracker.
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerExtrasTracker playerExtrasTracker;
    [SerializeField] private bool canDoubleJump, canDash, canEnterBallMode, canDropBombs;

    private void Start() //27.1. Buscamos estas referencias.
    {
        player = GameObject.Find("Player");
        playerExtrasTracker= player.GetComponent<PlayerExtrasTracker>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SetTracker();
        }
        Destroy(gameObject);
    }
    private void SetTracker()
    {
        if (canDoubleJump) playerExtrasTracker.CanDoubleJump = true;
        if (canDash) playerExtrasTracker.CanDash = true;
        if (canEnterBallMode) playerExtrasTracker.CanEnterBallMode = true;
        if (canDropBombs) playerExtrasTracker.CanDropBombs = true;
    }
    //Ahora vamos al player controller al paso 28 a implementar el -opcional- raycast y drawgizmos para checkgroundpoints, empezando en el método jump()
}
