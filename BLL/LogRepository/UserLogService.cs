﻿using System;
using System.Collections.Generic;
using System.Linq;
using DLL.LogContext;
using Entity.Logs;
using Entity.UserModels;

namespace BLL.LogRepository
{
    public class UserLogService
    {

        private List<UserLog> GetUserLogs()
        {
            return new UserLogRepository().Get();
        }

        public int GetUserCount(Role role)
        {
            return GetUserLogs().Count(r => r.Role == role);
        }

        public int GetUserCount(Role role,DateTime date)
        {
            return GetUserLogs().Count(r => r.Role == role
            && r.LogDateTime>=date
            && r.LogDateTime<=date 
            );
        }



    }
}