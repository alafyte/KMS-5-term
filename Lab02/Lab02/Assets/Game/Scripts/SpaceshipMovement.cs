using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SpaceShipMovement : MonoBehaviour
{
    public int numberOfLives = 3;
    public float initialSpeed = 13.0f;
    public float tiltAmount = 20.0f;
    public float currentSpeed;
    public TMP_Text livesText;
    public TMP_Text introText;
    public TMP_Text pointsText;

    private double lastPosition = 8;
    private Rigidbody rb;
    private float minX = -15f;
    private float maxX = 15f;
    private List<int> alreadyCollidedWith = new List<int>();
    private bool gameStarted = false;
    private double points = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
    }

    private void Update()
    {
        if (!gameStarted)
        {
            if (Input.anyKeyDown)
            {
                gameStarted = true;
                currentSpeed = initialSpeed;
                rb.velocity = transform.forward * currentSpeed;
                introText.text = "";
            }
        }
        else
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(horizontalInput * currentSpeed * Time.deltaTime, 0.0f, 0.0f);

            float currentHeight = transform.position.y;

            transform.Translate(movement);

            Vector3 clampedPosition = transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
            transform.position = clampedPosition;

            Vector3 newPosition = new Vector3(transform.position.x, currentHeight, transform.position.z);
            transform.position = newPosition;


            float tilt = -horizontalInput * tiltAmount;

            transform.rotation = Quaternion.Euler(0, 0, tilt);

            points += transform.position.z - lastPosition;

            pointsText.text = "Очки: " + System.Math.Round(points).ToString();

            lastPosition = transform.position.z;

            rb.velocity = transform.forward * currentSpeed;

            Debug.Log(currentSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            int direction = Random.Range(0, 2) * 2 - 1;

            Rigidbody asteroidRb = collision.gameObject.GetComponent<Rigidbody>();
            asteroidRb.velocity = new Vector3(Random.Range(-1f, 1f), direction, Random.Range(-1f, 1f)).normalized * initialSpeed;

            if (!alreadyCollidedWith.Contains(collision.gameObject.GetInstanceID()))
            {
                --numberOfLives;

                if (points >= 20)
                    points -= 20;
                else
                    points = 0;
                livesText.text = "Жизни: " + numberOfLives;

                if (numberOfLives == 0)
                {
                    RestartGame();
                }
                alreadyCollidedWith.Add(collision.gameObject.GetInstanceID());
            }

            currentSpeed = 0;

            rb.velocity = Vector3.zero;


            StartCoroutine(IncreaseSpeedOverTime(initialSpeed, 3.0f));
        } 
        else if (collision.gameObject.tag == "Bonus")
        {
            Destroy(collision.gameObject);
            rb.velocity = transform.forward * currentSpeed;
            ++numberOfLives;
            livesText.text = "Жизни: " + numberOfLives;
        }
    }

    IEnumerator IncreaseSpeedOverTime(float targetSpeed, float duration)
    {
        float timeElapsed = 0.0f;
        float startSpeed = currentSpeed;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            currentSpeed = Mathf.Lerp(startSpeed, targetSpeed, timeElapsed / duration);

            rb.velocity = transform.forward * currentSpeed;
            yield return null;
        }

        currentSpeed = targetSpeed;
        rb.velocity = transform.forward * currentSpeed;

    }

    void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
