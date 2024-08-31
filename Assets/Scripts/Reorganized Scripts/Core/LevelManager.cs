using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;
    
    public List<GameObject> level;
    private GameObject _currentLevel;
    [SerializeField] private int _index;
    
    [Header("Pieces")]
    public SOLevelPieces SOlevelPiece;
    public List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();
    
    public ArtManager.ArtType artType;

    public float TimeBetweenPieces = .3f;
    



    private void Awake(){

    if (SOlevelPiece.levelPieces.Count == 0)
    {
        Debug.LogError("levelPieces está vazia no início.");
    }
    else
    {
        Debug.Log($"levelPieces tem {SOlevelPiece.levelPieces.Count} elementos.");
    }
    CreateLevelPieces();
    
    }

    private void SpawnLevel(){
        //currentLevel.transform.localPosition = Vector3.zero;
        if (_currentLevel != null){
            Destroy(_currentLevel);
            _index++;

            if (_index >= level.Count){
                ResetLevelIndex();
            }

        }

        _currentLevel = Instantiate(level[_index], container);
        //_currentLevel.transform.position = _lastLevel.endPiece.position;

    }


    private void ResetLevelIndex(){
        _index = 0;
    }

    private void Update (){
        if(Input.GetKeyDown(KeyCode.D)){
           // SpawnLevel();
           
           CreateLevelPieces();
        }
    }

   
    private void CreateLevelPieces(){
        
        CleanSpawnedPieces();
        StartCoroutine(CreateLevelPiecesCourotine());
    }

    
    IEnumerator CreateLevelPiecesCourotine(){
       
        
        
        for (int i = 0; i< SOlevelPiece.pieceNumber; i++ ){
            
            CreateLevelPiece();
           yield return new WaitForSeconds(TimeBetweenPieces);
           ColorManager.Instance.ChangeColorByType(artType);
            
        }
    }


    private void CreateLevelPiece(){

        
            if (SOlevelPiece.levelPieces.Count == 0)
        {
            Debug.LogError("A lista levelPieces está vazia. Não é possível criar um piece.");
            return;
        }

        var piece = SOlevelPiece.levelPieces[Random.Range(0, SOlevelPiece.levelPieces.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if (_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
            spawnedPiece.transform.position = lastPiece.endPiece.position;
            Vector3 newPosition = new Vector3(0, 0, spawnedPiece.transform.position.z);
            spawnedPiece.transform.position = newPosition;
        }
        else{
            spawnedPiece.transform.localPosition = Vector3.zero;
        }

        foreach(var p in spawnedPiece.GetComponentsInChildren<ArtPiece>()){
            p.ChangePiece(ArtManager.Instance.GetSetupByType(SOlevelPiece.artType).gameObject);
        }

        _spawnedPieces.Add(spawnedPiece);
    
    }

    private void CleanSpawnedPieces(){

        for (int i = _spawnedPieces.Count - 1 ; i >= 0 ;  i-- ){
            Destroy(_spawnedPieces[i].gameObject);
        }

        _spawnedPieces.Clear();
    }

    }

