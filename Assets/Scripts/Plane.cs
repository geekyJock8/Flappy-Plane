using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour
{
    public float upForce;
    public Rigidbody2D rb2d;

    private bool isDead = false;

    void Start()
    {

    }

    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                rb2d.angularVelocity = 0.0f;
                transform.eulerAngles = new Vector3(0, 0, 75);
            }
            transform.Rotate(Vector3.back * 75 * Time.deltaTime);
        }
        IsPlaneOutOfScreen();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isDead = true;
        GameLogic.instance.PlaneCrashed();
    }

    void IsPlaneOutOfScreen()
    {
        if(this.transform.position.y < -6 || this.transform.position.y > 5.3)
        {
            GameLogic.instance.PlaneCrashed();
        }
    }
}