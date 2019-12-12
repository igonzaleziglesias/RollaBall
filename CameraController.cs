using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    void Start ()//posicion de la camara
    {
        offset = transform.position - player.transform.position;
    }
    
    void LateUpdate ()//ectualizar la posicion de la camara para que siga a la bola
    {
        transform.position = player.transform.position + offset;
    }
}
