using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderRenderer : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _health.HealthValue;
    }

    public void RenderSlider()
    {
        _slider.value = _health.HealthValue;
    }
}
