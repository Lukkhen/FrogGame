using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerStats))]
public class Player : MonoBehaviour
{
    public PlayerStats player;
    public Animator anim;
   public float speed;

    Rigidbody2D rb2D;
    Vector2 movement = Vector2.zero;
   private BoxCollider2D boxCollider;
   private Vector3 moveDelta; // vector moveDelta mostra qual a diferença de localização do player entre o frame atual e o proximo a ser renderizado
   //private RaycastHit2D hit; //casts player colider box

    private void Start()
    {
      boxCollider = GetComponent<BoxCollider2D>();
      rb2D = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerStats>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

       // Resetar MoveDelta (voltar ao 0)
       moveDelta = new Vector3(x,y,0);

       //transform.Translate(moveDelta * Time.deltaTime);

        // Y AXIS - Make sure we can move in this direction, by casting a box there first, if the box returns null, we're free to move
        //hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking")); //Impossible to go where the box hit
        //if (hit != null) //significa que podemos sim mover
        //{
        //    return;
        //}else
        //{
        //    transform.Translate(moveDelta.y * Time.deltaTime, 0, 0);
        //}

        //hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking")); //Impossible to go where the box hit
        //if (hit == null) //significa que podemos sim mover
        //{
        //    transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        //}else
        //{
        //    transform.Translate(moveDelta * Time.deltaTime);
        //}
        movement = new Vector2(x, y);
        rb2D.MovePosition(rb2D.position + movement * player.entity.speed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Horizontal", moveDelta.x);
        anim.SetFloat("Vertical", moveDelta.y);
        anim.SetFloat("Speed", moveDelta.magnitude);
        
        //animações pra cada lado
    }
}
