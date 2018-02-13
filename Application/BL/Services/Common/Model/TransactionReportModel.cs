using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services.Transaction.Models;

namespace BL.Services.Common.Model
{
    public class TransactionReportModel
    {
        public IEnumerable<TransactionModel> Transactions { get; set; }
    }
}
