using danj_backend.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace danj_backend.Model
{
    [Table("mdr_task_management")]
    public class MDR_Task_Management : ITaskManagement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int taskCode { get; set; }
        [Required]
        public string title { get; set; }
        public string description { get; set; }
        public string subtask { get; set; }
        public string imgurl { get; set; }
        [Required]
        public string priority { get; set; }
        public int assignee_userid { get; set; }
        [Required]
        public string reporter { get; set; }
        [Required]
        public string task_dept { get; set; }
        public char task_status { get; set; }
        public string created_by { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
