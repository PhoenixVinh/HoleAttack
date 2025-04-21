using System;
using System.Threading.Tasks;
using _Scripts.Event;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColdownTime : MonoBehaviour, IPrecent
{
    
    public static ColdownTime Instance;
    
    
    private TMP_Text _txtDisplayTime;
    private Slider _slider;
    
    public float ColdownTimeComplete = 300;
    private float _timeColdown = 0;
    
    
    
    private bool isStartColdown = false;



    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _timeColdown = ColdownTimeComplete;
        _txtDisplayTime = transform.Find("LabelTime").GetComponent<TMP_Text>();
        _slider = transform.GetChild(1).GetComponent<Slider>();

    }


    public void OnEnable()
    {
        TimeEvent.OnFreezeTime += FreezeTime;
    }

    public void OnDisable()
    {
        TimeEvent.OnFreezeTime -= FreezeTime;
    }

    private async void FreezeTime(float time)
    {
        isStartColdown = false;
        await Task.Delay((int)time * 1000);
        isStartColdown = true;
    }

    private void FixedUpdate()
    {
        if(!isStartColdown) return;
        else
        {
            CalucalteTime();
        }
    }

    private void CalucalteTime()
    {
        if (_timeColdown >= 0)
        {
            _timeColdown -= Time.deltaTime;
        
            TimeSpan timeSpan = TimeSpan.FromSeconds(Mathf.CeilToInt(_timeColdown));
            this._txtDisplayTime.text =  string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
            _slider.value = Precent();
        }
        else
        {
            // Process when playe lose
        }
        
    }

    public float Precent()
    {
        return _timeColdown / ColdownTimeComplete;
    }


    [ContextMenu("Start Coldown")]
    public void StartColdown()
    {
        this.isStartColdown = true;
    }




    public void SetData(float levelTimeToComplete)
    {
        this.ColdownTimeComplete = levelTimeToComplete;
        this._timeColdown = ColdownTimeComplete;
        StartColdown();
    }

    public void AddTime(float timeAdd)
    {
        this._timeColdown += timeAdd;
    }
}