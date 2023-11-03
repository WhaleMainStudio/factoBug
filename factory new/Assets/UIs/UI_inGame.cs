using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_inGame : MonoBehaviour
{
   [SerializeField] private Slider timeSpeedSlider;

    public void updateTimeSpeedSlider(int _value)
    {
        timeSpeedSlider.value = _value;
    }

}
