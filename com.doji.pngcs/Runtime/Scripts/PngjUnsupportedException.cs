using System;

namespace Doji.Pngcs {

    /// <summary>
    /// Exception for unsupported operation or feature
    /// </summary>
    [Serializable]
    public class PngjUnsupportedException : Exception {

        public PngjUnsupportedException()
            : base() {
        }

        public PngjUnsupportedException(string message, Exception cause)
            : base(message, cause) {
        }

        public PngjUnsupportedException(string message)
            : base(message) {
        }

        public PngjUnsupportedException(Exception cause)
            : base(cause.Message, cause) {
        }
    }
}
