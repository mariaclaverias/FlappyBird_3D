using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private ScoreSO score;
    [SerializeField]
    private AudioClipSO audioClip;

    private bool isDead = false;
    public bool IsDead => isDead;

    [SerializeField]
    private float jumpVelocity;
    [SerializeField]
    private float jumpRotate;
    [SerializeField]
    private float jumpRotateSpeed;


    private Rigidbody rb;
    private bool isGameStart = false;

    private void OnEnable()
    {
        GameManager.onStartGame += Setup;
    }

    private void OnDisable()
    {
        GameManager.onStartGame -= Setup;
    }

    private void Update()
    {
        if (isGameStart && !IsDead)
            PlayerMove();
    }

    private void Setup()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        InitPlayer();
    }

    public void InitPlayer()
    {
        isGameStart = !isGameStart;
        rb.useGravity = !rb.useGravity;
        rb.isKinematic = !rb.isKinematic;
    }

    public void PlayerMove()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                RotateHeadUp();
                rb.velocity = new Vector3(rb.velocity.x, jumpVelocity, 0);
                AudioSource.PlayClipAtPoint(audioClip.JumpAudio, transform.position);
            }
        }

        RotateHeadDown();
    }

    private void RotateHeadUp()
    {
        Quaternion newRotation = Quaternion.Euler(0, 0, jumpRotate);
        transform.rotation = newRotation;
    }

    private void RotateHeadDown()
    {
        Quaternion newRotation = Quaternion.Euler(0, 0, -jumpRotate);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, jumpRotateSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tube" ||
            collision.gameObject.tag == "Floor")
        {
            if (!isDead)
            {
                AudioSource.PlayClipAtPoint(audioClip.DeadAudio, transform.position);
                score.HighScore();
                isDead = true;
            }
            else
            {
                AudioSource.PlayClipAtPoint(audioClip.FallAudio, transform.position);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tube")
        {
            AudioSource.PlayClipAtPoint(audioClip.ScoreAudio, transform.position);
            score.UpdateScore();
        }
    }
}
