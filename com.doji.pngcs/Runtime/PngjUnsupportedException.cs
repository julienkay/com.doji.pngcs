namespace Hjg.Pngcs {

    using System;

    /// <summary>
    /// Exception for unsupported operation or feature
    /// </summary>
    [Serializable]
    public class PngjUnsupportedException : Exception {
        private const long serialVersionUID = 1L;

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
