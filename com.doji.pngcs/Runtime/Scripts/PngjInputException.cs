using System;

namespace Doji.Pngcs {

    /// <summary>
    /// Exception associated with input (reading) operations
    /// </summary>
    [Serializable]
    public class PngjInputException : PngjException {

        public PngjInputException(string message, Exception cause)
            : base(message, cause) {
        }

        public PngjInputException(string message)
            : base(message) {
        }

        public PngjInputException(Exception cause)
            : base(cause) {
        }
    }
}
