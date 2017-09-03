using SQLite;

namespace XyTodo.Models
{
    [Table( "task" )]
    public class ModelTask : ModelBase
    {
        //项目字段
        public const string COL_ID = "id";
        public const string COL_CONTENT = "content";
        public const string COL_NOTE = "note";
        public const string COL_COLOR = "color";
        public const string COL_TIME_CREATE = "time_create";
        public const string COL_TIME_TARGET = "time_target";
        public const string COL_TIME_DONE = "time_done";
        public const string COL_TIME_SORT = "time_sort";
        public const string COL_STATUS = "status";
        //属性
        [PrimaryKey, AutoIncrement, Column( COL_ID )]
        public int ID { get; set; }//主键
        [Column( COL_CONTENT )]
        public string Content { get; set; }//内容
        [Column( COL_NOTE )]
        public string Note { get; set; }//备注
        [Column( COL_COLOR )]
        public string Color { get; set; }//颜色
        [Column( COL_TIME_CREATE )]
        public int TimeCreate { get; set; }//创建时间
        [Column( COL_TIME_TARGET )]
        public int TimeTarget { get; set; }//目标时间
        [Column( COL_TIME_DONE )]
        public int TimeDone { get; set; }//完成时间
        [Column( COL_TIME_SORT )]
        public int TimeSort { get; set; }//排序时间，用来作常规状态自定义排序用
        [Column( COL_STATUS )]
        public int Status { get; set; }//状态
        [Ignore]
        public ModelTaskSub[] Sub { get; set; }//子任务

        public ModelTask()
        {
            Content = "";
            Note = "";
            Color = "";
            Sub = new ModelTaskSub[] { };
        }
    }
}
