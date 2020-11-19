using Core.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace DeveloperTest.DAL
{
    public static class LogItemHelper
    {
        private static readonly TypeHolder<LogItem> LogItemTypeHolder = new TypeHolder<LogItem>();

        private static List<LogItem> _all;
        public static List<LogItem> AllLogs
        {
            get
            {
                if (_all == null)
                {
                    lock (LogItemTypeHolder)
                    {
                        if (_all != null)
                            return _all;

                        // Hämta alla items från databas.
                        _all = LogItemTypeHolder.GetAll().OrderBy(logItem => logItem.Id).ToList();
                    }
                }

                return _all;
            }
        }

        public static bool Delete(int delId)
        {
            var logItem = Get(delId);

            if (logItem == null)
            {
                var sql = $"delete from {LogItemTypeHolder.TableName} where {LogItemTypeHolder.IdField} = @Id";
                var param = new[] { DataAdapter.GetNewParameter("@Id", delId) };
                return DataAdapter.sqlExec(sql, param) > 0;
            }
            else
            {
                logItem.Delete();
                return AllLogs.Remove(logItem);
            }
        }

        public static LogItem Get(int id)
        {
            return AllLogs.FirstOrDefault(logItem => logItem.Id == id);
        }

        public static IEnumerable<LogItem> Search(string freeText)
        {
            var compInfo = CultureInfo.InvariantCulture.CompareInfo;

            var searchablePropFuncs = new List<Func<LogItem, string>>
            {
                item => item.Question,
                item => item.User,
                item => item.Company,
                item => item.Answer
            };

            foreach (var logItem in AllLogs)
            {
                foreach (var getProp in searchablePropFuncs)
                {
                    var propData = getProp(logItem) ?? string.Empty;

                    if (compInfo.IndexOf(propData, freeText, CompareOptions.IgnoreCase) >= 0)
                    {
                        yield return logItem;
                    }
                }
            }
        }
    }
}