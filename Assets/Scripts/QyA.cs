using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QyA : MonoBehaviour
{
    public TMP_Text preguntaTexto;
    public TMP_Text[] botonesTexto;
    public Button[] botones;
    public TMP_Text resultado;
    Color ColorCorrect = new Color32(73, 243, 145, 170);
    Color ColorIncorrect = new Color32(186, 64, 66, 170);
    Color[] coloresOriginales;
    [Serializable]
    public class Pregunta
    {
        public string texto;
        public string[] respuestas;
        public int correcta;
    }
    public Pregunta[] preguntas;
    int preguntaActual = 0;
    // Start is called before the first frame update
    public void Start()
    {
        coloresOriginales = new Color[botones.Length];
        for (int i = 0; i < botones.Length; i++)
        {
            coloresOriginales[i] = botones[i].image.color;
        }
        MostrarPregunta();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MostrarPregunta()
    {
        preguntaTexto.text = preguntas[preguntaActual].texto;

        for (int i = 0; i < botonesTexto.Length; i++)
        {
            botonesTexto[i].text = preguntas[preguntaActual].respuestas[i];
            botones[i].interactable = true;
            botones[i].image.color = coloresOriginales[i];
        }
    }

    public void Responder(int opcion)
    {
        if(opcion == preguntas[preguntaActual].correcta)
        {
            Debug.Log("Correcto");
        }
        else
        {
            Debug.Log("Incorrecto");
        }
        foreach (Button boton in botones)
        {
            boton.interactable = false;
        }

        int correcta = preguntas[preguntaActual].correcta;
        if (opcion == correcta)
        {
            botones[opcion].image.color = ColorCorrect;
        }
        else
        {
            botones[opcion].image.color = ColorIncorrect;
            botones[correcta].image.color = ColorCorrect;
        }
        StartCoroutine(SiguientePregunta());
    }

    IEnumerator SiguientePregunta()
    {
        yield return new WaitForSeconds(2f); // Espera 2 segundos

        preguntaActual++;

        if (preguntaActual < preguntas.Length)
        {
            MostrarPregunta();
        }
        else
        {
            Debug.Log("Juego terminado");
        }
    }
}
