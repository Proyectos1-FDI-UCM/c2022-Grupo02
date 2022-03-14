using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    #region parameters
    [SerializeField]
    float followSpeed = 1, yPos;
    #endregion

    #region references
    [SerializeField]
    Transform _targetTransform;
    Transform _myTransform;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = _targetTransform.position;
        Vector2 newPos = Vector2.Lerp(_myTransform.position, targetPos, followSpeed * Time.deltaTime);

        _myTransform.position = new Vector3(newPos.x, newPos.y + yPos, -15f);
    }
}
