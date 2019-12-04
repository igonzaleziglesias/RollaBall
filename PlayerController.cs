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

    void FixedUpdate ()
    {   
        if(!winText.text.Equals("Gañaches meu!")){
            float moveHorizontal = Input.GetAxis ("Horizontal");
            float moveVertical = Input.GetAxis ("Vertical");

            Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

            rb.AddForce (movement * speed);
        
        }else{
    
            gameObject.transform.position=Vector3.zero;
        }
    
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ( "Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }


        if (other.gameObject.CompareTag ( "Enemy"))
        {
            winText.text = "Perdeches!!!";
            gameObject.SetActive (false);
            other.gameObject.SetActive(false);
            boton.SetActive(true);
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 64)
        {
            winText.text = "Gañaches meu!";
            enemy.gameObject.SetActive(false); 
            boton.SetActive(true);       
        }
    }
}