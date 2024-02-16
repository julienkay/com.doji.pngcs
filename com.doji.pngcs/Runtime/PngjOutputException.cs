namespace Hjg.Pngcs {

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Exception associated with input (reading) operations
    /// </summary>
    [Serializable]
    public class PngjOutputException : PngjException {
        private const long serialVersionUID = 1L;

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
