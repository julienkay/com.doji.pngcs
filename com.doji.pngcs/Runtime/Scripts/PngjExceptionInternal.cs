using System;

namespace Doji.Pngcs {

    /// <summary>
    /// Exception for internal problems
    /// </summary>
    [Serializable]
    public class PngjExceptionInternal : Exception {

        public PngjExceptionInternal()
            : base() {
        }

        public PngjExceptionInternal(string message, Exception cause)
            : base(message, cause) {
        }

        public PngjExceptionInternal(string message)
            : base(message) {
        }

        public PngjExceptionInternal(Exception cause)
            : base(cause.Message, cause) {
        }
    }
}
