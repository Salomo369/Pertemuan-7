///////////////////////////////////////////////////////////////////
///                     ScoreData.cs
///   Stores score and global game data, also to reset them all.
///////////////////////////////////////////////////////////////////
public class ScoreData
{
    public static int m_P1Score;
    public static int m_P2Score;
    public static int MaxScoreToWin = 7;

    public static void ResetData()
    {
        m_P1Score = 0;
        m_P2Score = 0;
    }
}