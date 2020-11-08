using System;
using System.Collections.Generic;
using System.Text;

namespace JenPile {
    class Expression {

        #region Properties

        #endregion

        #region Constructor
        public Expression() { }
        #endregion

        #region Class Methods
        // <Expression> -> <Expression> + <Term>
        // <Expression> -> <Expression> - <Term>
        // <Expression> -> <Term>

        // <Term> -> <Term> * <Factor>
        // <Term> -> <Term> / <Factor> 
        // <Term> -> <Factor> 

        // <Factor> -> (Expression)
        // <Factor> -> ID
        // <Factor> -> Num

        // ID -> id

        // bottom up approach - the first term to be computed will be on the bottom (like multiplying)

        #endregion

       







    }
}
