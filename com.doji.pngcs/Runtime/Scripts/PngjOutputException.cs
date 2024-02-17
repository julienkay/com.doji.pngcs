using System;

namespace Doji.Pngcs {

    /// <summary>
    /// Exception associated with input (reading) operations
    /// </summary>
    [Serializable]
    public class PngjOutputException : PngjException {

        public PngjOutputException(string message, Exception cause)
            : base(message, cause) {
        }

        public PngjOutputException(string message)
            : base(message) {
        }

        public PngjOutputException(Exception cause)
            : base(cause) {
        }
    }
}
