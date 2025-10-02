using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private InputSystem_Actions action;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        action = new InputSystem_Actions();
        action.GameOver.Restart.started += Restart;
        action.Enable();
    }

    void Restart(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("SampleScene");
    }
    private void OnDestroy()
    {
        action.GameOver.Restart.started -= Restart;
        action.Disable();
    }
}
