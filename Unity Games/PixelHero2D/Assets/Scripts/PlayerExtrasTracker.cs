using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExtrasTracker : MonoBehaviour
{
    [SerializeField] private bool _canDoubleJump, _canDash, _canEnterBallMode, _canDropBombs; //26. Creamos estas variables privadas y las encapsulamos y usamos como propiedades públicas

    public bool CanDoubleJump { get => _canDoubleJump; set => _canDoubleJump = value; }
    public bool CanDash { get => _canDash; set => _canDash = value; }
    public bool CanEnterBallMode { get => _canEnterBallMode; set => _canEnterBallMode = value; }
    public bool CanDropBombs { get => _canDropBombs; set => _canDropBombs = value; }//26.1. Ahora vamos a asociar el playercontroller con el playerextrastracker, así que vamos a la declaración de variable en playercontrol en el paso 26.2
    
}
