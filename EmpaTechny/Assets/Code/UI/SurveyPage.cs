using UnityEngine;

public class SurveyPage : MonoBehaviour
{
    public string question; // Pregunta de la encuesta

    private void Start()
    {
        Display();
    }

    // Mostrar la pregunta en pantalla
    public void Display()
    {
        Survey.Instance.questionText.SetText(question);

        // Asegurar que los botones responden correctamente
        for (int i = 0; i < Survey.Instance.optionButtons.Length; i++)
        {
            int answerIndex = i + 1;
            Survey.Instance.optionButtons[i].onClick.RemoveAllListeners();
            Survey.Instance.optionButtons[i].onClick.AddListener(() => Survey.Instance.SelectAnswer(answerIndex));
        }
    }
}
