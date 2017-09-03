using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XyTodo.Helpers
{
    public interface IHelperUserPreferences
    {
        void PutString(string key, string value);
        string GetString(string key);

        void PutInt(string key, int value);
        int GetInt(string key);

        void Clear();
    }
}
