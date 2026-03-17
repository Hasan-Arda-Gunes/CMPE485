using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapDemo : MonoBehaviour {

    //This script goes on the SpikeTrap prefab;

    public Animator spikeTrapAnim; //Animator for the SpikeTrap;
    public bool isOpen = false;
    public GameObject loseUI;

    // Use this for initialization
    void Awake()
    {
        //get the Animator component from the trap;
        spikeTrapAnim = GetComponent<Animator>();
        //start opening and closing the trap for demo purposes;
        StartCoroutine(OpenCloseTrap());
    }


    IEnumerator OpenCloseTrap()
    {
        while (true) // Cleaner way to loop indefinitely
        {
            // Open Trap
            spikeTrapAnim.SetTrigger("open");
            isOpen = true;
            yield return new WaitForSeconds(2f);

            // Close Trap
            spikeTrapAnim.SetTrigger("close");
            isOpen = false;
            yield return new WaitForSeconds(2f);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isOpen)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        loseUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}