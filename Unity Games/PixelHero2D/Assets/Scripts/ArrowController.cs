using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private Rigidbody2D arrowRB; //9. Creamos referencia al rigidbody2d
    [SerializeField]
    private float arrowSpeed; //9.1 velocidad del arrow
    private Vector2 _arrowDirection; //9.2 dirección del arrow. 
    //11.4. Presionamos alt + ENTER en arrowDirection y seleccionamos "Encapsular campo y usar propiedad". Esto va a crear el get set de abajo y también va a reemplazar ArrowDirection en varías líneas de código abajo. Le ponemos un guión bajo para diferenciar los campos (conectados a una propiedad pública) de otras variables. Ahora vamos al script playercontroller

    [SerializeField]
    private GameObject arrowImpact; //12. Primero necesitamos una instancia de la partícula
    private Transform transformArrow; //12.1. Vamos a tomar el componente transform

    public Vector2 ArrowDirection { get => _arrowDirection; set => _arrowDirection = value; }

    

    private void Awake()
    {
        arrowRB = GetComponent<Rigidbody2D>(); //9.3 busco el componente rigidbody2d del arrow
        transformArrow = GetComponent<Transform>(); //12.2. Tomamos el componente transform 
    }

    /*private void Start()
    {
        arrowDirection = new Vector2(1, arrowRB.velocity.y); //9.6. Creo la dirección de la flecha. Esta línea fue movida al start porque es más recomendable que en el awake se busquen referencias mientras que en el start estén las inicializaciones. Y con esto debería salir disparada la flecha sola en el editor. 
    //Se comentó en el paso 11.3, porque solo era un test.
    }*/
    void Update()
    {
        arrowRB.velocity = ArrowDirection * arrowSpeed; //9.4 accedo al arrowrb velocity, que será igual a la dirección por la velocidad
    }

    private void OnTriggerEnter2D(Collider2D collision) //9.5 Cuando ocurra una colisión, que se destruya la flecha. Luego agregamos este script al PlayerArrow, le ponemos una velocidad en el editor, y metemos ese go al layer arrow.
    {
        Instantiate(arrowImpact, transformArrow.position, Quaternion.identity); //12.3. Finalizamos la instanciación del impacto de la flecha. Vamos al editor, y en el prefab del arrow conectamos el sistema de partículas que hicimos con el espacio "Arrow Impact".
                                                                                //13. Luego creamos un GO de partículas llamado DustJump y en el renderer de las partículas cambiamos el sorting layer a Player, el material a sprites default, shape a box, rotación a 0, lo acercamos al personaje para ajustar el tamaño, cambiamos el scale en la sección shape, en emission cambio el rate over time a 0 y agrego un nuevo bursts con un count de 15. Luego en la partícula cambiamos la duración (aunque igual el bursts se encargará de eso), el start lifetime de 0.2 a 0.5, startsize a 0.11, start speed 0.5. Size over lifetime con una curva de pequeño a grande. Ponemos start color en random entre 2 colores, blanco y otro. El gravity modifier a -0.1. Luego en la partícula le cambiamos el stop action a destroy. Le reseteamos la posición a 0 0 0, y lo guardamos como prefab en la carpeta particulasfx. Luego necesitamos un punto de referencia para las partículas de polvo, creamos un hijo en player, vacío, llamado dustpoint y colocamos su posición donde queremos que aparezca el polvo. Además de instanciar este punto, también vamos a optimizar el arrowpoint instanciándolo. Así que vamos al script player controller y continuamos en el paso 13.1.
        Destroy(gameObject);
    }

    private void OnBecameInvisible() //9.7. Utilizamos este método para que la flecha desaparezca cuando sale de la cámara y la escena. OJO, si desaaparece de golpe o no donde debería, puede deberse a que le falta un renderer al objeto, o simplemente que no está recargándose la escena (en project settings/editor/reload scene, no tener esta opción hace que el play cargue más rápido, pero no recarga la escena, y eso puede dar problemas). Ahora vamos al playercontroller a setear la animacion de las flechas lanzadas
    {
        Destroy(gameObject);
    }
}
