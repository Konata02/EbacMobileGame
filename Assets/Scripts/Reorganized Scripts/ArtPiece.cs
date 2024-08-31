using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtPiece : MonoBehaviour
{
    public GameObject _currentArt;

    public void ChangePiece(GameObject piece){
        if (_currentArt != null) Destroy(_currentArt);
        _currentArt = Instantiate(piece, transform);
        _currentArt.transform.localPosition = Vector3.zero;
    }

}
