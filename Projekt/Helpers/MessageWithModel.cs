using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Helpers
{
    class MessageWithModel<ModelType>
    {
        public object Receipent { get; set; }
        public ModelType Model { get; set; }

        public MessageWithModel(object receipent, ModelType model)
        {
            Receipent = receipent;
            Model = model;
        }
    }
}
