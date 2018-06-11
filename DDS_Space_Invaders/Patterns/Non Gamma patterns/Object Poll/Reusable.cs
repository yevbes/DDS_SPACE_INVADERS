using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invaders.Patterns.Non_Gamma_patterns.Object_Poll
{
    public class Reusable
    {
        public Object[] Objs { get; protected set; }

        public Reusable(params Object[] objs)
        {
            this.Objs = objs;
        }
    }

    public class Creator : ICreation<Reusable>
    {
        private static Int32 iD = 0;

        public Reusable Create()
        {
            ++iD;
            return new Reusable(iD);
        }
    }

    public class ReusablePool : ObjectPool<Reusable>
    {
        public ReusablePool()
            : base(new Creator(), 2)
        {

        }
    }
}