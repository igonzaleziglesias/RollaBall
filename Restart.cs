using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	// Use this for initialization
	public void ReStart () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

}
