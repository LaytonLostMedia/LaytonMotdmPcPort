namespace DocomoCsJavaBridge.Events
{
    public class FrameCompleteEventArgs : EventArgs
    {
        public bool IsFinalFrame { get; }

        public FrameCompleteEventArgs(bool isFinalFrame)
        {
            IsFinalFrame = isFinalFrame;
        }
    }
}
