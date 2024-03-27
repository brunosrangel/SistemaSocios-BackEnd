using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSocios.Core.Model
{
    public abstract class DocModel : IDocModel
    {
       public Guid Id { get; set; }
    }

    internal interface IDocModel
    {
        Guid Id { get; set; }
    }
}
