using System;

namespace Assets
{
    /// <summary>
    /// An interface for main thread action dispatching
    /// </summary>
    public interface IDispatcher
    {
        /// <summary>
        /// Schedule code for execution in the main-thread. 
        /// </summary>
        /// <param name="fn">The Action to be executed</param>
        void Enqueue(Action fn);

        /// <summary>
        /// Invoke (execute) all pending actions on the main thread 
        /// </summary>
        void InvokeAllPending();

        /// <summary>
        /// Invoke the oldest action added to the queue. Executed on the main thread 
        /// </summary>
        void InvokeOne();
    }
}
