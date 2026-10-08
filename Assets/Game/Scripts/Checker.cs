using UnityEngine;

public class Checker : MonoBehaviour
{
    [SerializeField, Min(0)] private int _stepAmount;
    [SerializeField] private LayerMask _layerTeam;

    private void Awake()
        => transform.gameObject.layer = (int)Mathf.Log(_layerTeam.value, 2);

    public int GetStepAmount()
        => _stepAmount;
}