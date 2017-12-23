using System;
using System.Collections.Generic;
using System.Linq;
using DLL.LogContext;
using Entity.Logs;
using Entity.UserModels;

namespace BLL.LogRepository
{
    public class UserLogService
    {

        private List<UserLog> GetUserLogs() => new UserLogRepository().Get();

        public int GetUserCount(Role role) => GetUserLogs().Count(r => r.Role == role);

        public int GetUserCount(Role role,DateTime date) => GetUserLogs().Count(r => r.Role == role
                                                                                     && r.LogDateTime.Day == date.Day
        );
    }
}
