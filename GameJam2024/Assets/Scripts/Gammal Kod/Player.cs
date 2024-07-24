using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField] private float runSpeed = 40;
    [SerializeField] private int money;
    float horizontalMove = 0;
    bool jump = false;
    public bool crouch = false;

    [SerializeField]private Rigidbody2D rb2D;
    [SerializeField]private CharacterController2D controller;

    //Referens till animatorn
    [SerializeField]private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); //hämtar spelarens rigidbody
        controller = GetComponent<CharacterController2D>(); //hätar lite stulen kod som gör att karaktären kan gå
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            anim.SetBool("IsCrouching", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            anim.SetBool("IsCrouching", false);
        }

    }

    public void OnLanding()
    {
        anim.SetBool("IsJumping", false);
    }

    // Update is called at fixed intevalls
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }

    
}
