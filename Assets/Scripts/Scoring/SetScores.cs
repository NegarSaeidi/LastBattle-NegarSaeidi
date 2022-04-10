using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SetScores : MonoBehaviour
{
    public static float oxygen;
    public static int Elixir;
    public static int Booster;
    public static int Shield;
    public TextMeshProUGUI oxygen_text;
    public TextMeshProUGUI elixir_text;
    public TextMeshProUGUI booster_text;
    public TextMeshProUGUI shield_text;

    void Start()
    {
        oxygen_text.text = OxygenController.time/OxygenController.totalTime *100+ "%";
        elixir_text.text = MovementController.elixirCount.ToString();
        booster_text.text =MovementController.boosterCount.ToString();
        shield_text.text = MovementController.shieldCount.ToString();
    }

  
}
