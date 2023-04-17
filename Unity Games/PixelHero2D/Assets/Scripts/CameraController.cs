using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerController playerController; //7. Haremos que la cámara siga al player. Creamos la referencia al script primero.
    private Transform camTransform;
    private Transform playerTransform;
    private BoxCollider2D levelLimit; //7.6. Buscamos el componente boxcollider2d, y lo llamamos levelLimit en este script
    private float cameraSizeHorizontal;  //8. Creamos estas 2 variables de cámara.  
    private float cameraSizeVertical;
    void Start()
    {
        levelLimit = GameObject.Find("LevelLimit").GetComponent<BoxCollider2D>(); //7.7. Buscamos el GO LevelLimit (del editor), y su componente boxcollider2d, y lo asignamos a la instancia levelLimit (de este script).
        camTransform = transform; //7.1. Para evitar estar haciendo "GetComponent(transform.position," etc", asignamos el transform al camTransform.
        //camTransform = GetComponent<Transform>(); //La línea anterior se puede hacer también así.
        playerController = FindObjectOfType<PlayerController>(); //7.2. Como solo hay un objeto lo busco por type. En otras circunstancias tal vez necesite buscar por string pero en este caso no.
        playerTransform = playerController.transform; //7.3. Y creamos la tercera referencia, accediendo al transform del playercontroller.
        //playerTransform = playerController.GetComponent<Transform>(); //La línea anterior se puede hacer también así.
        cameraSizeVertical = Camera.main.orthographicSize; //8.1. Accedemos al margen superior de la cámara según su tamaño ortográfica y se lo asignamos.
        cameraSizeHorizontal = Camera.main.orthographicSize * Camera.main.aspect; //8.2. Esto me dará el margen horizontal. Ahora vamos a abajo para sumar/restar estas variables al bloque del if.
    }

    void LateUpdate() //LateUpdate es recomendable cuando queremos que todo lo demás suceda antes de que se aplique lo que haya en este bloque. Pero si la cámara está suavizada o algo se usa el update normal.
    {
        if (playerController != null) //7.4. Si esto no es nulo,
        {
            //camTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, camTransform.position.z); //7.5 Actualiza la posición de la cámara según la posición del player en x, y. En z mantendrá la posición de la propia cámara (está en -10 en Z). En modo debug, el script debería tomar las 3 referencias: El playercontroller, maincamera transform y player transform. Ahora iremos al editor y creamos un GO para delimitar la cámara con el mapa (Go LevelLimit), y lo metemos a un nuevo user layer llamado No Collision. Y vamos a project settings/physics 2d y desmarcamos todos los layers vinculados al layer no collision. Luego en el GO levellimit agregamos un box collider 2d que sea is trigger, y extendemos el margen del boxcollider, que obviamente es más grande que la cámara y cubre casi todo el nivel.
            //Comenté lo anterior porque en el paso 7.7 se le agregarán líneas a este código porque vamos a poner los límites del nivel, así veo la diferencia.

            camTransform.position = new Vector3(
                Mathf.Clamp(playerTransform.position.x, levelLimit.bounds.min.x + cameraSizeHorizontal, levelLimit.bounds.max.x - cameraSizeHorizontal),
                Mathf.Clamp(playerTransform.position.y, levelLimit.bounds.min.y + cameraSizeVertical, levelLimit.bounds.max.y - cameraSizeVertical), 
                camTransform.position.z); //7.8. Se agrega la propiedad math.clamp. Su sobrecarga primero pedirá el valor que quiero meter en la abracadera (playertransform.position x) y que debo pasar el mínimo y el máximo. La posición la calcula sobre el gizmo (centro de la cámara), por ende tendremos que sumar el size vertical y horizontal (que obtendremos después). Entonces, como primer parámetro usamos el playertransform.position.x, como segundo parámetro (min) usaremos el levelLimit.bounds (bordes) mínimos de X (a la izquierda) y el límite máximo en X (a la derecha). Hacemos luego lo mismo pero en Y. Y en Z no se cambia porque es en 2D. Regresando al editor en modo debug, este script en la cámara debería obtener todas las referencias al darle play. En el juego se notará que el centro de la cámara llega hasta el borde del collider. Podría funcionar bien con eso pero lo que haremos será meter los sizes de la cámara que habíamos mencionado para que no se salga tanto de la escena. Así que vamos al paso número 8 arriba.
            //8.3. Ahora que conseguimos el camerasizevertical y horizontal, lo sumamos/restamos a las líneas. //Nota adicional: Es recomendable trabajar con fixedupdate en lugar de update al trabajar con rigidbody. En este caso no se hizo porque tengo control de todos los parámetros, y las fuerzas siempre van a ser las mismas, pero si hablamos de físicas que se ven afectadas por fuerzas fuera de mi control es mejor usar fixedupdate para mantener todo constante. //8.4. Ahora vamos a crear las flechas. Primero creamos un GO vacío PlayerArrow. Le agregamos un sprite renderer y en sprite la flecha 1 (Objects/Bow/1). Creamos sorting layer del sprite renderer llamado "Player", el standing player y el playerarrow deben estar en él. Creamos una animación llamada "Player_Arrow_Flying", agregamos las flechas 1 y 2 y hacemos una animación donde "parpadee" la flecha usando ambas por turnos, por unos 30 frames. Vamos al go playerarrow y agregamos un rigidbody2d sin gravity scale, un capsule collider2d con is trigger activo (editamos el collider si es necesario). Creamos 2 nuevos layers normales, Player y Arrow. Vamos a project settings/physics 2d y arrow no debe tener colisión con no collision ni con arrow, y player no debe tener colisión con arrow. Y ahora vamos a crear un script arrowcontroller y trabajar allí.
        }  
    }
}
