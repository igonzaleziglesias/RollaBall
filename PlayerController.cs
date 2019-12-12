using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

GameObject enemy;
GameObject boton;
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
        enemy = GameObject.Find("Enemy");
        boton = GameObject.Find("Restart");
        boton.SetActive(false);
    }

    void FixedUpdate ()//actualizando la posicion de la bola(mover al centro si ganamos) 
    {   
        if(!winText.text.Equals("Gañaches meu!")){//si no ganamos(estamos jugando), movimiento de la bola
            float moveHorizontal = Input.GetAxis ("Horizontal");
            float moveVertical = Input.GetAxis ("Vertical");

            Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

            rb.AddForce (movement * speed);
        
        }else{
    
            gameObject.transform.position=Vector3.zero;//ganamos, posicionamos en el centro
        }
    
    }

    void OnTriggerEnter(Collider other) //ir recogiendo objetos
    {   //con pick ups
        if (other.gameObject.CompareTag ( "Pick Up"))
        {
            other.gameObject.SetActive (false);//los hacemos invisibles
            count = count + 1;//aumentamos el contador
            SetCountText ();
        }

        //con el enemigo
        if (other.gameObject.CompareTag ( "Enemy"))
        {
            winText.text = "Perdeches!!!";//actualizamos el mensaje de final de partida
            gameObject.SetActive (false);//hacemos daesaparecer la bola
            other.gameObject.SetActive(false);//hacemos invisible el enemigo
            boton.SetActive(true);//aparece el boton para volver a empezar
        }
    }

    void SetCountText ()//actualizar el contador
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 64)//condicion de victoria
        {
            winText.text = "Gañaches meu!";//mensaje de victoria
            enemy.gameObject.SetActive(false); //desactiva al enemigo
            boton.SetActive(true);       
        }
    }
}
