using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonTryAgain : MonoBehaviour
{
    public void TryAgain()
    {
        SceneManager.LoadScene("NIVEL");
    }
}
