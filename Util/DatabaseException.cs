using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[Serializable]
class DatabaseException : Exception
{
    public DatabaseException()
    {

    }

    public DatabaseException(string pParametro)
        : base( pParametro )
    {

    }
    
    public DatabaseException(string pParametro, Exception inner)
        : base( pParametro, inner )
    {

    }

}

