using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UIElements;


public class PLAYER_INVENTORY : MonoBehaviour
{

    public Transform playerPos;





    public List<GameObject> Inventory = new List<GameObject>();
    public PlayerInputs playerInputActions;
    public InputAction ScrollingEvent;
    private int currentIndex = 0;
    private int scrollValue;
    private int previousIndex;
    private Transform Item;
    private GameObject instantiatedItem;

    public Camera rightHandCam;
    public AudioClip[] scrollSounds;
    private AudioSource audioSource;
    private int soundOrder = 0;








    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    private void Update()
    {
        if (Inventory[currentIndex].tag == "Hose")
        {
            foreach (GameObject item in Inventory)
            {
                item.SetActive(false);
            }
            Inventory[currentIndex].SetActive(true);
        }
        if (Inventory[currentIndex].tag == "Hammer")
        {
            foreach (GameObject item in Inventory)
            {
                item.SetActive(false);
            }
            Inventory[currentIndex].SetActive(true);
        }
        if (Inventory[currentIndex].tag == "Glue")
        {
            foreach (GameObject item in Inventory)
            {
                item.SetActive(false);
            }
            Inventory[currentIndex].SetActive(true);
        }
        if (Inventory[currentIndex].tag == "Umbrella")
        {
            foreach (GameObject item in Inventory)
            {
                item.SetActive(false);
            }
            Inventory[currentIndex].SetActive(true);
        }
    }

    private void Awake()
    {
        playerInputActions = new PlayerInputs();
    }

    private void OnEnable()
    {
        ScrollingEvent = playerInputActions.InGame.Scrolling;
        ScrollingEvent.Enable();
        ScrollingEvent.performed += Scroll;
    }
    private void OnDisable()
    {
        ScrollingEvent.Disable();
        ScrollingEvent.performed -= Scroll;
    }




    private void Scroll(InputAction.CallbackContext context)
    {
        scrollValue = MathF.Sign(ScrollingEvent.ReadValue<float>());

        if (scrollValue < 0)
        {
            currentIndex = (int)Mathf.Repeat(currentIndex - 1, Inventory.Count);
            audioSource.PlayOneShot(scrollSounds[soundOrder]);
            soundOrder = (int)Mathf.Repeat(soundOrder - 1, scrollSounds.Length);
            Debug.Log("left in the inventory");
            Debug.Log(currentIndex);

        }
        if (scrollValue > 0)
        {
            currentIndex = (int)Mathf.Repeat(currentIndex + 1, Inventory.Count);
            audioSource.PlayOneShot(scrollSounds[soundOrder]);
            soundOrder = (int)Mathf.Repeat(soundOrder + 1, scrollSounds.Length);
            Debug.Log("right in the inventory");
            Debug.Log(currentIndex);

        }
    }
}