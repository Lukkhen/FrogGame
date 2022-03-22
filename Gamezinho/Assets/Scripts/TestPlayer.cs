using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public Animator anim;
    public float speed;
    private Vector3 moveDelta;
    private BoxCollider2D boxCollider;
    private RaycastHit2D hit;

    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {    // Aqui pega os x e y pelos comandos do teclado
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x, y, 0);

        // transform.Translate(moveDelta * Time.deltaTime); //MOVENDO 
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

    // Update is called once per frame
    void Update()
    {
       
    }
}
