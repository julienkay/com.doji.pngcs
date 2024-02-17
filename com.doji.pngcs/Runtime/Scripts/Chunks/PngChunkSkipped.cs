﻿namespace Doji.Pngcs.Chunks {
    public class PngChunkSkipped : PngChunk {
        internal PngChunkSkipped(string id, ImageInfo imgInfo, int clen)
            : base(id, imgInfo) {
            Length = clen;
        }

        public sealed override bool AllowsMultiple() {
            return true;
        }

        public sealed override ChunkRaw CreateRawChunk() {
            throw new PngjException("Non supported for a skipped chunk");
        }

        public sealed override void ParseFromRaw(ChunkRaw c) {
            throw new PngjException("Non supported for a skipped chunk");
        }

        public sealed override void CloneDataFromRead(PngChunk other) {
            throw new PngjException("Non supported for a skipped chunk");
        }

        public override ChunkOrderingConstraint GetOrderingConstraint() {
            return ChunkOrderingConstraint.NONE;
        }
    }
}
