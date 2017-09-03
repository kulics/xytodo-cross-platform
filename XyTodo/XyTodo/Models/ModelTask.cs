using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XyTodo.Models
{
    public class ModelTask : ModelBase
    {
        //项目字段
        public static string COL_ID = "id";
        public static string COL_CONTENT = "content";
        public static string COL_NOTE = "note";
        public static string COL_COLOR = "color";
        public static string COL_TIME_CREATE = "time_create";
        public static string COL_TIME_TARGET = "time_target";
        public static string COL_TIME_DONE = "time_done";
        public static string COL_TIME_SORT = "time_sort";
        public static string COL_STATUS = "status";
        //属性
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }//主键
        public string Content { get; set; }//内容
        public string Note { get; set; }//备注
        public string Color { get; set; }//颜色
        public int TimeCreate { get; set; }//创建时间
        public int TimeTarget { get; set; }//目标时间
        public int TimeDone { get; set; }//完成时间
        public int TimeSort { get; set; }//排序时间，用来作常规状态自定义排序用
        public int Status { get; set; }//状态
        public int Sub { get; set; }//子任务

        public ModelTask()
        {
            Content = "";
            Note = "";
            Color = "";
            //Sub = new List<ModelExtra>();
        }
    }
}
