using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemigo_volador : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] GameObject player;
    AIPath myPath;
    Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        myPath = GetComponent<AIPath>();
        myAnim = GetComponent<Animator>();

    }

    IEnumerator MiCorutina()
    {

        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);



    }

    // Update is called once per frame
    void Update()
    {
        //Alternativa 1 vector2,distance
        //float distancia = Vector2.Distance(transform.position, player.transform.position);
        // Debug.Log("distancia del jugador: " + distancia);
        //Debug.DrawLine(transform.position, player.transform.position, Color.red);

        //Alternativa 2 overcicle

        Collider2D col = Physics2D.OverlapCircle(transform.position, 5f, LayerMask.GetMask("Player"));

        if (col != null)
        {
            myPath.isStopped = false;
        }
        else
            myPath.isStopped = true;



    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisionando : " + collision.gameObject.name);
        if (collision.gameObject.name == "Bullet(Clone)")
        {

            life = life - 1;

        }
        if (life == 0)
        {
            myAnim.SetBool("isMuerte", true);
            StartCoroutine(MiCorutina());


        }
    }





}
