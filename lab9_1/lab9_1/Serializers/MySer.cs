using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9.Serializers
{
    abstract class MySer
    {
        public abstract void Write<T>(T obj, string path);
        public abstract T Read<T>(string path);
    }
}
