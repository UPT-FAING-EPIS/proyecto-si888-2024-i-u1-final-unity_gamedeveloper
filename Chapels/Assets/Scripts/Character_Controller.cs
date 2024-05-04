using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{

    public float velocidad;
    public float fuerzaSalto;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidBody;
    private bool mirandoDerecha=true;
    public LayerMask capaSuelo;
    private Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody=GetComponent<Rigidbody2D>();
        boxCollider=GetComponent<BoxCollider2D>();
        animator=GetComponent<Animator>();
    }

    bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit=Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y),0f,Vector2.down,0.2f,capaSuelo);
        return raycastHit.collider != null;
    }


    // Update is called once per frame
    void Update()
    {
        ProcesarMovimiento();
        ProcesarSalto();
    }

    void ProcesarSalto()
    {
        if (Input.GetKeyDown(KeyCode.Space) && EstaEnSuelo())
        {
            rigidBody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);

            float inputMovimiento = Input.GetAxis("Vertical");

            if (inputMovimiento != 0f)
            {
                animator.SetBool("isJumping", true);
            }
            else
            {
                animator.SetBool("isJumping", false);
            }
        }
    }



    void ProcesarMovimiento()
    {
        float inputMovimiento=Input.GetAxis("Horizontal");

        if (inputMovimiento != 0f)
        {
            animator.SetBool("isRunning",true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        rigidBody.velocity = new Vector2(inputMovimiento * velocidad, rigidBody.velocity.y);
        GestionarMovimiento(inputMovimiento);
    }
    void GestionarMovimiento(float inputmovimiento)
    {
        //Si se cumple condicióm
        if ((mirandoDerecha == true && inputmovimiento < 0) || (mirandoDerecha == false && inputmovimiento > 0))
        {
            //Ejecutar codigo de volteado 
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

    }

}
