using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MovementController : MonoBehaviour
{

    public CharacterController controller;

    [Header("Movement properties")]
    public float maxSpeed = 5.0f;
    public float gravity = -30.0f;
    public float jumpHeight = 3.0f;
    public Vector3 velocity;

    public GameObject pausePanel;
    [Header("Ground Detection")]
    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;
    public bool isGrounded;

    [Header("Animation")]
    private Animator anim;

    public static bool isPaused;
    public static int elixirCount, boosterCount, shieldCount;
    public static bool ShieldActivated,ShieldInUse;
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        Cursor.visible = true;
    }

    private void CheckForWin()
    {
        if (elixirCount == 11 && boosterCount == 3)
            SceneManager.LoadScene("Win");

    }
    private void IfShieldIsOn()
    {
        if(ShieldActivated)
        {
            ShieldInUse = true;
            ShieldActivated = false;
            print("Inuse");
            StartCoroutine(shiledDuration());
        }
    }
    IEnumerator shiledDuration()
    {
        yield return new WaitForSeconds(10.0f);
        ShieldInUse = false;
        print("DoneUse");
    }
    // Update is called once per frame
    void Update()
    {
        CheckForWin();
        IfShieldIsOn();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            isPaused = true;
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        if (!Shooting.IsReloading)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            //if (x != 0 || z != 0)
            //{

            //    if (GetComponent<AudioSource>().isPlaying == false)
            //    {

            //        GetComponent<AudioSource>().Play();
            //    }
            //}
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * maxSpeed * Time.deltaTime);
            anim.SetFloat("Velocity", Vector3.Magnitude(controller.velocity));
            //if (Input.GetButton("Jump") && isGrounded)
            //{

            //    velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);

            //}
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
    public void OnResume()
    {
        isPaused = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}
