using UnityEngine;
using UnityEngine.UI;

public class FPSMonitor : MonoBehaviour
{
    public Text text;
    private int _fps;
    private int _frameRange = 120;
    [SerializeField]
    private int[] _fpsBuffer;
    private int _fpsBufferIndex;

    private void Update()
    {
        if(_fpsBuffer==null || _frameRange != _fpsBuffer.Length)
        {
            InitBuffer();
        }
        UpdateBuffer();
        CalculeteFps();  
    }

    private void InitBuffer()
    {
        if (_frameRange <= 0)
        {
            _frameRange = 30;
        }
        _fpsBuffer = new int[_frameRange];
        _fpsBufferIndex = 0;
    }
    private void UpdateBuffer()
    {
        _fpsBuffer[_fpsBufferIndex++] = (int)(1 / Time.unscaledDeltaTime);
        if(_fpsBufferIndex >= _frameRange)
        {
            _fpsBufferIndex = 0;
        }
    }
    private void CalculeteFps()
    {
        int sum = 0;
        for (int i = 0; i < _frameRange; i++)
        {
            sum += _fpsBuffer[i];
        }
        _fps = sum / _frameRange;
        text.text = _fps.ToString();
    }
}
