using System.Diagnostics;
// 로그를 찍을떄 주로 하는거
// 1. 현재 이 로그가 발생된 시간
// 2. 로그 메시지
public static class Logger // 래핑클래스를 만든다.
{
    [Conditional("DEV_VER")]
    public static void Log(string msg) // 일반 로그 
    {
        UnityEngine.Debug.LogFormat("[{0}] {1}", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), msg);
    }
    [Conditional("DEV_VER")]
    public static void LogWarning(string msg) // 경고 로그 
    {
        UnityEngine.Debug.LogWarningFormat("[{0}] {1}", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), msg);
    }
    [Conditional("DEV_VER")]
    public static void LogError(string msg) // 에러 로그
    {
        UnityEngine.Debug.LogErrorFormat("[{0}] {1}", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), msg);
    }
}
