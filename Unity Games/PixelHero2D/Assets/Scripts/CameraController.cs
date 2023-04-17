using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerController playerController; //7. Haremos que la c�mara siga al player. Creamos la referencia al script primero.
    private Transform camTransform;
    private Transform playerTransform;
    private BoxCollider2D levelLimit; //7.6. Buscamos el componente boxcollider2d, y lo llamamos levelLimit en este script
    private float cameraSizeHorizontal;  //8. Creamos estas 2 variables de c�mara.  
    private float cameraSizeVertical;
    void Start()
    {
        levelLimit = GameObject.Find("LevelLimit").GetComponent<BoxCollider2D>(); //7.7. Buscamos el GO LevelLimit (del editor), y su componente boxcollider2d, y lo asignamos a la instancia levelLimit (de este script).
        camTransform = transform; //7.1. Para evitar estar haciendo "GetComponent(transform.position," etc", asignamos el transform al camTransform.
        //camTransform = GetComponent<Transform>(); //La l�nea anterior se puede hacer tambi�n as�.
        playerController = FindObjectOfType<PlayerController>(); //7.2. Como solo hay un objeto lo busco por type. En otras circunstancias tal vez necesite buscar por string pero en este caso no.
        playerTransform = playerController.transform; //7.3. Y creamos la tercera referencia, accediendo al transform del playercontroller.
        //playerTransform = playerController.GetComponent<Transform>(); //La l�nea anterior se puede hacer tambi�n as�.
        cameraSizeVertical = Camera.main.orthographicSize; //8.1. Accedemos al margen superior de la c�mara seg�n su tama�o ortogr�fica y se lo asignamos.
        cameraSizeHorizontal = Camera.main.orthographicSize * Camera.main.aspect; //8.2. Esto me dar� el margen horizontal. Ahora vamos a abajo para sumar/restar estas variables al bloque del if.
    }

    void LateUpdate() //LateUpdate es recomendable cuando queremos que todo lo dem�s suceda antes de que se aplique lo que haya en este bloque. Pero si la c�mara est� suavizada o algo se usa el update normal.
    {
        if (playerController != null) //7.4. Si esto no es nulo,
        {
            //camTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, camTransform.position.z); //7.5 Actualiza la posici�n de la c�mara seg�n la posici�n del player en x, y. En z mantendr� la posici�n de la propia c�mara (est� en -10 en Z). En modo debug, el script deber�a tomar las 3 referencias: El playercontroller, maincamera transform y player transform. Ahora iremos al editor y creamos un GO para delimitar la c�mara con el mapa (Go LevelLimit), y lo metemos a un nuevo user layer llamado No Collision. Y vamos a project settings/physics 2d y desmarcamos todos los layers vinculados al layer no collision. Luego en el GO levellimit agregamos un box collider 2d que sea is trigger, y extendemos el margen del boxcollider, que obviamente es m�s grande que la c�mara y cubre casi todo el nivel.
            //Coment� lo anterior porque en el paso 7.7 se le agregar�n l�neas a este c�digo porque vamos a poner los l�mites del nivel, as� veo la diferencia.

            camTransform.position = new Vector3(
                Mathf.Clamp(playerTransform.position.x, levelLimit.bounds.min.x + cameraSizeHorizontal, levelLimit.bounds.max.x - cameraSizeHorizontal),
                Mathf.Clamp(playerTransform.position.y, levelLimit.bounds.min.y + cameraSizeVertical, levelLimit.bounds.max.y - cameraSizeVertical), 
                camTransform.position.z); //7.8. Se agrega la propiedad math.clamp. Su sobrecarga primero pedir� el valor que quiero meter en la abracadera (playertransform.position x) y que debo pasar el m�nimo y el m�ximo. La posici�n la calcula sobre el gizmo (centro de la c�mara), por ende tendremos que sumar el size vertical y horizontal (que obtendremos despu�s). Entonces, como primer par�metro usamos el playertransform.position.x, como segundo par�metro (min) usaremos el levelLimit.bounds (bordes) m�nimos de X (a la izquierda) y el l�mite m�ximo en X (a la derecha). Hacemos luego lo mismo pero en Y. Y en Z no se cambia porque es en 2D. Regresando al editor en modo debug, este script en la c�mara deber�a obtener todas las referencias al darle play. En el juego se notar� que el centro de la c�mara llega hasta el borde del collider. Podr�a funcionar bien con eso pero lo que haremos ser� meter los sizes de la c�mara que hab�amos mencionado para que no se salga tanto de la escena. As� que vamos al paso n�mero 8 arriba.
            //8.3. Ahora que conseguimos el camerasizevertical y horizontal, lo sumamos/restamos a las l�neas. //Nota adicional: Es recomendable trabajar con fixedupdate en lugar de update al trabajar con rigidbody. En este caso no se hizo porque tengo control de todos los par�metros, y las fuerzas siempre van a ser las mismas, pero si hablamos de f�sicas que se ven afectadas por fuerzas fuera de mi control es mejor usar fixedupdate para mantener todo constante. //8.4. Ahora vamos a crear las flechas. Primero creamos un GO vac�o PlayerArrow. Le agregamos un sprite renderer y en sprite la flecha 1 (Objects/Bow/1). Creamos sorting layer del sprite renderer llamado "Player", el standing player y el playerarrow deben estar en �l. Creamos una animaci�n llamada "Player_Arrow_Flying", agregamos las flechas 1 y 2 y hacemos una animaci�n donde "parpadee" la flecha usando ambas por turnos, por unos 30 frames. Vamos al go playerarrow y agregamos un rigidbody2d sin gravity scale, un capsule collider2d con is trigger activo (editamos el collider si es necesario). Creamos 2 nuevos layers normales, Player y Arrow. Vamos a project settings/physics 2d y arrow no debe tener colisi�n con no collision ni con arrow, y player no debe tener colisi�n con arrow. Y ahora vamos a crear un script arrowcontroller y trabajar all�.
        }  
    }
}
