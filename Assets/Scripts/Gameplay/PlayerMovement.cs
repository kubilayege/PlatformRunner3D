using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Agent
{
    public Animator anim;
    public int place;
    public float speed;

    public Rigidbody rb;
    private float _speed;
    private Vector2 lastTouchPlace;
    private Vector2 currentDir;


    void Start()
    {
        currentDir = Vector2.zero;
        _speed = 5f;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    // Update is called once per frame
    void Update()
    {
        base.CheckPos();
        if (Input.GetMouseButtonDown(0))
        {
            if (!Helper.IsBrushState())
            {
                GameManager.main.game.Play();
                rb.isKinematic = false;
            }
            

            //if (!Helper.IsPlaying())
            //{
            //    GameManager.main.game.Play();
            //}

            lastTouchPlace = Input.mousePosition;
        }

        if (Helper.WinOrLoseState())
        {
            currentDir = Vector2.Lerp(currentDir, Vector2.zero, Time.deltaTime * _speed);

            Animate(currentDir);
        }


        if (!Helper.IsPlaying())
            return;


        if (Input.GetMouseButton(0))
        {
            Vector2 touchDir = (-lastTouchPlace + (Vector2)Input.mousePosition) / 50;
            currentDir = Vector2.Lerp(currentDir, (Vector2.ClampMagnitude(touchDir, 1)), Time.deltaTime * _speed);

            MovePlayer(currentDir);
        }

        if (!Input.GetMouseButton(0))
        {
            currentDir = Vector2.Lerp(currentDir, Vector2.zero, Time.deltaTime * _speed);

            Animate(currentDir);

        }

    }

    private void Animate(Vector2 animVector)
    {
        var horizontal = currentDir.x;
        var frontAxis = currentDir.y;


        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("FrontAxis", frontAxis);
    }

    public void MovePlayer(Vector2 currentDir)
    {
        if (currentDir.magnitude > 0.01f)
        {
            _speed = currentDir.magnitude * speed;
            Animate(currentDir);
            rb.MovePosition(transform.position + new Vector3(currentDir.x, 0, currentDir.y) * _speed * Time.deltaTime);
        }
    }
}
