﻿using System.ComponentModel.DataAnnotations;
using NLog;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLog.Extensions.AzureTableStorage
{
    [Target("AzureTableStorage")]
    public class AzureTableStorageTarget : TargetWithLayout
    {
        private TableStorageManager _tableStorageManager;
        
        [Required] 
        public string ConnectionStringKey { get; set; }
        
        [Required]
        public string TableName { get; set; }


        protected override void InitializeTarget()
        {
            base.InitializeTarget();
            _tableStorageManager = new TableStorageManager(ConnectionStringKey, TableName);
        }

        protected override void Write(LogEventInfo logEvent)
        {
            _tableStorageManager.Add(new LogEntity(logEvent));
        }

    }
}
