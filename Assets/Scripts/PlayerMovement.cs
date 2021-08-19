using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float playerMoveSpeed;
    public float PlayerBackwardSpeed;
    public float turnSpeed,jumpForce;
    Animator anim;
    AudioManager audioManager;
    public Text scoreText;
    [SerializeField]
    public int score ;
    public bool groundCheck;
  
    public GameObject particleEffectsPrefab;
    public static PlayerMovement instance;
    
    // Start is called before the first frame update
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalMovement = Input.GetAxis("Horizontal");
        var verticalMovement = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontalMovement, 0, verticalMovement);
        anim.SetFloat("Speed", verticalMovement);
        transform.Rotate(Vector3.up, horizontalMovement * turnSpeed * Time.deltaTime);

        if (verticalMovement != 0)
        {
            float moveSpeed = (verticalMovement > 0) ? playerMoveSpeed : PlayerBackwardSpeed;
            characterController.SimpleMove(transform.forward * verticalMovement * moveSpeed);

        }
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            transform.Translate(Vector3.up*jumpForce*Time.deltaTime);
        }


        scoreText.text = "Score : " + score;
    }
   
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Coin"))
            {
                audioManager.PlayAudio("Coin");
                Destroy(other.gameObject);
                score = score + 1;
                Instantiate(particleEffectsPrefab, transform.position, Quaternion.identity);
            }

            if (other.gameObject.CompareTag("Heart"))
            {
            SceneManager.LoadScene(5);
            }


            else if (other.gameObject.CompareTag("coin"))
            {
                audioManager.PlayAudio("Coin");
                Destroy(other.gameObject);
                score = score + 5;
                Instantiate(particleEffectsPrefab, transform.position, Quaternion.identity);
            }

            if (other.gameObject.CompareTag("terrain"))
            {
            groundCheck = true;
            }

            if (other.gameObject.CompareTag("Health"))
            {
            Destroy(other.gameObject);
            UIController.instance.healthSlider.value = Health.instance.startHealth;
            UIController.instance.healthText.text = "Health" + Health.instance.currentHealth;
            }

        }



    }
   
    
