using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonProbar : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene("PvETest");
    }
}
