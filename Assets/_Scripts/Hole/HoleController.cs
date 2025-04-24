using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Hole;
using DG.Tweening;

using UnityEngine;


public enum SpecialSkill
{
    IncreaseRange = 0, 
    Magnet = 1,
    Direction = 2, 
    FreezeColdown = 3,
}


public class HoleController : MonoBehaviour
{
    public static HoleController Instance;
    
    [Header("Variables")]
    public float _speedMovement;
    public float _radious;


    
    
    private HoleMovement _holeMovement;
    public HoleMovement HoleMovement => _holeMovement;

    //public BlackHole _blackHole;


    private HoleLevel _holeLevel;
    public HoleLevel HoleLevel => _holeLevel;


    private HoleSpecialSkill _holeSpecialSkill;
    [SerializeField] private LevelManager _levelManager;
    
    private void Awake()
    {
        Instance = this;
        _holeMovement = GetComponent<HoleMovement>();
        //_blackHole = GetComponent<BlackHole>();
        _holeLevel = GetComponent<HoleLevel>();
        _holeSpecialSkill = GetComponent<HoleSpecialSkill>();
        SetData();
    }

    

    private void SetData()
    {
        _holeMovement.SetSpeedMovement(_speedMovement);
    }


    public void OnUpLevelHole()
    {
       // this._blackHole.changeInitialScale(this.transform.localScale.x);
    }


    public void LoadLevel(int amountExp, float radius)
    {
        Vector3 localScale = transform.localScale;
        Vector3 newScale = new Vector3(radius, localScale.y, radius);
        // Update Scale of Hole 



        this.transform.DOScale(newScale, 1f).OnUpdate(
            () =>  OnUpLevelHole());
       
        
        this._holeLevel.SetData(amountExp);
    }
    
    
    
    
    
    
    
    

    public void ProcessSkill(int index)
    {
        SpecialSkill skill = (SpecialSkill)index;
        this._holeSpecialSkill.ProcessSkill(skill);
    }

    public float GetCurrentScale()
    {
        return this.transform.localScale.x; 
    }

    public float GetCurrentRadius()
    {
        return _levelManager.GetScalelevel();
    }

    
    // private  IncreaseRangeCoroutine()
    // {
    //     float timeIncrease = 20f; 
    // }
    public void SetPosition(Vector3 position)
    {
        this.transform.position = position;
        this._holeSpecialSkill.StopEventSkill();
        //this._levelManager.ResetLevel();
        
    }

    public void Reset()
    {
        this._levelManager.ResetLevel();
    }

    public bool IsProcessSkill(int index)
    {
        return this._holeSpecialSkill.UsingSkill(index);
    }
}
