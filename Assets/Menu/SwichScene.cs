using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwichScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void SwitchToMain()
    {
        SceneManager.LoadScene("Main");
    }
}
