using System;

namespace Doji.Pngcs.Chunks {

    /// <summary>
    /// iCCP Chunk: see http://www.w3.org/TR/PNG/#11iCCP
    /// </summary>
    public class PngChunkICCP : PngChunkSingle {

        public const string ID = ChunkHelper.iCCP;

        private string profileName;

        private byte[] compressedProfile;

        public PngChunkICCP(ImageInfo info)
            : base(ID, info) {
        }

        public override ChunkOrderingConstraint GetOrderingConstraint() {
            return ChunkOrderingConstraint.BEFORE_PLTE_AND_IDAT;
        }

        public override ChunkRaw CreateRawChunk() {
            ChunkRaw c = createEmptyChunk(profileName.Length + compressedProfile.Length + 2, true);
            Array.Copy((Array)(ChunkHelper.ToBytes(profileName)), 0, (Array)(c.Data), 0, profileName.Length);
            c.Data[profileName.Length] = 0;
            c.Data[profileName.Length + 1] = 0;
            Array.Copy((Array)(compressedProfile), 0, (Array)(c.Data), profileName.Length + 2, compressedProfile.Length);
            return c;
        }

        public override void ParseFromRaw(ChunkRaw chunk) {
            int pos0 = ChunkHelper.PosNullByte(chunk.Data);
            profileName = PngHelperInternal.charsetLatin1.GetString(chunk.Data, 0, pos0);
            int comp = (chunk.Data[pos0 + 1] & 0xff);
            if (comp != 0)
                throw new Exception("bad compression for ChunkTypeICCP");
            int compdatasize = chunk.Data.Length - (pos0 + 2);
            compressedProfile = new byte[compdatasize];
            Array.Copy((Array)(chunk.Data), pos0 + 2, (Array)(compressedProfile), 0, compdatasize);
        }

        public override void CloneDataFromRead(PngChunk other) {
            PngChunkICCP otherx = (PngChunkICCP)other;
            profileName = otherx.profileName;
            compressedProfile = new byte[otherx.compressedProfile.Length];
            Array.Copy(otherx.compressedProfile, compressedProfile, compressedProfile.Length);

        }

        /// <summary>
        /// Sets profile name and profile
        /// </summary>
        /// <param name="name">profile name </param>
        /// <param name="profile">profile (latin1 string)</param>
        public void SetProfileNameAndContent(string name, string profile) {
            SetProfileNameAndContent(name, ChunkHelper.ToBytes(profileName));
        }

        /// <summary>
        /// Sets profile name and profile
        /// </summary>
        /// <param name="name">profile name </param>
        /// <param name="profile">profile (uncompressed)</param>
        public void SetProfileNameAndContent(string name, byte[] profile) {
            profileName = name;
            compressedProfile = ChunkHelper.compressBytes(profile, true);
        }

        public string GetProfileName() {
            return profileName;
        }

        /// <summary>
        /// This uncompresses the string!
        /// </summary>
        /// <returns></returns>
        public byte[] GetProfile() {
            return ChunkHelper.compressBytes(compressedProfile, false);
        }

        public string GetProfileAsString() {
            return ChunkHelper.ToString(GetProfile());
        }
    }
}
