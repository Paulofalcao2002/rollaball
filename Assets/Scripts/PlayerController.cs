using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement; 

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI timerText;

    private int count;
    private float timer;
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        timer = 10;

        SetCountText();
        SetTimerText();
    }

    void Update() 
    {
        timer -= Time.deltaTime;
        SetTimerText();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    void SetTimerText()
    {
        string newText = "Time: " + timer.ToString("0");
        if (newText != timerText.text)
        {
            timerText.text = newText;
        }
        if (timer <= 0)
        {
            SceneManager.LoadScene("Scenes/ReplayMenu");
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;

            FindObjectOfType<AudioManager>().Play("Pickup");
            FindObjectOfType<Spawner>().SpawnCollectible();

            timer += 3f;

            SetCountText();
        }
    }
}
