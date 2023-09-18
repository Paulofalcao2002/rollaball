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
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        timer = 10;
        initialPosition = new Vector3(0, 0.5f, 0);

        SetCountText();
        SetTimerText();
    }

    void Update() 
    {
        timer -= Time.deltaTime;
        SetTimerText();

        if (transform.position.x < -10 || transform.position.x > 10 ||
            transform.position.z < -10 || transform.position.z > 10)
        {
            transform.position = initialPosition;
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Points: " + count.ToString();
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
            PlayerPrefs.SetInt("Score", count);
            int maxScore = PlayerPrefs.GetInt("MaxScore", 0);

            if (count > maxScore)
            {
                PlayerPrefs.SetInt("MaxScore", count);
            }

            PlayerPrefs.Save();
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
