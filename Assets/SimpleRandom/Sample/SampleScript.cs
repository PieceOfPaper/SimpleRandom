using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleScript : MonoBehaviour
{
    public RawImage m_RawImage;
    public Vector2Int m_Size = Vector2Int.one * 100;
    public Text m_TextTime;

    float[,] m_Randoms;
    Texture2D m_GeneratedTexture;


    public void GenerateTexture(SimpleRandom.Random random)
    {
        ClearTexture();

        random.Init(System.DateTime.Now.Millisecond);
        m_GeneratedTexture = new Texture2D(m_Size.x, m_Size.y);
        m_Randoms = new float[m_Size.x, m_Size.y];

        long startTicks = System.DateTime.Now.Ticks;
        for (int y = 0; y < m_Size.y; y++)
            for (int x = 0; x < m_Size.x; x++)
                m_Randoms[x, y] = random.RandRange(0f, 1f);
        long endTicks = System.DateTime.Now.Ticks;

        for (int y = 0; y < m_Size.y; y++)
            for (int x = 0; x < m_Size.x; x++)
                m_GeneratedTexture.SetPixel(x, y, Color.Lerp(Color.white, Color.red, m_Randoms[x, y]));
        m_GeneratedTexture.Apply();

        float avr = 0f;
        for (int y = 0; y < m_Size.y; y++)
            for (int x = 0; x < m_Size.x; x++)
                avr += m_Randoms[x, y];
        avr /= (m_Size.x * m_Size.y);

        if (m_RawImage != null) m_RawImage.texture = m_GeneratedTexture;
        if (m_TextTime != null) m_TextTime.text = string.Format("{0} Time: {1:n0}ms\nAVR: {2:f4}", random.GetType().Name, (endTicks - startTicks) / System.TimeSpan.TicksPerMillisecond, avr * 100);
    }

    public void ClearTexture()
    {
        if (m_GeneratedTexture != null)
            Destroy(m_GeneratedTexture);
        m_GeneratedTexture = null;
    }

    public void DoRandom_SystemRandom()
    {
        GenerateTexture(new SimpleRandom.SystemRandom());
    }

    public void DoRandom_UnityRandom()
    {
        GenerateTexture(new SimpleRandom.UnityRandom());
    }

    public void DoRandom_MiddleSquareRandom()
    {
        GenerateTexture(new SimpleRandom.MiddleSquareRandom());
    }

    public void DoRandom_LCGRandom()
    {
        GenerateTexture(new SimpleRandom.LCGRandom());
    }

    public void DoRandom_MT19937Random()
    {
        GenerateTexture(new SimpleRandom.MT19937Random());
    }
}
