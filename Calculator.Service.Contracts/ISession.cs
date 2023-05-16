namespace Calculator.Service.Contracts
{
    public interface ISession
    {
        void Refuse();
        void Allow();
    }
}