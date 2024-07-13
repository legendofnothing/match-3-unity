using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTime : LevelCondition
{
    private float m_time;

    private GameManager m_mngr;

    private const float _interval = 1f;

    public override void Setup(float value, Text txt, GameManager mngr)
    {
        base.Setup(value, txt, mngr);

        m_mngr = mngr;

        m_time = value;
        
        UpdateText();

        StartCoroutine(TimerRoutine());
    }
    
    protected override void UpdateText()
    {
        if (m_time < 0f) return;

        m_txt.text = string.Format("TIME:\n{0:00}", m_time);
    }

    private IEnumerator TimerRoutine() {
        while (!m_conditionCompleted) {
            yield return new WaitForSeconds(_interval);
            
            if (m_mngr.State != GameManager.eStateGame.GAME_STARTED) continue;
            m_time -= _interval;
            UpdateText();
                
            if (m_time <= -1f) {
                OnConditionComplete();
            }
        }

        yield return null;
    }
}
