using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    void Update () //anima los pick ups haciendolos rotar con un inclinacion
    {
        transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
    }
}
