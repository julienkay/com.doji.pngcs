namespace Hjg.Pngcs {

    using System;

    /// <summary>
    /// Exception for internal problems
    /// </summary>
    [Serializable]
    public class PngjExceptionInternal : Exception {
        private const long serialVersionUID = 1L;

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
