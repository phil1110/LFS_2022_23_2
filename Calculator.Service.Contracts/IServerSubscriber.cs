namespace Calculator.Service.Contracts
{
    public interface IServerSubscriber
    { 
        void Log(string calc);
        void SetQuarantine(ISession session);
    }
}
