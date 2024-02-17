namespace Doji.Pngcs {

    using System;

    /// <summary>
    /// Gral exception class for PNGCS library
    /// </summary>
    [Serializable]
    public class PngjException : Exception {
        private const long serialVersionUID = 1L;

        public PngjException(string message, Exception cause)
            : base(message, cause) {
        }

        public PngjException(string message)
            : base(message) {
        }

        public PngjException(Exception cause)
            : base(cause.Message, cause) {
        }
    }
}
