using System;

namespace Doji.Pngcs.Chunks {

    /// <summary>
    /// tIME chunk: http://www.w3.org/TR/PNG/#11tIME
    /// </summary>
    public class PngChunkTIME : PngChunkSingle {

        public const string ID = ChunkHelper.tIME;

        private int year, mon, day, hour, min, sec;

        public PngChunkTIME(ImageInfo info)
            : base(ID, info) {
        }

        public override ChunkOrderingConstraint GetOrderingConstraint() {
            return ChunkOrderingConstraint.NONE;
        }

        public override ChunkRaw CreateRawChunk() {
            ChunkRaw c = createEmptyChunk(7, true);
            PngHelperInternal.WriteInt2tobytes(year, c.Data, 0);
            c.Data[2] = (byte)mon;
            c.Data[3] = (byte)day;
            c.Data[4] = (byte)hour;
            c.Data[5] = (byte)min;
            c.Data[6] = (byte)sec;
            return c;
        }

        public override void ParseFromRaw(ChunkRaw chunk) {
            if (chunk.Len != 7)
                throw new PngjException("bad chunk " + chunk);
            year = PngHelperInternal.ReadInt2fromBytes(chunk.Data, 0);
            mon = PngHelperInternal.ReadInt1fromByte(chunk.Data, 2);
            day = PngHelperInternal.ReadInt1fromByte(chunk.Data, 3);
            hour = PngHelperInternal.ReadInt1fromByte(chunk.Data, 4);
            min = PngHelperInternal.ReadInt1fromByte(chunk.Data, 5);
            sec = PngHelperInternal.ReadInt1fromByte(chunk.Data, 6);
        }

        public override void CloneDataFromRead(PngChunk other) {
            PngChunkTIME x = (PngChunkTIME)other;
            year = x.year;
            mon = x.mon;
            day = x.day;
            hour = x.hour;
            min = x.min;
            sec = x.sec;
        }

        public void SetNow(int secsAgo) {
            DateTime d1 = DateTime.Now;
            year = d1.Year;
            mon = d1.Month;
            day = d1.Day;
            hour = d1.Hour;
            min = d1.Minute;
            sec = d1.Second;
        }

        internal void SetYMDHMS(int yearx, int monx, int dayx, int hourx, int minx, int secx) {
            year = yearx;
            mon = monx;
            day = dayx;
            hour = hourx;
            min = minx;
            sec = secx;
        }

        public int[] GetYMDHMS() {
            return new int[] { year, mon, day, hour, min, sec };
        }

        /// <summary>
        /// format YYYY/MM/DD HH:mm:SS
        /// </summary>
        public string GetAsString() {
            return string.Format("%04d/%02d/%02d %02d:%02d:%02d", year, mon, day, hour, min, sec);
        }

    }
}
