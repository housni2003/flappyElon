using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elonscript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float elonStrength;
    public LogicScript logic;
    public bool elonIsAlive = true;

    // Start is called before the first frame u;pdate
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && elonIsAlive)
        {
            myRigidbody.velocity = Vector2.up * elonStrength;
        }

        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        if (viewportPosition.x < 0 || viewportPosition.x > 1 ||
            viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            // The GameObject is outside the camera's view
            logic.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        elonIsAlive = false;
    }
}
