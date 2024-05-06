using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectScalling : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool _isDragging;
    private float _currentScale;
    public float minScale, maxScale; // minScale and maxScale are limits of scaling
    private float _temp;
    private float _scalingRate = 2;

    private void Start()
    {
        _currentScale = transform.localScale.x;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.touchCount == 1)
        {
            _isDragging = true;
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        _isDragging = false;
    }


    private void Update()
    {
        if (_isDragging)
            if (Input.touchCount == 2)
            {
                transform.localScale = new Vector2(_currentScale, _currentScale);
                float distance = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                if (_temp > distance)
                {
                    if (_currentScale < minScale)
                        return;
                    _currentScale -= (Time.deltaTime) * _scalingRate;
                }

                else if (_temp < distance)
                {
                    if (_currentScale > maxScale)
                        return;
                    _currentScale += (Time.deltaTime) * _scalingRate;
                }

                _temp = distance;
            }

        float wheelInput = Input.GetAxis("Mouse ScrollWheel"); 
        if (wheelInput > 0)
        {
            _currentScale += _scalingRate;
        }
        else if (wheelInput < 0)
        {
            _currentScale -=  _scalingRate;
        }
    }
}