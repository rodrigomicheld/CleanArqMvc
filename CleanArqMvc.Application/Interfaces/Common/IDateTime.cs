namespace InvestControl.Application.Interfaces.Common
{
    public interface IDateTime
    {
        DateTime Now { get; }
        DateTime Today { get; }
    }
}