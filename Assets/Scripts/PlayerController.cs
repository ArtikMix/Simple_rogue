using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer renderer;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 15f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    private Rigidbody2D rb;
    private TrailRenderer trail;

    private bool canBite = true;
    [SerializeField] private GameObject attack;
    [SerializeField] private Color leftButton, rightButton;

    [SerializeField] private GameObject[] hearts = new GameObject[3];
    private int health = 3;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
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

    private void Damage(int damage)
    {
        if (!isDashing)
        {
            health -= damage;
            hearts[health].SetActive(false);
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
        canBite = false;
        GameObject g = Instantiate(attack, transform.position, Quaternion.identity);
        g.GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.5f);
        canBite = true;
        Destroy(g, 0.1f);
    }
}
