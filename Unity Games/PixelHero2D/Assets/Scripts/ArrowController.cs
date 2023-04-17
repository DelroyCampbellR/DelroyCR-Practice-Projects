using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private Rigidbody2D arrowRB; //9. Creamos referencia al rigidbody2d
    [SerializeField]
    private float arrowSpeed; //9.1 velocidad del arrow
    private Vector2 _arrowDirection; //9.2 direcci�n del arrow. 
    //11.4. Presionamos alt + ENTER en arrowDirection y seleccionamos "Encapsular campo y usar propiedad". Esto va a crear el get set de abajo y tambi�n va a reemplazar ArrowDirection en var�as l�neas de c�digo abajo. Le ponemos un gui�n bajo para diferenciar los campos (conectados a una propiedad p�blica) de otras variables. Ahora vamos al script playercontroller

    [SerializeField]
    private GameObject arrowImpact; //12. Primero necesitamos una instancia de la part�cula
    private Transform transformArrow; //12.1. Vamos a tomar el componente transform

    public Vector2 ArrowDirection { get => _arrowDirection; set => _arrowDirection = value; }

    

    private void Awake()
    {
        arrowRB = GetComponent<Rigidbody2D>(); //9.3 busco el componente rigidbody2d del arrow
        transformArrow = GetComponent<Transform>(); //12.2. Tomamos el componente transform 
    }

    /*private void Start()
    {
        arrowDirection = new Vector2(1, arrowRB.velocity.y); //9.6. Creo la direcci�n de la flecha. Esta l�nea fue movida al start porque es m�s recomendable que en el awake se busquen referencias mientras que en el start est�n las inicializaciones. Y con esto deber�a salir disparada la flecha sola en el editor. 
    //Se coment� en el paso 11.3, porque solo era un test.
    }*/
    void Update()
    {
        arrowRB.velocity = ArrowDirection * arrowSpeed; //9.4 accedo al arrowrb velocity, que ser� igual a la direcci�n por la velocidad
    }

    private void OnTriggerEnter2D(Collider2D collision) //9.5 Cuando ocurra una colisi�n, que se destruya la flecha. Luego agregamos este script al PlayerArrow, le ponemos una velocidad en el editor, y metemos ese go al layer arrow.
    {
        Instantiate(arrowImpact, transformArrow.position, Quaternion.identity); //12.3. Finalizamos la instanciaci�n del impacto de la flecha. Vamos al editor, y en el prefab del arrow conectamos el sistema de part�culas que hicimos con el espacio "Arrow Impact".
                                                                                //13. Luego creamos un GO de part�culas llamado DustJump y en el renderer de las part�culas cambiamos el sorting layer a Player, el material a sprites default, shape a box, rotaci�n a 0, lo acercamos al personaje para ajustar el tama�o, cambiamos el scale en la secci�n shape, en emission cambio el rate over time a 0 y agrego un nuevo bursts con un count de 15. Luego en la part�cula cambiamos la duraci�n (aunque igual el bursts se encargar� de eso), el start lifetime de 0.2 a 0.5, startsize a 0.11, start speed 0.5. Size over lifetime con una curva de peque�o a grande. Ponemos start color en random entre 2 colores, blanco y otro. El gravity modifier a -0.1. Luego en la part�cula le cambiamos el stop action a destroy. Le reseteamos la posici�n a 0 0 0, y lo guardamos como prefab en la carpeta particulasfx. Luego necesitamos un punto de referencia para las part�culas de polvo, creamos un hijo en player, vac�o, llamado dustpoint y colocamos su posici�n donde queremos que aparezca el polvo. Adem�s de instanciar este punto, tambi�n vamos a optimizar el arrowpoint instanci�ndolo. As� que vamos al script player controller y continuamos en el paso 13.1.
        Destroy(gameObject);
    }

    private void OnBecameInvisible() //9.7. Utilizamos este m�todo para que la flecha desaparezca cuando sale de la c�mara y la escena. OJO, si desaaparece de golpe o no donde deber�a, puede deberse a que le falta un renderer al objeto, o simplemente que no est� recarg�ndose la escena (en project settings/editor/reload scene, no tener esta opci�n hace que el play cargue m�s r�pido, pero no recarga la escena, y eso puede dar problemas). Ahora vamos al playercontroller a setear la animacion de las flechas lanzadas
    {
        Destroy(gameObject);
    }
}
