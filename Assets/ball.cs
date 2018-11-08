using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ball : MonoBehaviour {

    public Rigidbody player;
    public float speed;
    public static float GlobalGravity = -9.8f;
    public float gravityScale = 1.0f;
    private bool isforce = false;
    private static float maxVelocity = 6f;

	// Use this for initialization
	void Start ()
    {
        player = GetComponent<Rigidbody>();
        player.useGravity = false;
	}

    void FixedUpdate()
    {
        Vector3 gravity = GlobalGravity * gravityScale * Vector3.up;
        player.AddForce(gravity, ForceMode.Acceleration);
        if (isforce)
        {
            force();
        }
        player.velocity = Vector3.ClampMagnitude(player.velocity, maxVelocity);
    }

    void force ()
    {
        isforce = false;
        player.AddForce(Vector3.up * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update ()
    {
		if(isforce)
        {
            force();
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        isforce = true;

        if(collision.gameObject.tag == "RedHelixPiece")
        {
            Restart();
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
