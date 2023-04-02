namespace Framework.framework.log
{
    public interface ILog
    {
        void Debug(string msg);
        void Warnning(string msg);
        void Error(string msg);
    }
}