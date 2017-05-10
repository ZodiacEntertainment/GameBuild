using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class volcontrol : MonoBehaviour
{
    [SerializeField]
    private Slider mySlider;
    public void OnValueChanged()
    {
        AudioListener.volume = mySlider.value;
    }
}