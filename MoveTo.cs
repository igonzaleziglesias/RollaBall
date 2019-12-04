   // MoveTo.cs
    using UnityEngine;
    using UnityEngine.AI;

    
    public class MoveTo : MonoBehaviour {
       
       public Transform goal;
       NavMeshAgent agent;

      // distancia mínima para cambiar la animacion
    public float proximidad;
    // el animator
    Animator animator;

    void Start () {
          
          agent = GetComponent<NavMeshAgent>();
            animator = goal.GetComponent<Animator>();
       }
       void Update(){
          agent.SetDestination( goal.position);

      if (!agent.pathPending && agent.remainingDistance < proximidad)
        {
            Debug.Log("Peligro");
            // cambiamos a true la variable del animator
            animator.SetBool("EstarEnPeligro", true);
        }
        else
        {
            Debug.Log("Tranqui");
            // cambiamos a false la variable del animator
            animator.SetBool("EstarEnPeligro", false);
        }
       }

    }
