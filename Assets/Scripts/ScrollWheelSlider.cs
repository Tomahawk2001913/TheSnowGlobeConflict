using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ScrollWheelSlider : MonoBehaviour {
    public float increment = 0.1f;

    private Slider slider;

    void Awake() {
        slider = GetComponent<Slider>();
    }

    void Update() {
        slider.value -= Input.mouseScrollDelta.y * increment;
    }
}
