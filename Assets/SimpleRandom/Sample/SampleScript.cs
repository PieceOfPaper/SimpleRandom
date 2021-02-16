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
        if (m_GeneratedTexture == null) m_GeneratedTexture = new Texture2D(m_Size.x, m_Size.y);
        if (m_Randoms == null) m_Randoms = new float[m_Size.x, m_Size.y];

        long startTicks = System.DateTime.Now.Ticks;
        for (int y = 0; y < m_Size.y; y++)
        {
            for (int x = 0; x < m_Size.x; x++)
            {
                m_Randoms[x, y] = random.RandRate();
            }
        }
        long endTicks = System.DateTime.Now.Ticks;

        for (int y = 0; y < m_Size.y; y++)
            for (int x = 0; x < m_Size.x; x++)
                m_GeneratedTexture.SetPixel(x, y, Color.Lerp(Color.white, Color.red, m_Randoms[x, y]));
        m_GeneratedTexture.Apply();

        float avr = 0f;
        float powAvr = 0f;
        for (int y = 0; y < m_Size.y; y++)
        {
            for (int x = 0; x < m_Size.x; x++)
            {
                avr += m_Randoms[x, y];
                powAvr += m_Randoms[x, y] * m_Randoms[x, y];
            }
        }
        avr /= (m_Size.x * m_Size.y);
        powAvr /= (m_Size.x * m_Size.y);

        if (m_RawImage != null) m_RawImage.texture = m_GeneratedTexture;
        if (m_TextTime != null) m_TextTime.text = $"{random.GetType().Name} Time: {((endTicks - startTicks) / System.TimeSpan.TicksPerMillisecond)}ms\nAvr: {(avr * 100).ToString("f4")}, Vari: {((powAvr - (avr * avr)) * 100).ToString("f4")}";
    }

    public void ClearTexture()
    {
        if (m_GeneratedTexture != null)
            Destroy(m_GeneratedTexture);
        m_GeneratedTexture = null;
    }

    SimpleRandom.Random m_SystemRandom = new SimpleRandom.SystemRandom();
    public void DoRandom_SystemRandom()
    {
        GenerateTexture(m_SystemRandom);
    }

    SimpleRandom.Random m_UnityRandom = new SimpleRandom.UnityRandom();
    public void DoRandom_UnityRandom()
    {
        GenerateTexture(m_UnityRandom);
    }

    SimpleRandom.Random m_LCGRandom = new SimpleRandom.LCGRandom();
    public void DoRandom_LCGRandom()
    {
        GenerateTexture(m_LCGRandom);
    }

    SimpleRandom.Random m_MT19937Random = new SimpleRandom.MT19937Random();
    public void DoRandom_MT19937Random()
    {
        GenerateTexture(m_MT19937Random);
    }

    SimpleRandom.Random m_Well512Random = new SimpleRandom.Well512Random();
    public void DoRandom_Well512Random()
    {
        GenerateTexture(m_Well512Random);
    }

    SimpleRandom.Random m_XorShiftRandom = new SimpleRandom.XorShiftRandom();
    public void DoRandom_XorShiftRandom()
    {
        GenerateTexture(m_XorShiftRandom);
    }

    SimpleRandom.Random m_XorShift64Random = new SimpleRandom.XorShift64Random();
    public void DoRandom_XorShift64Random()
    {
        GenerateTexture(m_XorShift64Random);
    }

    SimpleRandom.Random m_XorShift128Random = new SimpleRandom.XorShift128Random();
    public void DoRandom_XorShift128Random()
    {
        GenerateTexture(m_XorShift128Random);
    }

    SimpleRandom.Random m_SubtractiveGeneratorRandom = new SimpleRandom.SubtractiveGeneratorRandom();
    public void DoRandom_SubtractiveGeneratorRandom()
    {
        GenerateTexture(m_SubtractiveGeneratorRandom);
    }
}
