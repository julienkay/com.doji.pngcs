namespace Hjg.Pngcs {

    using System;

    /// <summary>
    /// Exception associated with input (reading) operations
    /// </summary>
    [Serializable]
    public class PngjInputException : PngjException {
        private const long serialVersionUID = 1L;

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
