using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers
{
    public abstract class IDataQueue<T> : BaseNotify
    {
        public abstract bool IsEmpty();
        public abstract void Enqueue(T add);
        public abstract T Dequeue();
    }
    /*thread safe queue to store all of the data (sent / received) from the server/client*/
    public class ThreadSafeDataQueue<T> : IDataQueue<T>
    {
        //used for the lock statement
        private readonly Object Lock = new Object();
        //the actual data queue to lock
        private Queue<T> Data = new Queue<T>();

        /*checks if the queue is empty*/
        public override bool IsEmpty()
        {
            lock (Lock)
            {
                return Data.Count == 0;
            }
        }

        /*adds a given element to the queue*/
        public override void Enqueue(T add)
        {
            lock (Lock)
            {
                Data.Enqueue(add);
            }
            NotifyPropertyChanged(this, "Added");
        }

        /*removes a given element from the queue*/
        public override T Dequeue()
        {
            T ret;
            lock (Lock)
            {
                ret = Data.Dequeue();
            }
            NotifyPropertyChanged(this, "Removed");
            return ret;
        }
    }
}
