using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GameObject CanvasInicio;
    public GameObject CanvasCreditos;
    public GameObject CanvasTutorial;
    
    void Start()
    {
        CanvasInicio.SetActive(true);
        CanvasCreditos.SetActive(false);
        CanvasTutorial.SetActive(false);
    }

    public void MostrarCreditos()
    {
        CanvasCreditos.SetActive(true);
        CanvasInicio.SetActive(false);
        CanvasTutorial.SetActive(false);
    }

    public void MostrarTutorial()
    {
        CanvasTutorial.SetActive(true);
    }

    public void CerrarTutorial()
    {
        CanvasTutorial.SetActive(false);
    }

    public void CerrarCreditos()
    {
        CanvasCreditos.SetActive(false);
        CanvasInicio.SetActive(true); 
    }

    public void Jugar()
    {
        CanvasInicio.SetActive(false);
        CanvasCreditos.SetActive(false);
        CanvasTutorial.SetActive(false);
        Debug.Log("play");
    }
}
