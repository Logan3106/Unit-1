using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ending : MonoBehaviour
{
    // Start is called before the first frame update
    public void Playagain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
}
