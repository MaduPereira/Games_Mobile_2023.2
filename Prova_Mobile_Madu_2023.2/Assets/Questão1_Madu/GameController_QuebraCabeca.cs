using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController_QuebraCabeca : MonoBehaviour
{
    public GameObject text1, text2;
    public static int contFigures = 8;
    public Text contPecas;
    void Start()
    {
        text1.SetActive(true); 
        text2.SetActive(false);
    }

    void Update()
    {
        if(contFigures > 0)
        {
            contPecas.text = "";
            contPecas.text = "Faltam " + contFigures.ToString() + " peças";
        }


        if (contFigures == 0)
        {
            text1.SetActive(false);
            text2.SetActive(true);
        }
    }
}
