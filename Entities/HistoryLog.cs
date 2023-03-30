using System;
using System.ComponentModel.DataAnnotations;
using Web_Api_Computer_Shop.Enum;

namespace Web_Api_Computer_Shop.Entities
{
    public class HistoryLog
    {
        public HistoryLog(string Description, Guid Id_User_Executed, EAction Action, string Old_Data, string New_Data, EStatus Status, ETypeTable Type_Table)
        {
            this.Description = Description;
            this.Id_User_Executed = Id_User_Executed;
            this.Action = Action;
            this.Old_Data = Old_Data;
            this.New_Data = New_Data;
            this.Status = Status;
            this.Type_Table = Type_Table;
        }
        public Guid Id { get; private set; } = Guid.NewGuid();
        [Required(ErrorMessage = "The field status {0} is required")]
        public EStatus Status { get; set; }
        [Required(ErrorMessage = "The field Description {0} is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "The field Id_User_Executed {0} is required")]
        public Guid Id_User_Executed { get; set; }
        [Required(ErrorMessage = "The field Action {0} is required")]
        public EAction Action { get; set; }
        [Required(ErrorMessage = "The field Old_Data {0} is required")]
        public string Old_Data { get; set; }
        [Required(ErrorMessage = "The field New_Data {0} is required")]
        public string New_Data { get; set; }
        [Required(ErrorMessage = "The field Type_Table {0} is required")]
        public ETypeTable Type_Table { get; set; }
        public DateTime Created_Date { get; private set; } = DateTime.Now;
    }
}
