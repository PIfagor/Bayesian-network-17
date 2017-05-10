using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts;
using UnityEngine.UI;


public class SceneController : MonoBehaviour
{
    public Text         Question;
    public Dropdown     Options;
    public GameObject   OverWindow;
    public Text         OverText;
    public Image        OverIcon;

    private readonly List<Fact>         _facts      = new List<Fact>();
    private readonly List<Rule>         _rules      = new List<Rule>();
    private readonly List<FactItem>     _userFacts  = new List<FactItem>();
    private List<MatchItem>             _matches    = new List<MatchItem>();
    private int                         _currentIndex = -1;


    private void Start()
    {

        LoadFacts();

        LoadRules();

        //foreach (var fact in _facts)
        //{
        //    Debug.Log(fact);
        //}

        //foreach (var rule in _rules)
        //{
        //    Debug.Log(rule);
        //}

        ShowNextQuestion();
    }

    public void StartOver()
    {
        _currentIndex = -1;
        _userFacts.Clear();
        _matches.Clear();

        OverWindow.SetActive(false);
        ShowNextQuestion();
    }


    private void ShowNextQuestion()
    {
        _currentIndex++;

        Fact c = _facts[_currentIndex];

        Question.text = c.Name;
        Question.text += " ?";
        Options.options.Clear();

        foreach (var val in c.Values)
        {
            Options.options.Add(new Dropdown.OptionData() { text = val });
        }

        Options.value = 1;
        Options.value = 0;
    }


    public void NextBtnAction()
    {
        // save previous
        string name = Question.text;
        
        FactItem item = new FactItem(name.Substring(0, name.Length - 2), Options.options[Options.value].text);
        
        _userFacts.Add(item);

        if (_currentIndex == _facts.Count - 1)
        {
            CalcResult();

            OverWindow.SetActive(true);

            if (_matches.Count > 0)
            {
                string resVal = _matches[0].Rule.Value;

                TryLoadIcon(resVal);
                OverText.text = "Your transport is: " + resVal;
            }
            else
            {
                UseDefaultIcon();
                OverText.text = "Best transport not found, you better to walk";
            }

            foreach (var fact in _userFacts)
            {
                Debug.Log(fact);
            }

            Debug.Log("------------------");

            for (int i = 0; i < 3 && i < _matches.Count; ++i)
            {
                Debug.Log(_matches[i]);
            }
            Debug.Log("------------------");
        }
        else
        {
            ShowNextQuestion();
        }
    }

    private void CalcResult()
    {
        foreach (var rule in _rules)
        {
            Debug.Log(rule);
        }

        foreach (var rule in _rules)
        {
            int matchCount = 0;

            for (int i = 0; i < rule.Facts.Count; ++i)
            {
                //Debug.Log(rule.Facts.Count);
                FactItem item       = rule.Facts[i];
                //Debug.Log(item);
                //foreach (var userFact in _userFacts)
                //{
                //    print("["+userFact.Name +"] vs ["+ item.Name + "]");
                //}
               // FactItem userItem = _userFacts.FirstOrDefault(t => t.Name == item.Name);
                //if (userItem == null)
                //{
                //    continue;
                //}
                //if (i == 3)
                //return;
                FactItem userItem   = _userFacts.First(t => t.Name == item.Name);

                if (item.Value == userItem.Value)
                {
                    ++matchCount;
                }

                if (matchCount > 0)
                {
                    _matches.Add(new MatchItem(matchCount, rule));
                }
            }
        }

        _matches = _matches.OrderByDescending(m => m.ParamMatchCount).ToList();
    }

    private void LoadFacts()
    {
        var factsFile   = Resources.Load("facts") as TextAsset;
        var lines       = factsFile.text.Split('\n');

        foreach (var line in lines)
        {
            _facts.Add(Utils.FactFromStr(line));
        }
    }

    private void LoadRules()
    {
        var factsFile   = Resources.Load("rules") as TextAsset;
        var lines       = factsFile.text.Split('\n');

        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line.Trim()) == false)
            {
                _rules.Add(Utils.RuleFromStr(line.Trim()));
            }
        }
    }

    private void TryLoadIcon(string resName)
    {
        Sprite s = Resources.Load<Sprite>("Icons/" + resName);

        if (s != null)
        {
            OverIcon.sprite = s;
        }
        else
        {
            UseDefaultIcon();
        }
    }

    private void UseDefaultIcon()
    {
        Sprite s        = Resources.Load<Sprite>("Icons/cat");
        OverIcon.sprite = s;
    }

}
