using InvestControl.Application.Interfaces.Common;

namespace CleanArqMvc.Infrastructure.Common
{
    public class SystemDateTime : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;

        public DateTime Today => DateTime.UtcNow.Date;
    }
}
