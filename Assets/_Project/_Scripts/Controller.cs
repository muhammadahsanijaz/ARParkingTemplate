using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;
using Image = UnityEngine.UI.Image;

public class Controller : MonoBehaviour
{
    public static Controller Instance;

    public GameObject WinDialog, LoseDialog, PauseMenu;

    public Transform Vehicle;
    public PlaneFinderBehaviour planeFinder;
    bool isPlaced = false;
    Rigidbody vehicleRigidbody;
    public Image working;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        vehicleRigidbody = Vehicle.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!isPlaced)
        {
            working.color = Color.red;
        }
        else
        {
            working.color = Color.green;
        }
    }
    public void ChangeISKinematic(bool f)
    {
        vehicleRigidbody.isKinematic = f;
    }

    public void TestPlaced()
    {
        isPlaced = false;
    }

    public void PlaneFinderCall(Vector2 screenPos)
    {
        if (!isPlaced)
        {
            isPlaced = true;
            planeFinder.PerformHitTest(screenPos);
        }
    }

    public void isFailed()
    {
        vehicleRigidbody.isKinematic = true;
        LoseDialog.SetActive(true);
    }

    public void isSuccess()
    {
        vehicleRigidbody.isKinematic = true;
        WinDialog.SetActive(true);
    }

    public void NotIsPlaced()
    {
        isPlaced = false;
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomeScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }



    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }

}
