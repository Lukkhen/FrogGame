using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public Animator anim;
   public float speed;
   //float xInput, yInput;

    private BoxCollider2D boxCollider;
    private Vector3 moveDelta; // vector moveDelta mostra qual a diferença de localização do player entre o frame atual e o proximo a ser renderizado
    private RaycastHit2D hit; //casts player colider box

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

    }

    private void FixedUpdate()
    {
        
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

       // Resetar MoveDelta (voltar ao 0)
       moveDelta = new Vector3(x,y,0);

        // Y AXIS - Make sure we can move in this direction, by casting a box there first, if the box returns null, we're free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking")); //Impossible to go where the box hit
        if (hit == null) //significa que podemos sim mover
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking")); //Impossible to go where the box hit
        if (hit == null) //significa que podemos sim mover
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
    // Start is called before the first frame update MUDEI O NOME PQ NÃO TAVA INDO COM 2 VOID START
    void Start1()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f); //Faz as animações pra cada lado
        anim.SetFloat("Horizontal", moveDelta.x);
        anim.SetFloat("Vertical", moveDelta.y);
        anim.SetFloat("Speed", moveDelta.magnitude);

        //transform.position = transform.position + movement * speed * Time.deltaTime;
        

    }
}
