﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Accounting
{
    public class AccountHead
    {
        [Key]
        public Int32 AccId { get; set; }
        public long AccCode { get; set; }
        public int CompanyId { get; set; }
        public int ParentAccountHeadId { get; set; }
        public string AccountHeadName { get; set; }
        public string Description { get; set; }
        public bool IsPostingHead { get; set; }
        public bool IsCashHead { get; set; }
        public bool IsBankHead { get; set; }
        public bool IsBalanceSheet { get; set; }
        public bool IsIncomeExpense { get; set; }
        public bool IsReceivedPayment { get; set; }
        public int TopAccountHead { get; set; }
        public int SequenceNo { get; set; }
        public int depth { get; set; }
        public int TenantId { get; set; }
        public bool IsAutoImported { get; set; }
        public bool isSummeryFieldforLedger { get; set; }
        public bool isSummeryFieldforTrailBalance { get; set; }
    }
}
