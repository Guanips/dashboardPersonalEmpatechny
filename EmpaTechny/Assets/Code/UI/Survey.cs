using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class Survey : MonoBehaviour
{
    public static Survey Instance { get; private set; }

    public GameObject[] surveyPages; // Páginas de la encuesta (vincular en el Inspector)
    public Button[] optionButtons;   // Botones de selección (siempre 5)
    public Button confirmButton;     // Botón de confirmar respuesta

    public TMP_Text questionText;
    private List<int> answers = new List<int>();  // Lista de respuestas
    private int currentPage = 0;
    private int selectedAnswer = -1; // Para controlar la opción seleccionada

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        questionText.SetText("---");
        ShowCurrentPage();

        // Asigna eventos a los botones de opción
        for (int i = 0; i < optionButtons.Length; i++)
        {
            int index = i + 1; // Opciones van del 1 al 5
            optionButtons[i].onClick.AddListener(() => SelectAnswer(index));
        }

        // Asigna evento al botón de confirmar
        confirmButton.onClick.AddListener(ConfirmAnswer);
    }

    private void ShowCurrentPage()
    {
        Debug.Log("Mostrando página: " + currentPage);

        for (int i = 0; i < surveyPages.Length; i++)
        {
            surveyPages[i].SetActive(i == currentPage);
        }

        selectedAnswer = -1; // Reiniciar selección
    }

    public void SelectAnswer(int answer)
    {
        selectedAnswer = answer;
        Debug.Log("Opción seleccionada: " + answer);
    }

    private void ConfirmAnswer()
    {
        if (selectedAnswer == -1) return; // No permitir avanzar sin responder

        answers.Add(selectedAnswer);
        selectedAnswer = -1; // Reiniciar selección antes de avanzar
        currentPage++;

        if (currentPage < surveyPages.Length)
        {
            Debug.Log("Siguiente pregunta: " + currentPage);
            ShowCurrentPage();
        }
        else
        {
            Debug.Log("Encuesta terminada");
            SendSurveyResults(); // Enviar los resultados
        }
    }

    private void SendSurveyResults()
    {
        // Serializa el array de respuestas a JSON
        string json = JsonUtility.ToJson(new SurveyData(answers));
        StartCoroutine(PostResults(json));
    }

    private IEnumerator PostResults(string jsonData)
    {
        string url = "https://backend-dashboard-empatechny.onrender.com/post_pisoreporte"; // Cambia a la URL de tu API
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Resultados enviados con éxito: " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("Error al enviar resultados: " + request.error);
        }
    }
}

// Clase que encapsula las respuestas
[System.Serializable]
public class SurveyData
{
    public List<int> answers; // Lista de respuestas numéricas

    public SurveyData(List<int> answers)
    {
        this.answers = answers;
    }
}
