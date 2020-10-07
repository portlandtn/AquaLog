using System.Collections.Generic;
using AquaLog.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace AquaLog.Data
{
    public class SqlLogData : ILogData
    {
        private readonly AquaLogDbContext _db;

        public SqlLogData(AquaLogDbContext db)
        {
            _db = db;
        }
        public Log Add(Log newLog)
        {
            _db.Add(newLog);
            return newLog;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public Log Delete(int id)
        {
            var log = GetById(id);
            if(log != null)
            {
                _db.Remove(log);
            }
            return log;
        }

        public IEnumerable<Log> GetLogsByDateRange(DateTime startDate, DateTime endDate)
        {
            var query = from l in _db.Logs
                        where (l.Date >= startDate && l.Date <= endDate)
                        orderby l.Id
                        select l;
            return query;
        }

        public Log GetById(int id)
        {
            return _db.Logs.Find(id);
        }

        public Log Update(Log updatedLog)
        {
            var entity = _db.Logs.Attach(updatedLog);
            entity.State = EntityState.Modified;
            return updatedLog;
        }

        public IEnumerable<Log> GetAllLogs()
        {
            var query = from l in _db.Logs
                        orderby l.Date
                        select l;
            return query;
        }
    }
}