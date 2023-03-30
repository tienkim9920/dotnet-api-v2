using System;
using System.Collections.Generic;
using System.Linq;
using Web_Api_Computer_Shop.Entities;
using Web_Api_Computer_Shop.Repository;

namespace Web_Api_Computer_Shop.Services.Admin
{
    public class HistoryLogService : IHistoryLogRepository
    {
        private ComputerShopDBContext context;
        public HistoryLogService(ComputerShopDBContext context)
        {
            this.context = context;
        }
        public void AddHistoryLog(HistoryLog historyLog)
        {
            if (historyLog == null) { throw new Exception("Model is null"); }
            else
            {
                context.HistoryLog.Add(historyLog);
                context.SaveChanges();
            }
        }

        public List<HistoryLog> GetAllHistoryLog()
        {
            return context.HistoryLog.ToList();
        }

        public List<HistoryLog> GetAllHistoryLogByDateTime(string datetime)
        {
            return context.HistoryLog.Where(x => x.Created_Date.ToString("dd/MM/yyyy") == datetime).ToList();
        }
    }
}
