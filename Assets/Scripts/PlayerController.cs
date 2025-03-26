using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int score = 0;
    public float speed = 5f, maxSpeed = 20f, jumpForce;
    public float turnSpeed, horizotalMove, jumpInput;
    public Rigidbody rb;
    public bool isGrounded, gameOver;
    public GameObject startBtn, gameEndPanel;
    public Text scoreText, gameEndScore;

    //public Vector3 movement = new Vector3 (0, 0, 1);
    /*private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }*/
    // Update is called once per frame
    private void FixedUpdate()
    {
        jumpInput = Input.GetAxis("Jump");
        if (jumpInput > 0 && isGrounded)
        { rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z); }
    }
    void Update()
    {
        if (gameOver == false) // equal to false when user click Play/Start button
        {
            if (speed < maxSpeed)
            { speed = speed + (.5f * Time.deltaTime); }

            // countinuousely move player forward
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            // Turn player left/right
            horizotalMove = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizotalMove);
            //rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            // implement jump on player
            
        }
    }
    //
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    //
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            score++;
            scoreText.text = score.ToString();
            Debug.Log(" Score : " + score);
            Debug.Log(" Trigger with coin");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Enemy")
        {
            //gameOver = true;
            StopGame();
        }
    }
    //
    //
    public void StopGame()
    {
        gameOver = true;
        gameEndScore.text = score.ToString();
        gameEndPanel.SetActive(true);

    }
    public void StartGame()
    {
        startBtn.SetActive(false);
        gameOver = false;
    }
    //
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}                       //------------ Vector3.right = (1,0,0)
                        //------------ Vector3.left = (-1,0,0)\
