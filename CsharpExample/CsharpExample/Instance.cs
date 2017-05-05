using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpExample
{
    class Instance<T> where T: new()
    {
        private static T instance_;
        public static T GetInstance()
        {
            if( instance_ ==null )
                instance_= new T();

            return instance_;
        }

        virtual public void Show() { }
    }
}
