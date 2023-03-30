using System;
using System.Text.Json;
using Web_Api_Computer_Shop.Entities;
using Web_Api_Computer_Shop.Enum;
using Web_Api_Computer_Shop.Repository;

namespace Web_Api_Computer_Shop.Helper
{
    public class HistoryLogHelper<T>
    {
        public string GenerateDecription(Guid Id, EAction action, T data)
        {
            return $"User whose id is {Id} {action} {typeof(T).ToString().Replace("Web_Api_Computer_Shop.Entities.", "")} with data is {JsonSerializer.Serialize(data)}";
        }
        public string GenerateDecriptionError(Guid Id, EAction action)
        {
            return $"User whose id is {Id} {action} {typeof(T).ToString().Replace("Web_Api_Computer_Shop.Entities.", "")} is Failed";
        }
        public HistoryLog ExcutedSaveHistoryLog(Guid UserId, EAction action, T oldData, T newData, ETypeTable typeTable)
        {
            var newJson = JsonSerializer.Serialize(newData);
            var oldJson = JsonSerializer.Serialize(oldData);
            var historyLog = new HistoryLog(GenerateDecription(UserId, action, newData), UserId, action, oldJson.ToString(), newJson.ToString(), EStatus.SUCCESS, typeTable);
            return historyLog;
        }
        public HistoryLog ExcutedSaveHistoryLogError(Guid UserId, EAction action, ETypeTable typeTable)
        {
            var historyLog = new HistoryLog(GenerateDecriptionError(UserId, action), UserId, action, null, null, EStatus.FAILES, typeTable);
            return historyLog;
        }
    }
}
