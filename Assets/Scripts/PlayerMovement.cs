using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float playerMoveSpeed;
    public float PlayerBackwardSpeed;
    public float turnSpeed;
    Animator anim;
    AudioManager audioManager;
    public Text scoreText;
    [SerializeField]
    private int score;
    public GameObject particleEffectsPrefab;



    // Start is called before the first frame update
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
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
        scoreText.text = "Score : " + score;
        //Quaternion direction = Quaternion.LookRotation(movement);
        //transform.rotation = Quaternion.Slerp(transform.rotation, direction, Time.deltaTime * turnSpeed); ;


    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            score = score + 1;
            Instantiate(particleEffectsPrefab, transform.position, Quaternion.identity);
        }


        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            score = score + 5;
            Instantiate(particleEffectsPrefab, transform.position, Quaternion.identity);
        }
        
    }
    
}