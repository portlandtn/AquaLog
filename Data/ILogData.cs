using System;
using System.Collections.Generic;
using AquaLog.Core;

namespace AquaLog.Data
{
    public interface ILogData
    {
        IEnumerable<Log> GetLogsByDateRange(DateTime startDate, DateTime endDate);
        IEnumerable<Log> GetAllLogs();
        Log GetById(int id);
        Log Update(Log updatedLog);
        Log Add(Log newLog);
        Log Delete(int id);
        int Commit();
    }
}