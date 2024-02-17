namespace Doji.Pngcs.Chunks {

    using Doji.Pngcs;
    using System;

    /// <summary>
    /// tEXt chunk: latin1 uncompressed text
    /// </summary>
    public class PngChunkTEXT : PngChunkTextVar {
        public const string ID = ChunkHelper.tEXt;

        public PngChunkTEXT(ImageInfo info)
            : base(ID, info) {
        }

        public override ChunkRaw CreateRawChunk() {
            if (key.Length == 0)
                throw new PngjException("Text chunk key must be non empty");
            byte[] b1 = PngHelperInternal.charsetLatin1.GetBytes(key);
            byte[] b2 = PngHelperInternal.charsetLatin1.GetBytes(val);
            ChunkRaw chunk = createEmptyChunk(b1.Length + b2.Length + 1, true);
            Array.Copy(b1, 0, chunk.Data, 0, b1.Length);
            chunk.Data[b1.Length] = 0;
            Array.Copy(b2, 0, chunk.Data, b1.Length + 1, b2.Length);
            return chunk;
        }

        public override void ParseFromRaw(ChunkRaw c) {
            int i;
            for (i = 0; i < c.Data.Length; i++)
                if (c.Data[i] == 0)
                    break;
            key = PngHelperInternal.charsetLatin1.GetString(c.Data, 0, i);
            i++;
            val = i < c.Data.Length ? PngHelperInternal.charsetLatin1.GetString(c.Data, i, c.Data.Length - i) : "";
        }

        public override void CloneDataFromRead(PngChunk other) {
            PngChunkTEXT otherx = (PngChunkTEXT)other;
            key = otherx.key;
            val = otherx.val;
        }
    }
}
