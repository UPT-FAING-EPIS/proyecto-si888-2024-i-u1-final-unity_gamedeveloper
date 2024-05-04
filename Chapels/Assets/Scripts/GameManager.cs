using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public HUD hud;
    private int vidas = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Mas de un Gamager en escena.");
        }
    }

    public void PerderVida()
    {
        vidas -= 1;
        if(vidas == 0)
        {
            SceneManager.LoadScene(0);
        }
        hud.DesactivarVida(vidas);
       
    }

    public bool RecuperarVida()
    {
        if(vidas == 3)
        {
            return false;
        }
        hud.ActivarVida(vidas);
        vidas += 1;
        return true;
    }


}
