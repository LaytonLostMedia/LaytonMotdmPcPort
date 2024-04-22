namespace com.nttdocomo
{
    public static class ScratchPad
    {
        public static Stream Open(int pos, bool canWrite)
        {
            string scratchPadPath = PathProvider.Instance.GetScratchPadPath();
            FileAccess access = canWrite ? FileAccess.Write : FileAccess.Read;

            Stream scratchPadStream = File.Open(scratchPadPath, FileMode.OpenOrCreate, access);
            scratchPadStream.Position = pos;

            return scratchPadStream;
        }
    }
}
