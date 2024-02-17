using System.Collections.Generic;
using System;
using System.IO;
using Doji.Pngcs.Chunks;

namespace Doji.Pngcs {

    public static class PngCS {

        public static string GetMetadata(string filePath, string key) {
            if (!File.Exists(filePath)) {
                throw new FileNotFoundException($"The file at path '{filePath}' was not found.");
            }
            PngReader reader = FileHelper.CreatePngReader(filePath);
            string data = reader.GetMetadata().GetTxtForKey(key);
            reader.End();
            return data;
        }

        public static void AddMetadata(string origFilename, Dictionary<string, string> data) {
            string tmp = "tmp.png";
            PngReader reader = FileHelper.CreatePngReader(origFilename);
            PngWriter writer = FileHelper.CreatePngWriter(tmp, reader.ImgInfo, true);

            int chunkBehav = ChunkCopyBehaviour.COPY_ALL_SAFE;
            writer.CopyChunksFirst(reader, chunkBehav);
            foreach (string key in data.Keys) {
                PngChunk chunk = writer.GetMetadata().SetText(key, data[key]);
                chunk.Priority = true;
            }

            int channels = reader.ImgInfo.Channels;
            if (channels < 3)
                throw new NotSupportedException("Writing metadata is only supported for RGB/RGBA images");
            for (int row = 0; row < reader.ImgInfo.Rows; row++) {
                ImageLine l1 = reader.ReadRowInt(row);
                writer.WriteRow(l1, row);
            }
            writer.CopyChunksLast(reader, chunkBehav);
            writer.End();
            reader.End();
            File.Delete(origFilename);
            File.Move(tmp, origFilename);
        }

        public static void AddMetadata(string origFilename, string key, string value) {
            Dictionary<string, string> data = new Dictionary<string, string> {
                { key, value }
            };
            AddMetadata(origFilename, data);
        }
    }
}