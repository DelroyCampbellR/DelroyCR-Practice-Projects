using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] private float waitForExplode; //23. Creamos este script completo y luego regresamos al playercontroller en el paso 24 en la declaración de variables
    [SerializeField] private float waitForDestroy;
    private Animator animator;
    private bool isActive;
    private int IdIsActive;
    [SerializeField] private Transform transformBomb; //25. Creamos estas 3 variables y abajo buscamos referencias
    [SerializeField] private float expansiveWaveRange;
    [SerializeField] private LayerMask isDestroyable; //Mostrará en el editor (en el prefab de la bomb) la lista de los layers, ahí definimos el layer que detectará, en este caso, destroyable, para destruir los objetos en dicho layer.
    private void Awake()
    {
        animator = GetComponent<Animator>();
        IdIsActive = Animator.StringToHash("isActive"); //Convertimos el string a id
        transformBomb = GetComponent<Transform>(); //25.1. Buscamos esta referencia //29.3. Comentamos. Tener en cuenta que cuando asignamos los transform en el inspector, el bombpoint transform debe venir de un prefab para pasarse a un bomb prefab. Si no aparece como si estuviera bloqueado. Así que convertimos el bombpoint en un prefab y directamente desde ese prefab (digamos en la lista de archivos de la carpeta prefabs) se pasa al bomb prefab (de la misma lista) //Lo he descomentado porque por alguna razón el transform siempre estaba en 0 pero con esto ya se coloca el gizmosdraw en la bomba
    }
    private void Update()
    {
        waitForExplode -= Time.deltaTime;
        waitForDestroy -= Time.deltaTime;
        if (waitForExplode <= 0 && !isActive)
        {
            ActivatedBomb();
        }
        if (waitForDestroy <= 0)
        {
            Destroy(gameObject);
        } 
    }
    private void ActivatedBomb()
    {
        isActive = true;
        animator.SetBool(IdIsActive, isActive); //transita a la explosión si el waitforexplode es igual o menor que 0 y isActive es false
        Collider2D[] destroyedObjects = Physics2D.OverlapCircleAll(transformBomb.position, expansiveWaveRange, isDestroyable); //25.2. Si estalla la bomba, va a buscar en este radio y si encuentra un destroyable lo agrega a la lista
        if (destroyedObjects.Length > 0) //25.3. Si encuentra algo dentro de la lista (o sea, si hay objetos destruibles agregados) entonces: 
        {
            foreach (var col in destroyedObjects)
            {
                Destroy(col.gameObject); //25.4. Recorremos la lista y destruimos los GO encontrados dentro de ella. Ahora al script playerextrastracker en el paso 26.
            }
        }
    }
    private void OnDrawGizmos() //29.1. Llamamos a ondraw aquí también
    {
        Gizmos.DrawWireSphere(transformBomb.position, expansiveWaveRange);
    }
}
