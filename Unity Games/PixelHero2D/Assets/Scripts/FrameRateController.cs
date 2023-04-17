using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateController : MonoBehaviour
{
   [SerializeField] private int target; //19. Creamos esta variable y el limitador en el awake. En el inspector colocamos 60 como target.
   private void Awake()
    {
        Application.targetFrameRate = target; //Y regresamos al script playercontroller en el paso 20
    }
}
