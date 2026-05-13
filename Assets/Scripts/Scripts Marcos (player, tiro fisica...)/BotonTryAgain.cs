using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonTryAgain : MonoBehaviour
{
    public void TryAgain()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("NIVEL");
    }
}
