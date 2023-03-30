using System.Collections.Generic;
using Web_Api_Computer_Shop.Entities;

namespace Web_Api_Computer_Shop.Repository
{
    public interface IHistoryLogRepository
    {
        List<HistoryLog> GetAllHistoryLog();
        List<HistoryLog> GetAllHistoryLogByDateTime(string datetime);
        void AddHistoryLog(HistoryLog historyLog);
    }
}
