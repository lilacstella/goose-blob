using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Guilt {  get; private set; }
    [SerializeField] Vector2 _guiltRange = new Vector2(-50, 100);
    [SerializeField] Color32 _guiltColorRangeMax, _guiltColorRangeMin;
    [SerializeField] CanvasGroup _gameManagerCanvas;
    [SerializeField] Image _guiltIndicator;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);
    }

    public void Start()
    {
        UpdateVisualGuiltIndicator();
    }

    private void Update()
    {
        
    }

    public void ResetGameManager()
    {
        Guilt = 0;
    }

    public void AddGuilt(int guilt)
    {
        Guilt += guilt;
        UpdateVisualGuiltIndicator();
    }

    public void ToggleGUIVisibility(bool visible)
    {
        if (visible) { _gameManagerCanvas.gameObject.SetActive(true); }
        else { _gameManagerCanvas.gameObject.SetActive(false); }
    }

    public void UpdateVisualGuiltIndicator()
    {
        float g = Mathf.InverseLerp(_guiltRange.x, _guiltRange.y, Guilt);
        _guiltIndicator.color = Color.Lerp(_guiltColorRangeMin, _guiltColorRangeMax, g);
    }
}
