namespace Framework.framework.log
{
    public class UnityLog : ILog
    {
        public void Debug(string msg)
        {
            UnityEngine.Debug.Log(msg);
        }

        public void Warnning(string msg)
        {
            UnityEngine.Debug.LogWarning(msg);
        }

        public void Error(string msg)
        {
            UnityEngine.Debug.LogError(msg);
        }
    }
}