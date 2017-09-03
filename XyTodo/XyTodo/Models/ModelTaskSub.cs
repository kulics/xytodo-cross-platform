using SQLite;

namespace XyTodo.Models
{
    //子任务模型
    [Table( "task_sub" )]
    public class ModelTaskSub : ModelBase
    {
        //项目字段
        public const string COL_ID = "id";
        public const string COL_ID_TASK = "id_task";
        public const string COL_CONTENT = "content";
        public const string COL_STATUS = "status";
        //属性
        [PrimaryKey, AutoIncrement, Column( COL_ID )]
        public int ID { get; set; }//主键
        [Column ( COL_ID_TASK )]
        public int IDTask { get; set; }//索引键
        [Column( COL_CONTENT )]
        public string Content { get; set; }//内容
        [Column( COL_STATUS )]
        public int Status { get; set; }//状态

        public ModelTaskSub()
        {
            Content = "";
        }
    }
}
