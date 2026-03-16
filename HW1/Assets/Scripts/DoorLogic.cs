using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLogic : MonoBehaviour
{
    public GameObject winPanel;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            WinGame();
        }
    }

    void WinGame()
    {
        winPanel.SetActive(true); // Show the GUI [cite: 45]
        Time.timeScale = 0f;    // Pause the game
        Cursor.lockState = CursorLockMode.None; // Unlock mouse for the buttons
        Cursor.visible = true;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}