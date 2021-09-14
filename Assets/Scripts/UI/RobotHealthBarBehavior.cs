using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotHealthBarBehavior : MonoBehaviour
{
    [SerializeField]
    private HealthBehavior _health;

    [SerializeField]
    private Image _fill;

    [SerializeField]
    private Gradient _healthGradient;

    [SerializeField]
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _health.Health;
        
        _fill.color = _healthGradient.Evaluate(1f);

    }
    private void Update()
    {
        _slider.value = _health.Health;
        _fill.color = _healthGradient.Evaluate(_slider.value / _slider.maxValue);
    }
}
