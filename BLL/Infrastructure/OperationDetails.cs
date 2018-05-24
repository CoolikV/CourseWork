using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class OperationDetails//Данный класс будет хранить информацию об успешности операции. 
        //Свойство Succedeed указывает, успешна ли операция, а свойства Message и Property будут хранить соответственно сообщение об ошибке и свойство
        //, на котором произошла ошибка.
    {
        public OperationDetails(bool succedeed, string message, string prop)
        {
            Succedeed = succedeed;
            Message = message;
            Property = prop;
        }
        public bool Succedeed { get; private set; }
        public string Message { get; private set; }
        public string Property { get; private set; }
    }
}
