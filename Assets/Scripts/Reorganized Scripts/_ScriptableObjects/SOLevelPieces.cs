using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOLevelPieces : ScriptableObject
{
   public  ArtManager.ArtType artType;
   public List<LevelPieceBase> levelPieces;

   public int pieceNumber;
}
