using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer renderer;

    private bool canDash = true;
    private bool isDashing = false;
    private float dashingPower = 7f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    private Rigidbody2D rb;
    private TrailRenderer trail;

    private bool canBite = true;
    [SerializeField] private GameObject attack;
    [SerializeField] private Color leftButton, rightButton;
    private float biteDistance = 2.5f;

    [SerializeField] private GameObject[] hearts = new GameObject[3];
    private int health = 3;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
        health = 3;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")));
        }
        if (Input.GetMouseButton(0) && canBite)
        {
            StartCoroutine(Bite(leftButton));
        }
        if (Input.GetMouseButton(1) && canBite)
        {
            StartCoroutine(Bite(rightButton));
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void Damage()
    {
        if (!isDashing && health>0)
        {
            health--;
            hearts[health].GetComponent<Image>().color = new Color(hearts[health].GetComponent<Image>().color.r, hearts[health].GetComponent<Image>().color.g, 
                hearts[health].GetComponent<Image>().color.b, 100/255f);
        }
    }

    private void Movement()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.position += new Vector3(speed, 0, 0) * Input.GetAxis("Horizontal") * Time.deltaTime;
            if (Input.GetAxis("Horizontal") > 0)
                renderer.flipX = false;
            if (Input.GetAxis("Horizontal") < 0)
                renderer.flipX = true;
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.position += new Vector3(0, speed, 0) * Input.GetAxis("Vertical") * Time.deltaTime;
        }
    }

    private IEnumerator Dash(float directionX, float directionY)
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower * directionX, transform.localScale.y * dashingPower * directionY);
        trail.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        trail.emitting = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        rb.velocity = new Vector2(0f, 0f);
    }

    private IEnumerator Bite(Color color)
    {
        Debug.Log("Bite color: " + color);

        canBite = false;

        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 heading = new Vector2();
        float dist;
        Vector2 direct = new Vector2();
        Vector2 bitePlace = new Vector2();
        GameObject g = new GameObject();
        if (Vector2.Distance(mouseWorld, transform.position) > biteDistance)
        {
            heading = mouseWorld - new Vector2(transform.position.x, transform.position.y);
            dist = heading.magnitude;
            direct = heading / dist;
            bitePlace = direct * biteDistance + new Vector2(transform.position.x, transform.position.y);
            g = Instantiate(attack, bitePlace, Quaternion.identity);
        }
        else if (Vector2.Distance(mouseWorld, transform.position) < biteDistance)
        {
            g = Instantiate(attack, mouseWorld, Quaternion.identity);
        }

        g.GetComponent<SpriteRenderer>().color = color;

        Collider2D[] enemies = Physics2D.OverlapCircleAll(g.transform.position, 1.1f);
        DoDamage(enemies, color);
        Destroy(g, 0.25f);

        yield return new WaitForSeconds(0.7f);
        canBite = true;
        
        Debug.Log(mouseWorld);
    }

    private void DoDamage(Collider2D[] e, Color c)
    {
        foreach(Collider2D col in e)
        {
            Debug.Log("Cicle " + col.tag);
            if (col.tag == "Enemy" && col.GetComponent<Enemy>().color.Equals(c) == true)
            {
                Debug.Log("Equal colors");
                col.GetComponent<Enemy>().TakeDamage();
            }
                
        }
    }
}
