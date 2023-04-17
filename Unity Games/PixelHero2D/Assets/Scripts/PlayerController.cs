using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player Sprites
    private GameObject standingPlayer; //21. Creamos estas 2 variables. Y también los 2 float (ballModeCounter, waitForBallMode) que los dejaremos en player movement.
    private GameObject ballPlayer;

    //Player movement
    [Header("Player Movement")] //Sirve para colocar títulos en el inspector.
    [SerializeField] private float moveSpeed; //1.2. Variable para trabajar la velocidad del movimiento
    [SerializeField] private float jumpForce; //2. Variable para controlar el salto
    private Rigidbody2D playerRB; //1. Instanciamos al componente Rigidbody2d.
    [SerializeField] private Transform checkGroundPoint;
    private Transform transformPlayerController; //2.4. Necesitamos una referencia al transform.
    [SerializeField] private LayerMask selectedLayerMask; //2.6. Desplegaremos todos los layers (como UI, Water, ground, etc) y lo asociamos a la variable selectedLayerMask. Aparecerá en el inspector una lista con todos los layers. Seleccionar Ground en este caso.
    private bool isGrounded, isFlippedInX; //2.7. Comprueba si ha tocado el suelo  //11.9.Creamos este bool flipped.
    //private Transform playerTransform; //16.5. Creamos variable. Y vamos al awake. //Comentado, ahora usaremos el transformPlayerController
    private Animator animatorStandingPlayer; //3. Instanciamos la variable animator. Esto se hace despúes de ya haber creado el componente animator y la animación en el editor.
    private Animator animatorBallPlayer; //22. Creamos esta variable de la animación del ball mode.
    private int IdSpeed, IdIsGrounded, IdShootArrow, IdCanDoubleJump; //3.4. Ahora esto es para optimizarlo, usando ids en lugar de strings. Creamos la variable para el id de velocidad. //3.5. Creamos el del isgrounded. //10. Creamos id para variable del shootarrow //15.5. Creamos nuevo id para el doble salto.
    private float ballModeCounter;
    [SerializeField] private float waitForBallMode;
    [SerializeField] private float isGroundedRange; //28.1. Creamos esta variable. Ahora vamos a ondrawgizmos abajo en el paso 29.

    [Header("Player Shoot")]
    [SerializeField] private ArrowController arrowController; //11.2. Accedemos al script arrowcontroller.
    private Transform transformArrowPoint; //11. Accedemos directamente al transform del go arrowpoint. //11.5. Accedemos al componente transform de este mismo GO que tiene el script, variable transformplayercontroller. //He eliminado el transformPlayerController porque tenía 2 instancias de él, una en shoot y otra en movement. Eliminé ésta y dejé solo la de movement.
    private Transform transformBombPoint; //24. Creamos estas 2 variables y abajo hacemos la búsqueda respectiva en el start
    [SerializeField] private GameObject prefabBomb;

    [Header("Player Dust")]
    [SerializeField] private GameObject dustJump; //13.3. Creamos un espacio para el prefab dustJump
    private Transform transformDustPoint; //13.4. Y para la transform del dustpoint.
    private bool isIdle, canDoubleJump; //14.2. Variable isIdle nueva. Ahora vamos al paso 15 donde crearemos el double jump. Creamos primero la nueva animación usando los sprites "roll" en el animation, luego las transiciones en el animator (con trigger como condición). Regresamos a este script y comenzaremos en el método jump(). Aunque primero creamos la nueva variable candoublejump aquí a continuación.  //15. Creamos nueva variable para el salto doble

    [Header("Player Dash")]
    [SerializeField] private float dashSpeed; //16.2. Creamos variables de dash
    [SerializeField] private float dashTime; //16.3
    private float dashCounter; //16.4. Y luego creamos la variable playerTransform arriba
    [SerializeField] private float waitForDash; //20. Creamos estas 2 variables y vamos al método dash
    private float afterDashCounter;

    [Header("Player Dash After Image")] //17. Creamos el prefab para el after image, y empezamos a trabajar aquí. 
    [SerializeField] private SpriteRenderer playerSR; //17.1. Creamos estas 4 variables
    [SerializeField] private SpriteRenderer afterImageSR;
    [SerializeField] private float afterImageLifeTime;
    [SerializeField] private Color afterImageColor;
    [SerializeField] private float afterImageTimeBetween; //18. Creamos estas 2 variables y vamos al método Dash()
    private float afterImageCounter;

    //Player Extras  //26.2. Llamamos a la clase playerextrastracker y vamos al awake.
    private PlayerExtrasTracker playerExtrasTracker;
    private void Awake()
    {
        playerExtrasTracker = GetComponent<PlayerExtrasTracker>(); //26.3. Asociamos el componente a esta variable. Ahora al Dash() a modificar un poco el if
        transformPlayerController = GetComponent<Transform>(); //16.6. Obtenemos el componente transform del player y lo asignamos a la variable playerTransform.
        playerRB = GetComponent<Rigidbody2D>(); //1.1. Que obtenga la instancia del rigidbody2d para poder acceder a sus funciones.

        //transformPlayerController = GetComponent<Transform>(); //11.6. Accedo al componente transform.de este GO y se lo asigno a transformPlayerController.
    }
    private void Start()
    {
        standingPlayer = GameObject.Find("StandingPlayer"); //21.1. Creamos estas 3 líneas.
        ballPlayer = GameObject.Find("BallPlayer");
        ballPlayer.SetActive(false);
        transformDustPoint = GameObject.Find("DustPoint").GetComponent<Transform>(); //13.5. Obtenemos el componente transform del go dustpoint, al igual que en el paso 11.1. Guardamos y en el editor conectamos el prefab dustjump al espacio que abrimos anteriormente en el paso 13.3. Está en el GO Player. Ahora vamos al paso 14 abajo, donde agregaremos el dust al movimiento lateral.
        transformArrowPoint = GameObject.Find("ArrowPoint").GetComponent<Transform>(); //11.1. Obtenemos el componente transform del GO arrowpoint.
        //checkGroundPoint = GameObject.Find("CheckGroundPoint").GetComponent<Transform>(); //2.5. Buscamos el GO CheckGroundPoint y su transform para almacenarlo en la variable checkGroundPoint. //29.2. Comentamos esta línea ya que ahora vamos a asignarlo en el editor por medio de un serialize. Hacemos lo mismo con el del bombcontroller
        transformBombPoint = GameObject.Find("BombPoint").GetComponent<Transform>(); //24.1. Buscamos el bombpoint. Ahora vamos al método shoot abajo
        animatorStandingPlayer = standingPlayer.GetComponent<Animator>(); //3.1. Con esto encontramos el componente animator en el hijo (Standing Player). //Corrección. Al usar la variable standingPlayer nos ahorramos unas búsqueda
        animatorBallPlayer = ballPlayer.GetComponent<Animator>(); //22.1. Buscamos el animator de ballplayer y se lo asignamos a la variable.
        IdSpeed = Animator.StringToHash("speed"); //3.6. Con estas 2 líneas convertimos los strings en ids.
        IdIsGrounded = Animator.StringToHash("isGrounded"); //3.7. Hacemos el del isgrounded. Y ya abajo podremos usar ids, así que comentaré los que tenían strings y agrego los nuevos pero usando estas ids.
        IdShootArrow = Animator.StringToHash("shootArrow"); //10.1. convertimos el string en id para ser usado luego
        IdCanDoubleJump = Animator.StringToHash("canDoubleJump"); //15.6. Inicializamos el id de doble salto. Ahora vamos al paso 16 para crear el movimiento dash en este mismo script.
    }
    void Update()
    {
        //Move(); //6. Optimizando el código, creamos este método move y movemos las líneas "float inputx" y "playerRB.velocity" dentro de su bloque de código. //16. El método dash va a llamar a move. Por eso lo comento y creo el método dash abajo con la llamada a move(). Y después de eso voy a crear las variables dash arriba
        Dash(); //16.1. Creo el método dash.
        Jump(); //6.1. Lo mismo que el anterior, creamos este método y movemos las líneas "isGrounded = Physics2D..." y "if (Input.GetButtonDown(jump)" dentro de su bloque.
        //CheckAndSetDirection(); //6.2. Lo mismo, tomamos las líneas "if (playerRB.velocity.x < 0)" y "else if (playerRB.velocity.x > 0)" se pasan a este bloque. 
        //SetAnimator(); //6.3. Lo mismo, pasando las líneas animator.SetFloat y animator.Setbool. Ahora vamos al script cameracontroller que colocamos a la cámara. //10.4. Las líneas de setanimator se colocaron en otros métodos y se eliminó setanimator, para optimizar el código, como se describe en el paso 10.3. //Comentado por los cambios del paso 11.
        CheckAndSetDirection(); //11.13. Cambiamos el nombre y asignamos el método a la variable isflipedinx. Este bool se encarga de comprobar si está normal en X o está girado. Ahora vamos abajo para usar el isflipedinX para verificar el giro de x en el if del shootarrow().
                                //Nota: También podríamos llamar directamente al método CheckAndSetDirection() como pasa con Jump() o ShootArrow(), en ese caso este metodo tendría que ser un void y quitaríamos su return. Pero por ahora lo dejaremos así ya que permite un poco más de flexibilidad en caso de que queramos o necesitemos hacer algo con la variable isFlippedInX. //Nota 2: Lo hemos eliminado, me refiero a la asignación "isFlippedInX = CheckAndSetDirection();" y ahora es un void que no tiene return.

        Shoot(); //10.2 Creamos método
        PlayDust(); //14.2. Llamamos al método playdust
        BallMode(); //21.2. Creamos este método y vamos a él.
    }
    private void Dash()
    {
        if (afterDashCounter > 0) //20.1. Si el dashcounter es mayor que 0, que reste tiempo. Si no, que ejecute el fire2 cuando se presiona. Así lo restringimos para que no se esté usando todo el tiempo. //26.4. Ahora al salto (Jump())
            afterDashCounter -= Time.deltaTime;
        
        else
        {
            if ((Input.GetButtonDown("Fire2") && standingPlayer.activeSelf) && playerExtrasTracker.CanDash)
            {
                dashCounter = dashTime; //Si apretamos el botón que está en Fire2 y el go standingplayer está activa y candash es true, el tiempo de ejecución de dashcounter será el de dashtime
                ShowAfterImage(); //17.2. Creamos este método
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime; //Si es mayor que 0, o sea que está activo, comenzamos a restarle tiempo al dash
            playerRB.velocity = new Vector2(dashSpeed * transformPlayerController.localScale.x, playerRB.velocity.y);
            afterImageCounter -= Time.deltaTime; //18.1 Restamos tiempo a la variable
            if (afterImageCounter <= 0) //Si pasó el tiempo de la "imagen viva" del dash
            {
                ShowAfterImage(); 
            }
            afterDashCounter = waitForDash; //20.2. Esta línea sirve para resetear el dashcounter a un tiempo de espera que yo defina. Guardamos y vamos al inspector para definir dicho tiempo en waitfordash. Ahora vamos a crear un GO para el modo bola y regresar a aquí para el paso 21.
        }
        else
        {
            Move(); //Si el dash no está activo en su totalidad, llamamos a move normal. Ahora vamos al editor a colocar los valores a las variables dash en los serializedfields.
        }
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && (standingPlayer.activeSelf))
        {
            ArrowController tempArrowController = Instantiate(arrowController, transformArrowPoint.position, transformArrowPoint.rotation); //11.3. Instantiate() Instanciamos a arrowController, en la posición de transformArrowPoint, y le pasamos la rotación quaternion de transformArrowPoint. Lo asignamos a una nueva variable temporal "tempArrowController" que vamos a usar para asignarlo en el editor. En el GO Player debería aparecer un espacio arrowcontroller. Ponemos ahí el prefab "PlayerArrow" que habíamos hecho antes. Ahora vamos al script arrowcontroller y eliminamos y comentamos el método start, que solo usábamos como text.

            if (isFlippedInX) //11.14. Usamos la variable isflippledinX para determinar si está o no girado en X. Y con esto terminamos esta sección. Ahora vamos a trabajar en el sistema de partículas. Creamos el prefab del sistema de partículas y regresamos al script arrowcontroller en el paso 12.
            {
                tempArrowController.ArrowDirection = new Vector2(-1, 0f);//11.7. Dependiendo hacia donde apunta el player en -1 de vector 2 (a la izquierda), la flecha saldrá disparada en ese lado
               tempArrowController.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                tempArrowController.ArrowDirection = new Vector2(1, 0f); //11.8. Si no, que sea igual a 1, osea al otro lado. Vamos al editor y aumento la velocidad del prefab del arrow de 10 a 17, mientras que en el GO player cambiamos la velocidad del player de 10 a 8 (lo ideal es que lanzar flechas tenga un pequeño delay entre uno y otro). Ahora el método CheckDirection lo llamaremos CheckAndSetDirection y devolverá un bool, así que tenemos que declararlo arriba.
            }
            animatorStandingPlayer.SetTrigger(IdShootArrow); //10.3. Llamamos al animator. Ahora por cuestión de orden vamos a mover las líneas que estaban en el método setanimator y eliminar dicho método. El animator.setbool irá al jump(), y el setfloat irá a move(). Ahora crearemos un GO vacío llamado ArrowPoint y lo colocamos como hijo de Player, y frente al GO. Luego vamos al punto 11. a crear las variables.
        }
        if ((Input.GetButtonDown("Fire1") && ballPlayer.activeSelf) && playerExtrasTracker.CanDropBombs) //24.2. Verifica si está echo bola y presiono el botón de disparo, pues que instancie el prafabbomb en la posición de transformbombpoint, sin rotación. Ahora vamos al editor a configurar, crear el bombpoint como go, asignar el prefab bomb al player si no lo he hecho, y ajustar la altura del bombpoint. Con eso debería ser suficiente. Ahora vamos a crear elementos destructibles con bombas en el editor y regresar al script bombcontroller en el paso 25.
           //26.7. Agregamos candropbomb al if y vamos al paso 27 creando el nuevo script UnlockExtras (antes modificamos un poco el GO del corazón que servirá como itempickup) 
        {
            Instantiate(prefabBomb, transformBombPoint.position, Quaternion.identity);
        }
    }

    private void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal") * moveSpeed; //1.2. Obtenemos el axis horizontal y lo asignamos a inputX para movernos en horizontal. No es necesario multiplicar por time.deltatime ya que el rigidbody2d.velocity se mueve por segundos.
        //Si usamos getaxis va a tener una pequeña aceleración/desaceleración en el movimiento. GetAxisRaw es más instantáneo. 
        playerRB.velocity = new Vector2(inputX, playerRB.velocity.y); //1.3. Accedemos al playerRB, a su propiedad velocity y decirle que es igual al X (inputX) y a Y (playerRB.velocity.y para que lo deje tal como está por default). Sigue poner jump en este script.
        if (standingPlayer.activeSelf) //22.2. Creamos estos if. Y ahora vamos a crear un efecto de bomba para el ball mode. Lo creamos con sprites y eso, y pasamos al paso 23 en el script nuevo bombcontroller (creamos sus transiciones del animator antes en el editor, y pasamos al script).
        {
            animatorStandingPlayer.SetFloat(IdSpeed, Mathf.Abs(playerRB.velocity.x));
        }
        if (ballPlayer.activeSelf)
        {
            animatorBallPlayer.SetFloat(IdSpeed, Mathf.Abs(playerRB.velocity.x));
        }
    }
    private void Jump()
    {
        //isGrounded = Physics2D.OverlapCircle(checkGroundPoint.position, isGroundedRange, selectedLayerMask); //2.8. Usaremos la posición (Vector2 point), el radio del círculo que voy a dibujar debajo del player (para comprobar si toca el suelo) (float radius) y el layermask con el que quiero que interactúe (int layerMask). Devuelve un bool. //26.5. Y agregamos candoublejump al if siguiente. Ahora al ballmode() //29.2. Comentamos esta línea para usar raycast en su lugar, pero sí sirve bien con overlapcircle, de hecho creo que se pueden usar ambos.
        isGrounded = Physics2D.Raycast(checkGroundPoint.position, Vector2.down, isGroundedRange, selectedLayerMask); //28. Usamos raycast como verificación adicional, antes creamos una variable isgroundedrange arriba en playermovement, serializada, para tener más control del número usando el inspector. Lo sustituimos también en el overlapcircle.
        if (Input.GetButtonDown("Jump") && (isGrounded || canDoubleJump && playerExtrasTracker.CanDoubleJump))
        { //2.1. Controlamos el salto con el botón seteado como jump.
          //2.9. Agregamos && isGrounded para verificar que si, el jugador presiona jump y está tocando el suelo, que salte. Al estar en el aire, el bool isGrounded será false y por ende no se cumple la condición y no me dejará saltar de más. Sigue eliminar la fricción con materials. Crear un 2d/physicsmaterial2d en el editor, y cambiarle la fricción a 0 en el inspector. Y vamos al GO ground y colocamos este material en el composite collider2d en la parte "Material". Y ya no tendrá fricción.
          //15.1. Agregamos una condición más "canDoubleJump" a este if. Ahora vamos a crear un nuevo if dentro de este if.

            if (isGrounded) //15.2. Creamos un if para instanciar las partículas de polvo con este nuevo salto y pasar a candoublejump a true.
            {
                canDoubleJump = true;
                Instantiate(dustJump, transformDustPoint.position, Quaternion.identity);
            }
            else
            {
                canDoubleJump = false;
                animatorStandingPlayer.SetTrigger(IdCanDoubleJump); //15.4. Llamamos al animator del doble salto. Hay que crear un nuevo id arriba (IdCanDoubleJump).
            }
            //Instantiate(dustJump, transformDustPoint.position, Quaternion.identity); //13.2. Instanciamos la posición del dust. Esto mostrará líneas rojas de error así que ahora vamos a crear sus respectivas referencias arriba.  //15.3. Vamos a mover esta línea al if de arriba, ya que ahora hay double jump.
            //2.3. Para evitar los saltos infinitos, creamos un GO hijo al player llamado CheckGroundPoint, y creamos un layer llamado ground para el ground (del grid).
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce); //2.2. Que X sea lo que tenga, y en Y será jumpForce. //13.1. Movemos esta línea dentro del bloque del if de jump.
        }
        animatorStandingPlayer.SetBool(IdIsGrounded, isGrounded);
    }
    private void CheckAndSetDirection()
    {
        if (playerRB.velocity.x < 0)//5. Hacer un flip del spriterenderer dará inconvenientes cuando ponga ataques o disparos después, así que cambiaremos toda la escala del GO Player para que todo gire al lado que debe.
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isFlippedInX = true; //11.10. Agregamos esta línea. Si el velocity del player es menor que 0, giro a -1 que es lo mismo que estar girado en X.
        }
        else if (playerRB.velocity.x > 0)
        {
            transform.localScale = Vector3.one;
            //5.1. Si usara if aquí, el personaje no se cambiaría si lo dejara de mover, y si usara else, el personaje automáticamente voltearía. Así que se debe usar else if.
            //5.2. Cambios adicionales en el editor: Quitamos el material physics 2d del ground, creamos uno nuevo llamado player y se lo ponemos al collider del player/standingplayer, fricción 0. También vamos a ground y cambiamos Geometry Type (Composite Collider 2D) a Polygons, y en el propio player/father cambio interpolate de none a interpolate para mejor detección de colisiones.
            isFlippedInX = false; //11.11. Y es lo contrario, si es mayor que 0, no está girado en X. 
        }
        //return isFlippedInX; //11.12. Regresamos el resultado del bool isflipedinX. Ahora vamos al update(). //Antes la funcion check era un bool, usábamos return isflippedinx y asignábamos la función checnandsetdirection() en el start, a isflippedinx, pero no es tan necesario así que lo comentaré.
    }
    /*private void SetAnimator()
    {
        //animator.SetFloat("speed", playerRB.velocity.x); //3.2. Procedemos a setear la velocidad (speed) que habíamos creado como float en el editor (parámetro). Utilizaremos la segunda sobrecarga, que requiere el nombre del parámetro (en este caso speed) y la velocidad, que en este caso es la velocidad del player en X (playerRB.velocity.x). Comentado para usar ids en lugar de strings
        //Como nota adicional, Unity no recomienda que usemos llamadas de strings, por eso es más recomendable usar ids. Para crear un id se debe transformar el string en un id, y luego usar la primera sobrecarga, que usa int ids.
        //animator.SetFloat(IdSpeed, Mathf.Abs(playerRB.velocity.x)); //4. Ahora vamos a solucionar el problema que hay donde al presionar a la izquierda no se cambia la animación a run porque se está convirtiendo el número a negativo (y por ende no cumple con la condición del parámetro). Para ello, hay que cambiar los negativos a positivos por medio de transformarlos en números absolutos, y eso se hace metiendo la velocidad dentro del método Mathf.Abs. Ahora vamos a hacer un flip para que mire al otro lado cuando corre.
        //animator.SetBool("isGrounded", isGrounded); //3.3. Seteamos el bool, al igual que como lo hicimos en el paso anterior. Con este par de líneas debería ligar el animator en el GO player al darle play, y debería hacer las animaciones. Recordar que todos los parámetros en las transiciones (se ven en vista normal, no vista debug) estén correctamente configurados tanto de ida como de vuelta si es necesario. Comentado para usar ids en lugar de strings
        //animator.SetBool(IdIsGrounded, isGrounded);
    }*/

    private void PlayDust() //14. Vamos a agregar el dust al movimiento lateral.
    {
        if (playerRB.velocity.x != 0 && isIdle) //14.1. Creamos nueva variable bool "isIdle" arriba arriba.
        {
            isIdle = false;
            if (isGrounded)
            {
                Instantiate(dustJump, transformDustPoint.position, Quaternion.identity);
            }
        }
        if (playerRB.velocity.x == 0)
        {
            isIdle = true;
        }
    }

    private void ShowAfterImage()
    {
        SpriteRenderer afterImage = Instantiate(afterImageSR, transformPlayerController.position, transformPlayerController.rotation); //17.3. En el momento en que instancie este componente, se instancia todo el prefab que está private serializado. Devuelve un sprite renderer. Lo guardamos en afterImage.
        afterImage.sprite = playerSR.sprite; //17.4. Esto reemplazará el sprite del player por el del player
        afterImage.transform.localScale = transformPlayerController.localScale; //17.5. Reemplazará el scale.
        afterImage.color = afterImageColor; //Cambia el color.
        Destroy(afterImage.gameObject, afterImageLifeTime); //17.6. Destruye el go después del tiempo que indique en el lifetime. Guardamos y agregamos los componentes respectivos en el player en el inspector. Ahora vamos arriba para el paso 18 sobre las imagenes de dash
        afterImageCounter = afterImageTimeBetween; //18.2. Se establece la diferencia de tiempo. De esta forma y en el método dash, yo soy quien define el tiempo que dura el afterimage. Ahora vamos al frameratecontroller para limitar la cantidad de frames a un número fijo independientemente de la plataforma de juego (vsync solo limita el framerate en pc, no en móvil).
    }
    private void BallMode()
    {//26.6. Agregamos canenterballmode al if, ahora al metodo shoot() arriba
        float inputVertical = Input.GetAxisRaw("Vertical"); //21.3. Creamos esta línea y nos aseguramos que el axes en vertical esté en Y axis (en el Input Manager).
        if ((inputVertical <= -.9f && !ballPlayer.activeSelf || inputVertical >= .9f && ballPlayer.activeSelf) && playerExtrasTracker.CanEnterBallMode) //Si estoy presionando hacia abajo y el ballPlayer está inactivo, que haga lo siguiente. O, si vertical está hacia arriba y ballplayer están activos, que haga lo siguiente.
        {
            ballModeCounter -= Time.deltaTime;
            if (ballModeCounter < 0)
            {
                ballPlayer.SetActive(!ballPlayer.activeSelf); //21.4. Si el tiempo es menor que 0, se enciende (o se apaga) el ballPlayer. Si está apagado se enciende, si está encendido se apaga. Lo mismo para el standingplayer
                standingPlayer.SetActive(!standingPlayer.activeSelf);
            }  
        }
        else ballModeCounter = waitForBallMode; //21.5. Si el tiempo no es suficiente para pasar a ballmode (o sea, que presioné el botón por error por ejemplo) que no active el ballmode. Que se active solo si se cumple el tiempo del waitforballmode (que yo defino en el inspector). Luego creamos la animación y conectamos las transiciones del ball mode en el editor. Y vamos arriba al paso 22.
    }

    private void OnDrawGizmos() //29. Llamamos a ondrawgizmos para poder ver los rangos. Luego vamos al script bombcontroller a hacer lo mismo.
    {
        Gizmos.DrawWireSphere(checkGroundPoint.position, isGroundedRange);
    }
}