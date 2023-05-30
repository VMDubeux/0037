using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Complementar GameObject:")]
    public AudioClip _choiceSound;

    [Header("Private Variables:")]
    [SerializeField] private float _speed = 10.0f;

    // Not Serialized Private Variables:
    private Vector3 _startPos; // Initial position
    private Rigidbody _rbPlayer; // Rigidbody (Component)
    private AudioSource _audioPlayer; // Player Audio Source (Component)
    private float _horizontalBoard = 58.0f;

    void Start()
    {
        SettingGroundZero();
        Components();
    }

    void Update()
    {
        MovementInputsAndAppliedForces();
        CenarieBound();
    }

    private void SettingGroundZero()
    {
        _startPos = new Vector3(0, 2.5f, 16.25f);
        transform.position = _startPos;
    }

    private void Components()
    {
        _rbPlayer = GetComponent<Rigidbody>();
        _audioPlayer = GetComponent<AudioSource>();
    }

    void MovementInputsAndAppliedForces()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * _speed * Time.deltaTime, transform.position.y, transform.position.z);
        
        //float verticalInput = Input.GetAxis("Vertical");
        //_rbPlayer.AddForce(Vector3.right * horizontalInput * _speed * Time.deltaTime, ForceMode.Force);
        //_rbPlayer.AddForce(Vector3.forward * verticalInput * _speed * Time.deltaTime);
    }

    void CenarieBound()
    {
        if (transform.position.x < -58.0f) transform.position = new Vector3(-58.0f, transform.position.y, transform.position.z);
        else if (transform.position.x > 58.0f) transform.position = new Vector3(58.0f, transform.position.y, transform.position.z);
    }
}
