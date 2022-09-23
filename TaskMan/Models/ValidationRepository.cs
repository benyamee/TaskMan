using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskMan.Models
{
    [MetadataType(typeof(TaskTableMetadata))]
    public partial class TaskTable
    {
        private class TaskTableMetadata
        {
            [Required(ErrorMessage = "QuoteId is Needed")]
            public int QuoteId { get; set; }
      
            [Required(ErrorMessage = "Quote_type is Needed")]
            public string Quote_Type { get; set; }
            [Required(ErrorMessage = "Contact is Needed")]
            public string Contact { get; set; }

            [Required(ErrorMessage = "Task_Desc is Needed")]
            public string Task_Desc { get; set; }

            [Required(ErrorMessage = "Due_Date is Needed")]
            public DateTime Due_Date { get; set; }

            [Required(ErrorMessage = "Task_Type is Needed")]
            public DateTime Task_Type { get; set; }
        }
    }
}