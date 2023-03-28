using System.Numerics;

namespace danj_backend.Data
{
    public interface ITaskManagement
    {
        int id { get; set; }
        int taskCode { get; set; }
        string title { get; set; }
        string description { get; set; }
        string subtask { get; set; }
        string imgurl { get; set; }
        string priority { get; set; }
        int assignee_userid { get; set; }
        string reporter { get; set; }
        string task_dept { get; set; }
        char task_status { get; set; }
        string created_by { get; set; }
        DateTime created_at { get; set; }
        DateTime updated_at { get; set; }
    }
}
