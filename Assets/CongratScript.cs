using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;

    private List<string> _textToDisplay;
    private float _rotatingSpeed;
    private float _timeToNextText;

    private int _currentText;

    // Start is called before the first frame update
    void Start()
    {
        _timeToNextText = 0.0f;
        _currentText = 0;

        _rotatingSpeed = 100f;

        _textToDisplay = new List<string>
        {
            "Congratulation",
            "All Errors Fixed",
            "WeeeHuuu!",
            "Well Done!"
        };

        Text.text = _textToDisplay[0];

        SparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        RotateObject(SparksParticles.gameObject, Vector3.up);
        RotateObject(gameObject, Vector3.right);

        _timeToNextText += Time.deltaTime;

        if (_timeToNextText >= 1f)
        {
            _timeToNextText = 0.0f;

            if (_currentText >= _textToDisplay.Count - 1)
            {
                Text.text = _textToDisplay[_currentText];
                _currentText = 0;
            }
            else
            {
                Text.text = _textToDisplay[_currentText];
                _currentText++;
            }
        }
    }

    private void RotateObject(GameObject gameObject, Vector3 direction)
    {
        gameObject.transform.Rotate(direction * _rotatingSpeed * Time.deltaTime);
    }
}